using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BoilerplateRomi.Boilerplate
{
    public class TestTouch : CoreTouch, IPointerDownHandler, IPointerUpHandler
    {
        private bool dragged;
        private RectTransform rectTransform;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Setup(ApplicationController.Instance));
            rectTransform = GetComponent<RectTransform>();
        }

        public override void OnDrag(Vector2 screenDelta, Vector2 screenPos)
        {
            screenDelta = CanvasHelper.ScreenPosToUISpace(screenDelta);

            if (dragged)
            {
                rectTransform.anchoredPosition += screenDelta;
            }

            base.OnDrag(screenDelta, screenPos);
        }

        public override void OnPinchGesture(float scale)
        {
            if (dragged)
            {
                rectTransform.localScale *= scale;
            }

            base.OnPinchGesture(scale);
        }

        public override void OnTwistGesture(float degrees)
        {
            if (dragged)
            {
                Vector3 rot = rectTransform.eulerAngles;
                rot.z += degrees;
                rectTransform.eulerAngles = rot;
            }

            base.OnTwistGesture(degrees);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            dragged = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            dragged = false;
        }
    }
}