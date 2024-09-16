using BoilerplateRomi.Models;
using UnityEngine;
using UnityEngine.UI;

namespace BoilerplateRomi.Views
{
    public class MainView : UIView
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button goToHelpButton;

        private readonly ModalOptions _options = new ModalOptions();

        protected override void Start()
        {
            backButton.onClick.AddListener(GoToStartState);
            goToHelpButton.onClick.AddListener(GoToHelpState);
            base.Start();
        }

        void GoToStartState()
        {
            _options.Message = "Do you want to go back to Start page?";
            _options.YesText = "Yes, I'm bored here";
            _options.NoText = "I'll stay a bit";
            _options.YesAction = () => _applicationController.LogicManager.SwitchState(Enums.EStateName.START);
            _showDialog?.Invoke(_options);
        }
        void GoToHelpState()
        {
            _options.Message = "Do you want to go to Help page?";
            _options.YesText = "Yes, I need guidance";
            _options.NoText = "Nah";
            _options.YesAction = ()=> _applicationController.LogicManager.SwitchState(Enums.EStateName.HELP);
            _showDialog?.Invoke(_options);
        }
    }
}