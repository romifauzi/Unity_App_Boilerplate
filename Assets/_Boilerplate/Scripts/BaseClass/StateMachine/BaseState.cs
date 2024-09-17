using System.Collections;
using BoilerplateRomi.Enums;
using UnityEngine;

namespace BoilerplateRomi.StateMachine
{
    public class BaseState
    {
        protected ApplicationController _applicationController;
        protected readonly string _stateName;
        protected static object Payload;

        public string StateName { get => _stateName; }

        public BaseState(ApplicationController applicationController, string stateName)
        {
            _applicationController = applicationController;
            _stateName = stateName;
        }

        public virtual IEnumerator StateStart()
        {
            Extensions.Log("Time: {0}, {1} state started", Time.time, _stateName);
            yield return null;
            EventController.AddListener(EventId.OnBackPressedAndroid, OnBackPressed);
        }

        public virtual void StateUpdate()
        {
            //Debug.LogFormat("{0} state updates", stateName);
        }

        public virtual IEnumerator StateEnd()
        {
            Extensions.Log("Time: {0}, {1} state ended", Time.time, _stateName);
            yield return null;
            EventController.RemoveListener(EventId.OnBackPressedAndroid, OnBackPressed);
        }

        public virtual void ToPreviousState()
        {
            
        }
        
        public virtual void OnBackPressed()
        {
            Extensions.Log($"Back Pressed, State: {_stateName}");
        }
    }
}