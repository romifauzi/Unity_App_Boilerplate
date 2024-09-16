using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BoilerplateRomi.Enums;


namespace BoilerplateRomi.StateMachine
{
    public abstract class BaseStateMachine : CoreScript
    {
        private BaseState currentState;
        private BaseState previousState;
        private BaseState overlayState;

        private Dictionary<Enums.EStateName, BaseState> stateList = new Dictionary<Enums.EStateName, BaseState>();
        
        public event Action<EStateName,bool> OnOverlayUpdate;

        public EStateName ENextState { get; private set; }
        public EStateName ECurrentState { get => currentState?.StateName ?? EStateName.NONE; }
        public EStateName EPreviousState { get => previousState.StateName; }

        public event System.Action<Enums.EStateName> OnStateChanged;
        
        public override IEnumerator Setup(ApplicationController applicationController)
        {
            yield return base.Setup(applicationController);
        }

        protected void AddState(BaseState state)
        {
            stateList.Add(state.StateName, state);
        }

        public BaseState GetCurrentState()
        {
            return currentState;
        }

        public T GetState<T>() where T: BaseState
        {
            var state = stateList.First(x => x.Value is T);

            return state.Value as T;
        }

        public void SwitchState(EStateName newState)
        {
            if (ECurrentState == newState && overlayState == null) return;
            StartCoroutine(SwitchStateCoroutine(stateList[newState]));
        }

        public void OverlayState(EStateName overlayState)
        {
            StartCoroutine(OverlayStateCoroutine(stateList[overlayState]));
        }
        
        IEnumerator OverlayStateCoroutine(BaseState addState)
        {
            if (overlayState == addState)
            {
                yield return overlayState.StateEnd();
                OnOverlayUpdate?.Invoke(overlayState.StateName, false);
                overlayState = null;
                if (currentState != null)
                    yield return currentState.StateStart();
            }
            else
            {
                if (currentState != null)
                    yield return currentState.StateEnd();
                
                overlayState = addState;
                yield return overlayState.StateStart();   
                OnOverlayUpdate?.Invoke(overlayState.StateName, true);
            }
        }

        IEnumerator SwitchStateCoroutine(BaseState newState)
        {
            ENextState = newState.StateName;
            if (currentState != null)
            {
                if (overlayState != null)
                {
                    yield return overlayState.StateEnd();
                    OnOverlayUpdate?.Invoke(overlayState.StateName, false);
                    overlayState = null;
                }
                
                yield return currentState.StateEnd();
                if (newState != currentState)
                    previousState = currentState;
                currentState = null;
            }

            currentState = newState;
            yield return currentState.StateStart();
            OnStateChanged?.Invoke(currentState.StateName);
        }

        public override void CoreUpdate()
        {
            if (currentState != null)
                currentState.StateUpdate();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}