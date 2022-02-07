using Racing.Tools;
using UnityEngine;

namespace Racing.Transport
{
    internal class BoatController : TransportController
    {
        private readonly ResourcePath _path = new ResourcePath("Prefabs/Boat");
        private readonly BoatView _boatView;
        public override GameObject ViewGameObject => _boatView.gameObject;

        public BoatController()
        {
            _boatView = LoadView();
        }

        private BoatView LoadView()
        {
            var prefab = ResourceLoader.LoadPrefab(_path);
            var go = Object.Instantiate(prefab);
            AddGameObject(go);
            return go.GetComponent<BoatView>();
        }
    }
}