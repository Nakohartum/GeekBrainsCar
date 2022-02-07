using System;

namespace Racing.Tools
{
    internal class SubscriptionProperty<T> : ISubscriptionProperty<T>
    {
        private T _value;
        private Action<T> _onValueChange;

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                _onValueChange?.Invoke(_value);
            }
        }

        public void SubscribeOnChange(Action<T> subscribeAction)
        {
            _onValueChange += subscribeAction;
        }

        public void UnSubscribeOnChange(Action<T> unSubscribeAction)
        {
            _onValueChange -= unSubscribeAction;
        }
    }
}