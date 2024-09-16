using System.Collections;
using BoilerplateRomi.Enums;
using UnityEngine;

namespace BoilerplateRomi.StateMachine
{
    public class BaseState
    {
        protected ApplicationController _applicationController;
        protected readonly EStateName EStateName;
        protected static object Payload;

        public EStateName StateName { get => EStateName; }

        public BaseState(ApplicationController applicationController, EStateName eStateName)
        {
            _applicationController = applicationController;
            this.EStateName = eStateName;
        }

        public virtual IEnumerator StateStart()
        {
            Extensions.Log("Time: {0}, {1} state started", Time.time, EStateName);
            yield return null;
            EventController.AddListener(EventId.OnBackPressedAndroid, OnBackPressed);
        }

        public virtual void StateUpdate()
        {
            //Debug.LogFormat("{0} state updates", stateName);
        }

        public virtual IEnumerator StateEnd()
        {
            Extensions.Log("Time: {0}, {1} state ended", Time.time, EStateName);
            yield return null;
            EventController.RemoveListener(EventId.OnBackPressedAndroid, OnBackPressed);
        }

        public virtual void ToPreviousState()
        {
            
        }
        
        public virtual void OnBackPressed()
        {
            Extensions.Log($"Back Pressed, State: {EStateName}");
        }
    }
}