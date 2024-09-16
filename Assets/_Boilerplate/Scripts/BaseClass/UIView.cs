using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using BoilerplateRomi.Models;

namespace BoilerplateRomi.Views
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public abstract class UIView : MonoBehaviour
    {
        [SerializeField] protected BaseTween displayTween;
        [SerializeField] bool hideOnStart = true;
        [SerializeField] protected bool hideGameObjectOnDisable;
        [SerializeField] bool ignoreTimeScale;

        protected Canvas _canvas;
        protected ApplicationController _applicationController;
        protected Action<ModalOptions> _showDialog;
        protected Action<ToastOptions> _showToast;

        public bool IsActive => _canvas.enabled && gameObject.activeInHierarchy;

        protected virtual void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
            displayTween?.Initialize(ignoreTimeScale);

            if (hideOnStart)
                OnHideEnd();
        }

        public virtual void SetupView(ApplicationController applicationController)
        {
            _applicationController = applicationController;
            _showDialog = applicationController.UiManager.ToastModalView.ShowDialog;
            _showToast = applicationController.UiManager.ToastModalView.ShowToast;
        }

        protected virtual void OnEnable()
        {
            if (displayTween == null)
                return;

            displayTween.onDisplayStart += OnDisplayStart;
            displayTween.onDisplayEnd += OnDisplayEnd;
            displayTween.onHideStart += OnHideStart;
            displayTween.onHideEnd += OnHideEnd;
        }

        protected virtual void OnDisable()
        {
            if (displayTween == null)
                return;

            displayTween.onDisplayStart -= OnDisplayStart;
            displayTween.onDisplayEnd -= OnDisplayEnd;
            displayTween.onHideStart -= OnHideStart;
            displayTween.onHideEnd -= OnHideEnd;
        }

        public Sequence GetDisplaySequence(bool reverse = false)
        {
            return displayTween.GetTween(reverse);
        }

        public virtual void PlaySequence(bool reverse = false)
        {
            displayTween.PlaySequence(reverse);
        }

        protected virtual void OnDisplayStart()
        {
            if (hideGameObjectOnDisable)
            {
                gameObject.SetActive(true);
            }
            else
                _canvas.enabled = true;
        }

        protected virtual void OnDisplayEnd() { }

        protected virtual void OnHideStart() { }

        protected virtual void OnHideEnd()
        {
			if (displayTween.IsSequencePlaying())
                return;									 
            if (hideGameObjectOnDisable)
            {
                gameObject.SetActive(false);
            }
            else
                _canvas.enabled = false;
        }
    }
}
