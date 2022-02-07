using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Racing.UI
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startGame;
        [SerializeField] private Button _options;
        [SerializeField] private Button _other;

        public void Init(UnityAction startGame, UnityAction options, UnityAction other)
        {
            _startGame.onClick.AddListener(startGame);
            _options.onClick.AddListener(options);
            _other.onClick.AddListener(other);
        }

        private void OnDestroy()
        {
            _startGame.onClick.RemoveAllListeners();
            _options.onClick.RemoveAllListeners();
            _other.onClick.RemoveAllListeners();
        }
    }
}