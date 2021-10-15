using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Locglo.Boilerplate
{
    public class StartView : UIView
    {
        [SerializeField] Button startButton;

        protected override void Start()
        {
            startButton.onClick.AddListener(StartApp);
            base.Start();
        }

        private void StartApp()
        {
            applicationController.LogicManager.SwitchState(Enums.EStateName.MAIN);
        }
    }
}