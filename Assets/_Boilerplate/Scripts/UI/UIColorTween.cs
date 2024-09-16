using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace BoilerplateRomi.Views
{
    [RequireComponent(typeof(Image))]
    public class UIColorTween : BaseTween
    {
        [SerializeField] private Image image;
        [SerializeField] private bool initImage;
        [SerializeField] private Color targetColor;

        private Color _initColor, _targetColor;
        public override void Initialize(bool ignoreTimeScale = false)
        {
            _initColor = invertTween ? targetColor : image.color;
            _targetColor = invertTween ? image.color : targetColor;

            InitSeq();

            if (initImage)
            {
                image.color = _initColor;
            }

            forwardSeq.AppendCallback(delegate { image.color = _initColor; });
            forwardSeq.Append(image.DOColor(_targetColor, duration)).SetEase(easeType);

            reverseSeq.AppendCallback(delegate { image.color = _targetColor; });
            reverseSeq.Append(image.DOColor(_initColor, duration)).SetEase(easeType);

            base.Initialize(ignoreTimeScale);
        }
    }
}