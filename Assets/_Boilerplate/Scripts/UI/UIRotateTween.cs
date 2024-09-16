using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoilerplateRomi.Views
{
    public class UIRotateTween : BaseTween
    {
        [SerializeField] private float targetAngle;

        private float _initAngle, _targetAngle;

        public override void Initialize(bool ignoreTimeScale = false)
        {
            _initAngle = invertTween ? targetAngle : transform.eulerAngles.z;
            _targetAngle = invertTween ? transform.eulerAngles.z : targetAngle;

            InitSeq();

            transform.eulerAngles = new Vector3(0f, 0f, _initAngle);

            forwardSeq.AppendCallback(delegate { transform.eulerAngles = new Vector3(0f, 0f, _initAngle); });
            forwardSeq.Append(transform.DORotate(new Vector3(0f, 0f, _targetAngle), duration));

            reverseSeq.AppendCallback(delegate { transform.eulerAngles = new Vector3(0f, 0f, _targetAngle); });
            reverseSeq.Append(transform.DORotate(new Vector3(0f, 0f, _initAngle), duration));

            base.Initialize(ignoreTimeScale);
        }
    }
}