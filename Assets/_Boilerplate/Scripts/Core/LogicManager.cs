using System.Collections;
using BoilerplateRomi.StateMachine;

namespace BoilerplateRomi
{
    public class LogicManager : BaseStateMachine
    {
        public override IEnumerator Setup(ApplicationController applicationController)
        {
            AddState(new StartState(applicationController));
            AddState(new MainState(applicationController));
            AddState(new HelpState(applicationController));
            return base.Setup(applicationController);
        }
    }
}