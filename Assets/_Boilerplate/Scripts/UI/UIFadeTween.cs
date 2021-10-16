using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Locglo.Boilerplate
{
    public class UIFadeTween : BaseTween
    {
        [SerializeField] private CanvasGroup fadeCanvas;
        [SerializeField] private float targetAlpha = 0f;

        private float _initAlpha, _targetAlpha;
        public override void Initialize()
        {
            _initAlpha = invertTween ? targetAlpha : fadeCanvas.alpha;
            _targetAlpha = invertTween ? fadeCanvas.alpha : targetAlpha;

            InitSeq();

            fadeCanvas.alpha = _initAlpha;

            forwardSeq.AppendCallback(delegate { fadeCanvas.alpha = _initAlpha; });
            forwardSeq.Append(fadeCanvas.DOFade(_targetAlpha, duration)).SetEase(easeType);

            reverseSeq.AppendCallback(delegate { fadeCanvas.alpha = _targetAlpha; });
            reverseSeq.Append(fadeCanvas.DOFade(_initAlpha, duration)).SetEase(easeType);

            base.Initialize();
        }
    }
}