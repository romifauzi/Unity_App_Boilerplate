using BoilerplateRomi.Views;
using System.Collections;

namespace BoilerplateRomi.StateMachine
{
    public class HelpState : BaseState
    {
        public HelpState(ApplicationController applicationController): base(applicationController, Enums.EStateName.HELP)
        {
            
        }

        public override IEnumerator StateStart()
        {
            _applicationController.UiManager.DisplayView<HelpView>();
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