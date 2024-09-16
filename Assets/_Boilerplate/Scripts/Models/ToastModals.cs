using System;
using UnityEngine;

namespace BoilerplateRomi.Models
{
    public class ModalOptions
    {
        public string Message;
        public Action YesAction;
        public Action NoAction;
        public string YesText = "Yes";
        public string NoText = "No";
        public Color YesColor = Color.black;
        public Color NoColor = Color.black;
        public int SafeTap = 1;

        public void ResetButtonCaption()
        {
            YesText = "Yes";
            NoText = "No";
        }
    }

    public class ToastOptions
    {
        public string Message;
        public float Duration = 2f;
        public bool ShowImage;
        public Color ImageColor = Color.white;
        public ToastImage Type = ToastImage.Exclamation;
    }

    [Serializable]
    public class ToastImageSetting
    {
        public ToastImage type;
        public Sprite sprite;
    }

    public enum ToastImage
    {
        Exclamation,
        Checkmark
    }
}