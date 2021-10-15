using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Locglo.Boilerplate
{
    public abstract class BaseTween : MonoBehaviour
    {
        [SerializeField] protected Ease easeType = Ease.InOutQuad;
        [SerializeField] protected bool invertTween;
        protected Sequence forwardSeq, reverseSeq;

        /// <summary>
        /// callback on start of the display sequence
        /// </summary>
        public event System.Action onDisplayStart;
        /// <summary>
        /// callback on end of the display sequence
        /// </summary>
        public event System.Action onDisplayEnd;
        /// <summary>
        /// callback on start of the hide sequence
        /// </summary>
        public event System.Action onHideStart;
        /// <summary>
        /// callback on end of the hide sequence
        /// </summary>
        public event System.Action onHideEnd;

        public virtual void Initialize()
        {
            forwardSeq.SetAutoKill(false).PrependCallback(OnDisplayStart).AppendCallback(OnDisplayEnd);
            reverseSeq.SetAutoKill(false).PrependCallback(OnHideStart).AppendCallback(OnHideEnd);
            forwardSeq.Pause();
            reverseSeq.Pause();
        }

        protected void InitSeq()
        {
            forwardSeq = DOTween.Sequence();
            reverseSeq = DOTween.Sequence();
        }

        protected virtual void OnDisplayStart()
        {
            onDisplayStart?.Invoke();
            Debug.Log("Display Tween Start", gameObject);
        }

        protected virtual void OnDisplayEnd()
        {
            onDisplayEnd?.Invoke();
            Debug.Log("Display Tween End", gameObject);
        }

        protected virtual void OnHideStart()
        {
            onHideStart?.Invoke();
            Debug.Log("Hide Tween Start", gameObject);
        }

        protected virtual void OnHideEnd()
        {
            onHideEnd?.Invoke();
            Debug.Log("Hide Tween End", gameObject);
        }

        /// <summary>
        /// Get the Sequencer
        /// </summary>
        /// <param name="reverse">return reversed sequence</param>
        public virtual Sequence GetTween(bool reverse = false)
        {
            return reverse ? reverseSeq : forwardSeq;
        }

        /// <summary>
        /// Play the Sequencer
        /// </summary>
        /// <param name="reverse">reverse play sequence</param>
        public virtual void PlaySequence(bool reverse = false)
        {
            GetTween(reverse).Restart();
        }
    }
}