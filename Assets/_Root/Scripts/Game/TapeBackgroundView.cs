using Racing.Tools;
using UnityEngine;

namespace Racing.Game
{
    internal class TapeBackgroundView : MonoBehaviour
    {
        [SerializeField] private Background[] _backgrounds;
        private ISubscriptionProperty<float> _diff;

        public void Init(ISubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.SubscribeOnChange(Move);
        }

        private void OnDestroy()
        {
            _diff.UnSubscribeOnChange(Move);
        }

        private void Move(float obj)
        {
            for (int i = 0; i < _backgrounds.Length; i++)
            {
                _backgrounds[i].Move(-obj);
            }
        }
    }
}