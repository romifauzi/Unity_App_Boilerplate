using System;
using System.Collections;
using System.Collections.Generic;
using BoilerplateRomi.Enums;
using UnityEngine;
using DG.Tweening;

namespace BoilerplateRomi.Views
{
    public class UIManager : CoreScript
    {
        [SerializeField] UIView[] views;

        private UIView _currentView;
        private UIView _previousView;
        [SerializeField] private UIView defaultView;
        
        public override IEnumerator Setup(ApplicationController main)
        {
            InitView(main);
            return base.Setup(main);
        }

        private void InitView(ApplicationController appController)
        {
            foreach (var item in views)
            {
                item.SetupView(appController);
            }

            _currentView = defaultView;
        }
        
        public T GetView<T>() where T: UIView
        {
            foreach (var item in views)
            {
                if (item is T view)
                    return view;
            }

            return null;
        }

        public void DisplayView<T>() where T:UIView
        {
            if (_currentView is T)
            {
                return;
            }

            _currentView = GetView<T>();
            if (_currentView == null) return;
            _currentView.gameObject.SetActive(true);
            _currentView.PlaySequence();
        }

        public void HideCurrentView()
        {
            if (_currentView == null) return;
            _previousView = _currentView;
            _previousView.PlaySequence(true);
        }

        public UIView GetCurrentView()
        {
            return _currentView;
        }
    }
}