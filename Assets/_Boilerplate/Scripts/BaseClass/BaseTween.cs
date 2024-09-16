using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BoilerplateRomi.Views
{
    public abstract class BaseTween : MonoBehaviour
    {
        [SerializeField] protected Ease easeType = Ease.InOutQuad;
        [SerializeField] protected bool invertTween;
        [SerializeField] protected float duration = 0.5f;
        protected Sequence forwardSeq, reverseSeq;

        private bool firstRun = true;

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

        public virtual void Initialize(bool ignoreTimeScale = false)
        {
            forwardSeq.SetUpdate(ignoreTimeScale);
            reverseSeq.SetUpdate(ignoreTimeScale); 
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
            //Extensions.Log(gameObject, "Display Tween Start");
        }

        protected virtual void OnDisplayEnd()
        {
            onDisplayEnd?.Invoke();
            //Extensions.Log(gameObject, "Display Tween End");
        }

        protected virtual void OnHideStart()
        {
            onHideStart?.Invoke();
            //Extensions.Log(gameObject, "Hide Tween Start");
        }

        protected virtual void OnHideEnd()
        {
            onHideEnd?.Invoke();
            //Extensions.Log(gameObject, "Hide Tween End");
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
            if (firstRun)
            {
                GetTween(reverse).Play();
                firstRun = false;
            }
            else
                GetTween(reverse).Restart();
        }
        
        public virtual void StopSequence(bool reverse = false)
        {
            GetTween(reverse).Rewind();
        }
        
        public bool IsSequencePlaying()
        {
            return reverseSeq.IsPlaying() || forwardSeq.IsPlaying();
        }							   
    }
}