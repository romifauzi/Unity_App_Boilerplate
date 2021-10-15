using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Locglo.Boilerplate
{
    public class MainState : BaseState
    {
        public MainState(ApplicationController applicationController) : base(applicationController, Enums.EStateName.MAIN)
        {

        }

        public override IEnumerator StateStart()
        {
            applicationController.UiManager.DisplayView(Enums.EViewName.MAIN);
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
