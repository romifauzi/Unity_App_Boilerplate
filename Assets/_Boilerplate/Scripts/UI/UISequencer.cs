using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static Locglo.Boilerplate.Enums;

namespace Locglo.Boilerplate
{
    public class UISequencer : BaseTween
    {
        [SerializeField] BaseTween[] tweens;
        [SerializeField] ESequenceType sequenceType;
        [SerializeField] float staggerInterval;

        #region EDITOR
#if UNITY_EDITOR
        private Vector3 pos, scale;
        private Quaternion rot;
        private float canvasAlpha;

        public void GrabInitialState()
        {
            pos = transform.position;
            rot = transform.rotation;
            scale = transform.localScale;

            if (TryGetComponent(out CanvasGroup canvas))
            {
                canvasAlpha = canvas.alpha;
            }
        }

        public void RestoreInitialState()
        {
            transform.position = pos;
            transform.rotation = rot;
            transform.localScale = scale;

            if (TryGetComponent(out CanvasGroup canvas))
            {
                canvas.alpha = canvasAlpha;
            }
        }
#endif
        #endregion

        public override void Initialize(bool ignoreTimeScale = false)
        {
            InitSeq();

            for (int i = 0; i < tweens.Length; i++)
            {
                tweens[i].Initialize();
                AddTween(sequenceType, forwardSeq, tweens[i].GetTween(), i * staggerInterval);
                AddTween(sequenceType, reverseSeq, tweens[i].GetTween(true), i * staggerInterval);
            }

            base.Initialize(ignoreTimeScale);
        }

        void AddTween(ESequenceType type, Sequence seq, Sequence tween, float step)
        {
            switch (type)
            {
                case ESequenceType.PARALLEL:
                    seq.Join(tween);
                    break;
                case ESequenceType.SERIAL:
                    seq.Append(tween);
                    break;
                case ESequenceType.STAGGERED:
                    seq.Insert(step, tween);
                    break;
            }
        }
    }
}
