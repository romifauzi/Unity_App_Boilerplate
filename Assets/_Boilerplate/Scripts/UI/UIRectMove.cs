using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BoilerplateRomi.Views
{
    public class UIRectMove : BaseTween
    {
        [SerializeField] Vector2 movePos;
        private RectTransform rect;

        public bool initTransform;

        private Vector3 initialPos, targetPos;

        public override void Initialize(bool ignoreTimeScale = false)
        {
            rect = GetComponent<RectTransform>();
            initialPos = invertTween ? rect.anchoredPosition + movePos : rect.anchoredPosition;
            targetPos = invertTween ? rect.anchoredPosition  : rect.anchoredPosition + movePos;

            InitSeq();

            forwardSeq.AppendCallback(delegate { rect.anchoredPosition = initialPos; });
            forwardSeq.Append(rect.DOAnchorPos(targetPos, duration)).SetEase(easeType);

            reverseSeq.AppendCallback(delegate { rect.anchoredPosition = targetPos; });
            reverseSeq.Append(rect.DOAnchorPos(initialPos, duration)).SetEase(easeType);

            if (initTransform)
                rect.anchoredPosition = initialPos;

            base.Initialize(ignoreTimeScale);
        }
    }
}