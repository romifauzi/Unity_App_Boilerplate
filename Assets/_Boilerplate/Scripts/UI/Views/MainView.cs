using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Locglo.Boilerplate
{
    public class MainView : UIView
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button goToHelpButton;

        protected override void Start()
        {
            backButton.onClick.AddListener(GoToStartState);
            goToHelpButton.onClick.AddListener(GoToHelpState);
            base.Start();
        }

        void GoToStartState()
        {
            applicationController.LogicManager.SwitchState(Enums.EStateName.START);
        }
        void GoToHelpState()
        {
            applicationController.LogicManager.SwitchState(Enums.EStateName.HELP);
        }
    }
}