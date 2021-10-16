using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Locglo.Boilerplate.Enums;

namespace Locglo.Boilerplate
{
    public abstract class BaseStateMachine : CoreScript
    {
        private EStateName m_CurrentState;
        private BaseState currentState;
        private BaseState previousState;

        private Dictionary<EStateName, BaseState> stateList = new Dictionary<EStateName, BaseState>();

        public EStateName ECurrentState { get => currentState.StateName; }
        public EStateName EPreviousState { get => previousState.StateName; }

        public event System.Action<EStateName> OnStateChanged;

        public override IEnumerator Setup(ApplicationController applicationController)
        {
            AddState(new StartState(applicationController));
            AddState(new MainState(applicationController));
            AddState(new HelpState(applicationController));
            yield return base.Setup(applicationController);
        }

        private void AddState(BaseState state)
        {
            stateList.Add(state.StateName, state);
        }

        public void SwitchState(EStateName newState)
        {
            StartCoroutine(SwitchStateCoroutine(stateList[newState]));
        }

        IEnumerator SwitchStateCoroutine(BaseState newState)
        {
            if (currentState != null)
            {
                yield return currentState.StateEnd();
                previousState = currentState;
                currentState = null;
            }

            currentState = newState;
            m_CurrentState = currentState.StateName;
            yield return currentState.StateStart();
            OnStateChanged?.Invoke(currentState.StateName);
        }

        public override void CoreUpdate()
        {
            if (currentState != null)
                currentState.StateUpdate();
        }
    }
}