using BoilerplateRomi;
using BoilerplateRomi.StateMachine;
using ExampleApp.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleApp
{
    public class PokeAppStateManager : LogicManager
    {
        public override IEnumerator Setup(ApplicationController applicationController)
        {
            AddState(new MonsterListState(applicationController));
            AddState(new MonsterDetailState(applicationController));
            return base.Setup(applicationController);
        }
    }
}