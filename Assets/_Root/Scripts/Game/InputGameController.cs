using Racing.Tools;
using Racing.Transport;
using UnityEngine;

namespace Racing.Game
{
    internal class InputGameController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/EndlessMove");

        private BaseInputView _inputView;
        public InputGameController(SubscriptionProperty<float> leftMoveDiff, 
            SubscriptionProperty<float> rightMoveDiff, TransprortModel gameInformationTransprortModel)
        {
            _inputView = LoadView();
            _inputView.Init(leftMoveDiff, rightMoveDiff, gameInformationTransprortModel.Speed);
        }

        private BaseInputView LoadView()
        {
            var prefab = ResourceLoader.LoadPrefab(_resourcePath);
            var objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);
            return objectView.GetComponent<BaseInputView>();
        }
    }
}