using System;
using JoostenProductions;
using UnityEngine;

namespace Racing.Game
{
    internal class KeyBoardInput : BaseInputView
    {
        private void Start()
        {
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            direction.Normalize();
            var moveValue = direction.x * _speed;
            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);
            if (sign > 0)
            {
                OnRightMove(abs);
            }
            else
            {
                OnLeftMove(abs);
            }
        }
    }
}