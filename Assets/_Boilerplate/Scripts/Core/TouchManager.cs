using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using System;

namespace BoilerplateRomi
{
    public class TouchManager : CoreScript
    {
        private List<Action<float>> twistActions = new List<Action<float>>();
        private List<Action<float>> pinchActions = new List<Action<float>>();
        private List<Action<Vector2, Vector2>> dragActions = new List<Action<Vector2, Vector2>>();
        private List<Action<Vector2>> tapActions = new List<Action<Vector2>>();

        public override IEnumerator Setup(ApplicationController main)
        {
            LeanTouch.OnGesture += OnGesture;
            LeanTouch.OnFingerTap += OnTap;
            return base.Setup(main);
        }

        private void OnDestroy()
        {
            LeanTouch.OnGesture -= OnGesture;
            LeanTouch.OnFingerTap -= OnTap;
        }

        private void OnTap(LeanFinger obj)
        {
            var tapPos = obj.ScreenPosition;

            foreach (var item in tapActions)
            {
                item.Invoke(tapPos);
            }
        }

        private void OnGesture(List<LeanFinger> obj)
        {
            //if multi touch detected
            if (obj.Count > 1)
            {
                //get pinch and twist gestures delta values
                var pinchScale = LeanGesture.GetPinchScale(obj);
                var twistDegrees = LeanGesture.GetTwistDegrees(obj);

                //invoke the values to all the registered delegates from core touch
                foreach (var item in pinchActions)
                {
                    item.Invoke(pinchScale);
                }

                foreach (var item in twistActions)
                {
                    item.Invoke(twistDegrees);
                }
            }
            else
            {
                var deltaPos = obj[0].ScreenDelta;
                var screenPos = obj[0].ScreenPosition;

                foreach (var item in dragActions)
                {
                    item.Invoke(deltaPos, screenPos);
                }
            }
        }

        public void RegisterTwistEvent(Action<float> action)
        {
            if (twistActions.Contains(action))
            {
                Debug.LogWarningFormat("{0} has already been registered", action.Method.Name);
                return;
            }

            twistActions.Add(action);
        }

        public void RegisterPinchEvent(Action<float> action)
        {
            if (pinchActions.Contains(action))
            {
                Debug.LogWarningFormat("{0} has already been registered", action.Method.Name);
                return;
            }

            pinchActions.Add(action);
        }

        public void RegisterTapEvent(Action<Vector2> action)
        {
            if (tapActions.Contains(action))
            {
                Debug.LogWarningFormat("{0} has already been registered", action.Method.Name);
                return;
            }

            tapActions.Add(action);
        }

        public void RegisterDragEvent(Action<Vector2, Vector2> action)
        {
            if (dragActions.Contains(action))
            {
                Debug.LogWarningFormat("{0} has already been registered", action.Method.Name);
                return;
            }

            dragActions.Add(action);
        }

        public void UnregisterTwistEvent(Action<float> action)
        {
            if (twistActions.Contains(action))
            {
                twistActions.Remove(action);
            }
            else
                Debug.LogWarningFormat("{0} not found, cancel unregister", action.Method.Name);

        }

        public void UnregisterPinchEvent(Action<float> action)
        {
            if (pinchActions.Contains(action))
            {
                pinchActions.Remove(action);
            }
            else
                Debug.LogWarningFormat("{0} not found, cancel unregister", action.Method.Name);
        }

        public void UnregisterTapEvent(Action<Vector2> action)
        {
            if (tapActions.Contains(action))
            {
                tapActions.Remove(action);
            }
            else
                Debug.LogWarningFormat("{0} not found, cancel unregister", action.Method.Name);
        }

        public void UnregisterDragEvent(Action<Vector2, Vector2> action)
        {
            if (dragActions.Contains(action))
            {
                dragActions.Remove(action);
            }
            else
                Debug.LogWarningFormat("{0} not found, cancel unregister", action.Method.Name);
        }
    }
}