using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Scripts.Tools
{
    internal class CustomText : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        public string Text
        {
            get
            {
                return GetText();
            }
            set
            {
                SetText(value);
            }
        }


        private void OnValidate()
        {
            Initialize();
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            bool hasAnyTextComponent = TryAttachTextComponent(ref _text) || TryAttachTextComponent(ref _textMeshPro);
            if (!hasAnyTextComponent)
            {
                throw new UnityException("Can't attach any text component");
            }
        }


        private bool TryAttachTextComponent<TComponent>(ref TComponent component) where TComponent : Component
        {
            if (component != null)
            {
                return true;
            }

            return TryGetComponent(out component);
        }
        
        public void SetText(string text)
        {
            if (_text != null)
            {
                _text.text = text;
            }

            if (_textMeshPro != null)
            {
                _textMeshPro.text = text;
            }
        }

        public string GetText()
        {
            if (_text != null)
            {
                return _text.text;
            }

            if (_textMeshPro != null)
            {
                return _textMeshPro.text;
            }
            
            return String.Empty;
        }
    }
}