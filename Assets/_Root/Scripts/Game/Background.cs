using UnityEngine;

namespace Racing.Game
{
    internal class Background : MonoBehaviour
    {
        [SerializeField] private float _leftBorder;
        [SerializeField] private float _rightBorder;
        [SerializeField] private float _relativeSpeedRate;
        public void Move(float value)
        {
            Vector3 pos = transform.position;
            pos += Vector3.right * value * _relativeSpeedRate;

            if (pos.x <= _leftBorder)
            {
                pos.x = _rightBorder - (_leftBorder - pos.x);
            }
            else if (pos.x >= _rightBorder)
            {
                pos.x = _leftBorder + (_rightBorder - pos.x);
            }

            transform.position = pos;
        }
    }
}