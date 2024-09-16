using BoilerplateRomi.Views;
using System.Collections;

namespace BoilerplateRomi.StateMachine
{
    public class StartState : BaseState
    {
        public StartState(ApplicationController applicationController): base(applicationController, Enums.EStateName.START)
        {
            
        }

        public override IEnumerator StateStart()
        {
            _applicationController.UiManager.DisplayView<StartView>();
            yield return base.StateStart();
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
        }

        public override IEnumerator StateEnd()
        {
            _applicationController.UiManager.HideCurrentView();
            yield return base.StateEnd();
        }
    }
}