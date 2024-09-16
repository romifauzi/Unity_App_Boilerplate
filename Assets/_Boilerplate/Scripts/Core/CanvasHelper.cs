using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BoilerplateRomi.Boilerplate
{
    public class CanvasHelper : MonoBehaviour
    {
        private static CanvasScaler canvasScaler;

        // Start is called before the first frame update
        void Start()
        {
            canvasScaler = GetComponent<CanvasScaler>();
        }

        /// <summary>
        /// Convert screen position into UI reference resolution
        /// </summary>
        /// <param name="vec">screen pos</param>
        /// <returns></returns>
        public static Vector2 ScreenPosToUISpace(Vector2 vec)
        {
            Vector2 referenceResolution = canvasScaler.referenceResolution;
            Vector2 currentResolution = new Vector2(Screen.width, Screen.height);

            float widthRatio = currentResolution.x / referenceResolution.x;
            float heightRatio = currentResolution.y / referenceResolution.y;
            float ratio = Mathf.Lerp(widthRatio, heightRatio, canvasScaler.matchWidthOrHeight);

            return vec / ratio;
        }
    }
}