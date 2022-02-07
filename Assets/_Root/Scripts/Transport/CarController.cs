using Racing.Game;
using Racing.Tools;
using UnityEngine;
using static Racing.Game.TransportType;

namespace Racing.Transport
{
    internal class CarController : TransportController
    {
        private readonly ResourcePath _carPath = new ResourcePath("Prefabs/Car");
        private readonly CarView _carView;

        public override GameObject ViewGameObject => _carView.gameObject;

        public CarController()
        {
            _carView = LoadView();
            
        }

        private CarView LoadView()
        {
            var prefab = ResourceLoader.LoadPrefab(_carPath);
            var go = Object.Instantiate(prefab);
            AddGameObject(go);
            
            return go.GetComponent<CarView>();
        }

    }
}