using BoilerplateRomi;
using BoilerplateRomi.Enums;
using BoilerplateRomi.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleApp.States
{
    public class MonsterDetailState : BaseState
    {
        public MonsterDetailState(ApplicationController applicationController) : base(applicationController, AppStates.MonsterDetails)
        {

        }
    }
}