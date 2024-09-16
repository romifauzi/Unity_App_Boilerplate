using System.Collections;
using System.Collections.Generic;
using BoilerplateRomi.Enums;
using McKenna;
using UnityEngine;
using EventId = McKenna.EventId;

namespace BoilerplateRomi.StateMachine
{
    public class BaseState
    {
        //protected Main Main;
        protected readonly EStateName EStateName;
        protected static object Payload;

        public EStateName StateName { get => EStateName; }

        public BaseState(Main main, EStateName eStateName)
        {
            //this.Main = main;
            this.EStateName = eStateName;
        }

        public virtual IEnumerator StateStart()
        {
            Extensions.Log("Time: {0}, {1} state started", Time.time, EStateName);
            yield return null;
            EventsController.AddListener(EventId.OnBackPressed, OnBackPressed);
        }

        public virtual void StateUpdate()
        {
            //Debug.LogFormat("{0} state updates", stateName);
        }

        public virtual IEnumerator StateEnd()
        {
            Extensions.Log("Time: {0}, {1} state ended", Time.time, EStateName);
            yield return null;
            EventsController.RemoveListener(EventId.OnBackPressed, OnBackPressed);
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