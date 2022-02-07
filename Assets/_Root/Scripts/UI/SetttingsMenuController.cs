using Racing.Game;
using Racing.Tools;
using UnityEngine;

namespace Racing.UI
{
    internal class SetttingsMenuController : BaseController
    {
        private readonly ResourcePath _path = new ResourcePath("Prefabs/Settings");
        private SettingsMenuView _settingsMenuView;
        private GameInformation _gameInformation;

        public SetttingsMenuController(GameInformation gameInformation, Transform placeForUI)
        {
            _gameInformation = gameInformation;
            _settingsMenuView = LoadView(placeForUI);
            _settingsMenuView.Init(Back);
        }

        private SettingsMenuView LoadView(Transform placeForUI)
        {
            var prefab = ResourceLoader.LoadPrefab(_path);
            var go = Object.Instantiate(prefab, placeForUI);
            AddGameObject(go);
            return go.GetComponent<SettingsMenuView>();
        }

        private void Back()
        {
            _gameInformation.CurrentGameState.Value = GameState.MainMenu;
        }
    }
}