using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static Locglo.Boilerplate.Enums;

namespace Locglo.Boilerplate
{
    public class UIManager : CoreScript
    {
        [SerializeField] UIView[] views;

        UIView currentView;
        UIView previousView;

        public override IEnumerator Setup(ApplicationController applicationController)
        {
            InitView(applicationController);
            return base.Setup(applicationController);;
        }

        private void InitView(ApplicationController appController)
        {
            foreach (var item in views)
            {
                item.SetupView(appController);
            }
        }

        private UIView GetView(EViewName view)
        {
            foreach (var item in views)
            {
                if (item.ViewName == view)
                    return item;
            }

            return null;
        }

        public void DisplayView(EViewName newView)
        {
            //if (currentView != null)
            //{
            //    previousView = currentView;
            //    previousView.GetDisplaySequence(true).Play();
            //}

            currentView = GetView(newView);
            currentView.PlaySequence();
        }

        public void HideCurrentView()
        {
            if (currentView != null)
            {
                previousView = currentView;
                previousView.PlaySequence(true);
            }
        }
    }
}