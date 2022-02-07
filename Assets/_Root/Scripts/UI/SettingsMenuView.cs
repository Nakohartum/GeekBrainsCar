using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Racing.UI
{
    internal class SettingsMenuView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        public void Init(UnityAction back)
        {
            _backButton.onClick.AddListener(back);
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveAllListeners();
        }
    }
}