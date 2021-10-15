using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Locglo.Boilerplate
{
    public class UIFadeTween : BaseTween
    {
        [SerializeField] private CanvasGroup fadeCanvas;
        [SerializeField] private float duration = 0.5f, targetAlpha = 0f;

        public override void Initialize()
        {
            float initAlpha = invertTween ? targetAlpha : fadeCanvas.alpha;
            float _targetAlpha = invertTween ? fadeCanvas.alpha : targetAlpha;

            InitSeq();

            forwardSeq.AppendCallback(delegate { fadeCanvas.alpha = initAlpha; });
            forwardSeq.Append(fadeCanvas.DOFade(_targetAlpha, duration)).SetEase(easeType);

            reverseSeq.AppendCallback(delegate { fadeCanvas.alpha = _targetAlpha; });
            reverseSeq.Append(fadeCanvas.DOFade(initAlpha, duration)).SetEase(easeType);

            base.Initialize();
        }
    }
}