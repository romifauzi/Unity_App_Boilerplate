using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BoilerplateRomi.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIFadeTween : BaseTween
    {
        [SerializeField] private CanvasGroup fadeCanvas;
        [SerializeField] private bool initCanvasGroup;
        [SerializeField] private float targetAlpha = 0f;

        private float _initAlpha, _targetAlpha;
        public override void Initialize(bool ignoreTimeScale = false)
        {
            _initAlpha = invertTween ? targetAlpha : fadeCanvas.alpha;
            _targetAlpha = invertTween ? fadeCanvas.alpha : targetAlpha;

            InitSeq();

            if (initCanvasGroup)
            {
                fadeCanvas.alpha = _initAlpha;
                var interactable = _initAlpha > 0.0001f;
                fadeCanvas.interactable = fadeCanvas.blocksRaycasts = interactable;
            }

            forwardSeq.AppendCallback(delegate { fadeCanvas.alpha = _initAlpha; });
            forwardSeq.Append(fadeCanvas.DOFade(_targetAlpha, duration)).SetEase(easeType);

            reverseSeq.AppendCallback(delegate { fadeCanvas.alpha = _targetAlpha; });
            reverseSeq.Append(fadeCanvas.DOFade(_initAlpha, duration)).SetEase(easeType);

            base.Initialize(ignoreTimeScale);
        }

        protected override void OnDisplayStart()
        {
            base.OnDisplayStart();
            fadeCanvas.interactable = true;
            fadeCanvas.blocksRaycasts = true;
        }

        protected override void OnHideStart()
        {
            base.OnHideStart();
            fadeCanvas.interactable = false;
            fadeCanvas.blocksRaycasts = false;
        }

        private void OnValidate()
        {
            fadeCanvas = GetComponent<CanvasGroup>();
        }
    }
}