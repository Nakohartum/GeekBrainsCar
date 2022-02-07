using Racing.Tools;
using UnityEngine;

namespace Racing.Game
{
    internal abstract class BaseInputView : MonoBehaviour
    {
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;
        protected float _speed;

        public virtual void Init(SubscriptionProperty<float> moveLeft, SubscriptionProperty<float> moveRight, float speed)
        {
            _leftMove = moveLeft;
            _rightMove = moveRight;
            _speed = speed;
        }

        protected virtual void OnLeftMove(float value)
        {
            _leftMove.Value = value;
        }

        protected virtual void OnRightMove(float value)
        {
            _rightMove.Value = value;
        }
    }
}