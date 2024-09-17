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

        private Dictionary<string, BaseState> stateList = new Dictionary<string, BaseState>();
        
        public event Action<string,bool> OnOverlayUpdate;

        public string ENextState { get; private set; }
        public string ECurrentState { get => currentState?.StateName ?? EStateName.None; }
        public string EPreviousState { get => previousState.StateName; }

        public event Action<string> OnStateChanged;
        
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

        public void SwitchState(string newState)
        {
            if (ECurrentState.Equals(newState) && overlayState == null) return;
            StartCoroutine(SwitchStateCoroutine(stateList[newState]));
        }

        public void OverlayState(string overlayState)
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