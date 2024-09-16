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
        //[SerializeField] Enums.EViewName viewName;

        protected Canvas canvas;
        protected Action<ModalOptions> _showDialog;
        protected Action<ToastOptions> _showToast;

        public bool IsActive => canvas.enabled && gameObject.activeInHierarchy;

        //public Enums.EViewName ViewName { get => viewName; }

        protected virtual void Awake()
        {
            canvas = GetComponent<Canvas>();
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
            displayTween?.Initialize(ignoreTimeScale);

            if (hideOnStart)
                OnHideEnd();
        }

        public virtual void SetupView(ApplicationController main)
        {
            _showDialog = main.UIController.ToastModalView.ShowDialog;
            _showToast = main.UIController.ToastModalView.ShowToast;
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
                canvas.enabled = true;
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
                canvas.enabled = false;
        }
    }
}
