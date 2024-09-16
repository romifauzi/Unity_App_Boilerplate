using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.DOTweenEditor;
using DG.Tweening;

namespace BoilerplateRomi.Views
{
    [CustomEditor(typeof(UISequencer))]
    public class UISequencerEditor : Editor
    {
        UISequencer source;

        private void OnEnable()
        {
            source = (UISequencer)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(15f);

            if (GUILayout.Button("Preview Tween", GUILayout.Height(30f)))
            {
                if (Application.isPlaying)
                    return;

                if (DOTweenEditorPreview.isPreviewing)
                    return;

                source.GrabInitialState();
                source.Initialize();
                DOTweenEditorPreview.PrepareTweenForPreview(source.GetTween(), true, false);
                source.GetTween().OnComplete(()=> 
                {
                    DOTweenEditorPreview.Stop();
                    source.RestoreInitialState();
                });
                DOTweenEditorPreview.Start();
            }
        }
    }
}