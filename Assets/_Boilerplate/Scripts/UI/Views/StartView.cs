using UnityEngine;
using UnityEngine.UI;

namespace BoilerplateRomi.Views
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
            _applicationController.LogicManager.SwitchState(Enums.EStateName.MAIN);
        }
    }
}