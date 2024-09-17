using BoilerplateRomi;
using BoilerplateRomi.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleApp.States
{
    public class MonsterListState : BaseState
    {
        public MonsterListState(ApplicationController applicationController) : base(applicationController, AppStates.MonsterList)
        {

        }
    }
}