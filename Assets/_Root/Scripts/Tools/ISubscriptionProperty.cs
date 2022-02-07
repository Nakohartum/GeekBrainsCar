using System;

namespace Racing.Tools
{
    internal interface ISubscriptionProperty<out T>
    {
        T Value { get; }

        void SubscribeOnChange(Action<T> subscribeAction);
        void UnSubscribeOnChange(Action<T> unSubscribeAction);
    }
}