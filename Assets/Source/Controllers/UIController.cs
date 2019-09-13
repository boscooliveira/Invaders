using Assets.Source.Models.Game;
using Assets.Source.Services.DI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Controllers
{
    [Serializable]
    public class UIStateActivator
    {
        public EUIState UIState;
        public GameObject ObjectToActivate;
    }

    public class UIController : MonoBehaviour
    {
        public List<UIStateActivator> Activators;
        private IUIManager _uiManager;
        private UIStateActivator _currentActivator;

        public void Awake()
        {
            _uiManager = DIContainer.Instance.Resolve<IUIManager>();
            _uiManager.UIStateChanged += OnUIStateChanged;
        }

        private void OnUIStateChanged(EUIState state)
        {
            if (_currentActivator?.UIState == state)
            {
                return;
            }

            if (_currentActivator != null)
            {
                _currentActivator.ObjectToActivate.SetActive(false);
            }

            UIStateActivator activator = GetActivator(state);
            if (activator == null)
            {
                return;
            }

            _currentActivator = activator;
            _currentActivator.ObjectToActivate.SetActive(true);
        }

        private UIStateActivator GetActivator(EUIState state)
        {
            foreach (var activator in Activators)
            {
                if (state == activator.UIState)
                {
                    return activator;
                }
            }
            return null;
        }
    }
}
