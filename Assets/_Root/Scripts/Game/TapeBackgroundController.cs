using System;
using Racing.Tools;
using Object = UnityEngine.Object;

namespace Racing.Game
{
    internal class TapeBackgroundController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/background");
        private readonly SubscriptionProperty<float> _diff;
        private readonly ISubscriptionProperty<float> _leftMove;
        private readonly ISubscriptionProperty<float> _rightMove;

        private TapeBackgroundView _tapeBackgroundView;

        public TapeBackgroundController(ISubscriptionProperty<float> leftMove, ISubscriptionProperty<float> rightMove)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _diff = new SubscriptionProperty<float>();
            _tapeBackgroundView = LoadView();
            _tapeBackgroundView.Init(_diff);
            _leftMove.SubscribeOnChange(MoveLeft);
            _rightMove.SubscribeOnChange(MoveRight);
        }

        protected override void OnDispose()
        {
            _leftMove.UnSubscribeOnChange(MoveLeft);
            _rightMove.UnSubscribeOnChange(MoveRight);
        }

        private void MoveRight(float obj)
        {
            _diff.Value = obj;
        }

        private void MoveLeft(float obj)
        {
            _diff.Value = -obj;
        }

        private TapeBackgroundView LoadView()
        {
            var prefab = ResourceLoader.LoadPrefab(_resourcePath);
            var view = Object.Instantiate(prefab);
            AddGameObject(view);
            return view.GetComponent<TapeBackgroundView>();
        }
    }
}