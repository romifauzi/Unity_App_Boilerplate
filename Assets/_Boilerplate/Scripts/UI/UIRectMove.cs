using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Locglo.Boilerplate
{
    public class UIRectMove : BaseTween
    {
        [SerializeField] Vector2 movePos;
        [SerializeField] float duration;
        private RectTransform rect;

        public override void Initialize()
        {
            rect = GetComponent<RectTransform>();
            Vector2 initialPos = rect.anchoredPosition;
            Vector2 targetPos = initialPos + movePos;

            InitSeq();

            forwardSeq.AppendCallback(delegate { rect.anchoredPosition = initialPos; });
            forwardSeq.Append(rect.DOAnchorPos(targetPos, duration)).SetEase(easeType);

            reverseSeq.AppendCallback(delegate { rect.anchoredPosition = targetPos; });
            reverseSeq.Append(rect.DOAnchorPos(initialPos, duration)).SetEase(easeType);

            forwardSeq.SetAutoKill(false).Pause();
            reverseSeq.SetAutoKill(false).Pause();
        }
    }
}