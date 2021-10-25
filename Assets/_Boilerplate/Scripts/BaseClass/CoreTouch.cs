using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Locglo.Boilerplate
{
    public abstract class CoreTouch : CoreScript
    {
        public override IEnumerator Setup(ApplicationController applicationController)
        {
            yield return base.Setup(applicationController);
            RegisterEvents();
        }

        public virtual void OnPinchGesture(float scale)
        {
            Debug.LogFormat("{0} pinch value, GO {1}", scale, gameObject.name);
        }

        public virtual void OnTwistGesture(float degrees)
        {
            Debug.LogFormat("{0} twist value, GO {1}", degrees, gameObject.name);
        }

        public virtual void OnTap(Vector2 screenPos)
        {
            Debug.LogFormat("{0} tap screen pos value, GO {1}", screenPos, gameObject.name);
        }

        public virtual void OnDrag(Vector2 screenDelta, Vector2 screenPos)
        {
            Debug.LogFormat("{0} delta drag value, {1} screen pos value, GO {2}", screenDelta, screenPos, gameObject.name);
        }

        private void RegisterEvents()
        {
            applicationController.TouchManager.RegisterPinchEvent(OnPinchGesture);
            applicationController.TouchManager.RegisterTwistEvent(OnTwistGesture);
            applicationController.TouchManager.RegisterTapEvent(OnTap);
            applicationController.TouchManager.RegisterDragEvent(OnDrag);
        }

        private void UnregisterEvents()
        {
            applicationController.TouchManager.UnregisterPinchEvent(OnPinchGesture);
            applicationController.TouchManager.UnregisterTwistEvent(OnTwistGesture);
            applicationController.TouchManager.UnregisterTapEvent(OnTap);
            applicationController.TouchManager.UnregisterDragEvent(OnDrag);
        }

        private void OnEnable()
        {
            if (applicationController != null)
                RegisterEvents();
        }

        private void OnDisable()
        {
            if (applicationController != null)
                UnregisterEvents();
        }
    }
}