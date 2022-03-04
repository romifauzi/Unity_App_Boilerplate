using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Locglo.Boilerplate.Enums;
using DG.Tweening;

namespace Locglo.Boilerplate
{
    [RequireComponent(typeof(Canvas))]
    public abstract class UIView : MonoBehaviour
    {
        [SerializeField] BaseTween displayTween;
        [SerializeField] bool hideOnStart = true;
        [SerializeField] protected bool hideGameObjectOnDisable;
        [SerializeField] bool ignoreTimeScale;
        [SerializeField] EViewName viewName;

        protected Canvas canvas;
        protected ApplicationController applicationController;

        public bool IsActive => canvas.enabled && gameObject.activeInHierarchy;

        public EViewName ViewName { get => viewName; }

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

        public virtual void SetupView(ApplicationController applicationController)
        {
            this.applicationController = applicationController;
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
