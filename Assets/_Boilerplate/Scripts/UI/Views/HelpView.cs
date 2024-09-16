using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BoilerplateRomi.Views
{
    public class HelpView : UIView
    {
        [SerializeField] private Button backButton;

        protected override void Start()
        {
            backButton.onClick.AddListener(GoToMainState);
            base.Start();
        }

        void GoToMainState()
        {
            _applicationController.LogicManager.SwitchState(Enums.EStateName.MAIN);
        }
    }
}