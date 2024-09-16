using BoilerplateRomi.Models;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BoilerplateRomi.Views
{
    public class ToastModalView : MonoBehaviour
    {
        [Header("Toast")] 
        [SerializeField] private BaseTween toastSequencer;
        [SerializeField] private TMP_Text toastText;
        
        [Header("Modal")] 
        [SerializeField] private BaseTween modalSequencer;
        [SerializeField] private TMP_Text modalText;
        [SerializeField] private Button yesButton, noButton;
       

        private Coroutine _toastCoroutine;
        private Coroutine _modalCoroutine;

        // Start is called before the first frame update
        void Start()
        {
            toastSequencer.Initialize();
            modalSequencer?.Initialize();
        }

        public void ShowToast(ToastOptions options)
        {
            if (_toastCoroutine != null)
                StopCoroutine(_toastCoroutine);
            
            toastSequencer.PlaySequence();
            toastText.SetText(options.Message);

            _toastCoroutine = StartCoroutine(HideToast());

            IEnumerator HideToast()
            {
                yield return new WaitForSeconds(options.Duration);
                toastSequencer.PlaySequence(true);
                _toastCoroutine = null;
            }
        }

        public void ShowDialog(ModalOptions options)
        {
            modalSequencer.PlaySequence();
            modalText.SetText(options.Message);
            var yesText = yesButton.GetComponentInChildren<TMP_Text>();

            yesButton.onClick.RemoveAllListeners();
            yesButton.onClick.AddListener(() =>
            {
                if (options.SafeTap > 1)
                {
                    options.SafeTap--;
                    return;
                }

                options.YesAction?.Invoke();
                HideDialog();
            });

            yesText.SetText(options.YesText);
            yesText.color = options.YesColor;
            
            noButton.onClick.RemoveAllListeners();
            noButton.onClick.AddListener(() =>
            {
                options.NoAction?.Invoke();
                HideDialog();
            });
            
            var noText = noButton.GetComponentInChildren<TMP_Text>();
            noText.SetText(options.NoText);
            noText.color = options.NoColor;
        }
        public void HideDialog()
        {
            Extensions.Log("hide dialog");
            modalSequencer.PlaySequence(true);
        }
    }
}