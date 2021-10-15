using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Locglo.Boilerplate
{
    public class StartState : BaseState
    {
        public StartState(ApplicationController applicationController): base(applicationController, Enums.EStateName.START)
        {
            
        }

        public override IEnumerator StateStart()
        {
            applicationController.UiManager.DisplayView(Enums.EViewName.START);
            yield return base.StateStart();
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
        }

        public override IEnumerator StateEnd()
        {
            applicationController.UiManager.HideCurrentView();
            yield return base.StateEnd();
        }
    }
}