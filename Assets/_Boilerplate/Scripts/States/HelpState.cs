using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Locglo.Boilerplate
{
    public class HelpState : BaseState
    {
        public HelpState(ApplicationController applicationController): base(applicationController, Enums.EStateName.HELP)
        {
            
        }

        public override IEnumerator StateStart()
        {
            applicationController.UiManager.DisplayView(Enums.EViewName.HELP);
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