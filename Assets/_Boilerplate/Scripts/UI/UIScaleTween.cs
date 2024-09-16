using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoilerplateRomi.Views
{
    public class UIScaleTween : BaseTween
    {
        [SerializeField] Vector3 targetScale;

        private Vector3 _initScale, _targetScale;

        public override void Initialize(bool ignoreTimeScale = false)
        {
            _initScale = invertTween ? targetScale : transform.localScale;
            _targetScale = invertTween ? transform.localScale : targetScale;

            InitSeq();

            forwardSeq.AppendCallback(delegate { transform.localScale = _initScale; });
            forwardSeq.Append(transform.DOScale(_targetScale, duration)).SetEase(easeType);

            reverseSeq.AppendCallback(delegate { transform.localScale = _targetScale; });
            reverseSeq.Append(transform.DOScale(_initScale, duration)).SetEase(easeType);

            base.Initialize(ignoreTimeScale);
        }
    }
}