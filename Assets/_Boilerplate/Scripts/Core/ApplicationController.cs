using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Locglo.Boilerplate.Enums;

namespace Locglo.Boilerplate
{
    public class ApplicationController : MonoBehaviour
    {
        #region Variables
        [SerializeField] private EStateName startState;

        [Header("Managers")]
        [SerializeField] private LogicManager logicManager;
        [SerializeField] private UIManager uiManager;
        #endregion

        #region Properties
        public ApplicationController Instance { get; private set; }
        public LogicManager LogicManager { get => logicManager; }
        public UIManager UiManager { get => uiManager; }
        #endregion

        private void Awake()
        {
            Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(InitApp());
        }

        IEnumerator InitApp()
        {
            yield return LogicManager.Setup(this);
            yield return UiManager.Setup(this);

            LogicManager.SwitchState(startState);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                LogicManager.SwitchState(EStateName.MAIN);
            }
        }
    }
}