using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Locglo.Boilerplate.Enums;

namespace Locglo.Boilerplate
{
    public class BaseState
    {
        protected ApplicationController applicationController;
        protected EStateName stateName;

        public EStateName StateName { get => stateName; }

        public BaseState(ApplicationController applicationController, EStateName stateName)
        {
            this.applicationController = applicationController;
            this.stateName = stateName;
        }

        public virtual IEnumerator StateStart()
        {
            Debug.LogFormat("Time: {0}, {1} state started", Time.time, stateName);
            yield return null;
        }

        public virtual void StateUpdate()
        {
            Debug.LogFormat("{0} state updates", stateName);
        }

        public virtual IEnumerator StateEnd()
        {
            Debug.LogFormat("Time: {0}, {1} state ended", Time.time, stateName);
            yield return null;
        }
    }
}