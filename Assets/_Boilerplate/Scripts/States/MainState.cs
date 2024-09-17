using BoilerplateRomi.Enums;
using BoilerplateRomi.Views;
using System.Collections;

namespace BoilerplateRomi.StateMachine
{
    public class MainState : BaseState
    {
        public MainState(ApplicationController applicationController) : base(applicationController, EStateName.Main)
        {

        }

        public override IEnumerator StateStart()
        {
            _applicationController.UiManager.DisplayView<MainView>();
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
