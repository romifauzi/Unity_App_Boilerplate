using System.Collections;
using BoilerplateRomi.Enums;
using BoilerplateRomi.Views;
using UnityEngine;


namespace BoilerplateRomi
{
    public class ApplicationController : MonoBehaviour
    {
        #region Variables
        [SerializeField] private EStateName startState;

        [Header("Managers")]
        [SerializeField] private LogicManager logicManager;
        [SerializeField] private UIManager uiManager;
        [SerializeField] private TouchManager touchManager;
        #endregion

        #region Properties
        public static ApplicationController Instance { get; private set; }
        public LogicManager LogicManager { get => logicManager; }
        public UIManager UiManager { get => uiManager; }
        public TouchManager TouchManager { get => touchManager; }
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
            yield return TouchManager.Setup(this);

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