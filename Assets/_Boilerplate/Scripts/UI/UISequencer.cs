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

        public override void Initialize()
        {
            InitSeq();

            for (int i = 0; i < tweens.Length; i++)
            {
                tweens[i].Initialize();
                AddTween(sequenceType, forwardSeq, tweens[i].GetTween(), i * staggerInterval);
                AddTween(sequenceType, reverseSeq, tweens[i].GetTween(true), i * staggerInterval);
            }

            base.Initialize();
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
