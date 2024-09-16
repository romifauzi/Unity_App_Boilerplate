using System.Collections;
using BoilerplateRomi.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace McKenna.Controllers
{
    public class UiController : UIManager
    {
        [SerializeField] private CanvasGroup bgCanvasGroup;
        [SerializeField] private TopMenuView topMenuView;
        [SerializeField] private ToastModalView toastModalView;
        [SerializeField] private GameObject loaderScreen;

        public TopMenuView TopMenuView => topMenuView;
        public ToastModalView ToastModalView => toastModalView;

        public override IEnumerator Setup(Main main)
        {
            topMenuView.SetupView(main);
            return base.Setup(main);
        }

        public void ShowBg(bool value)
        {
            bgCanvasGroup.alpha = value ? 1f : 0f;
        }

        public void ShowLoader(bool value)
        {
            loaderScreen.SetActive(value);
        }
    }
}