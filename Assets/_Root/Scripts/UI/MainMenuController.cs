using Racing.Game;
using Racing.Tools;
using UnityEngine;

namespace Racing.UI
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly GameInformation _gameInformation;
        private readonly MainMenuView _mainMenuView;

        public MainMenuController(GameInformation gameInformation, Transform placeForUIElements)
        {
            _gameInformation = gameInformation;
            _mainMenuView = LoadView(placeForUIElements);
            _mainMenuView.Init(StartGame, OpenOptions, Other);
        }

        private void Other()
        {
            
        }

        private void OpenOptions()
        {
            _gameInformation.CurrentGameState.Value = GameState.Options;
        }

        private void StartGame()
        {
            _gameInformation.CurrentGameState.Value = GameState.Play;
        }

        private MainMenuView LoadView(Transform placeForUIElements)
        {
            var prefab = ResourceLoader.LoadPrefab(_resourcePath);
            var view = Object.Instantiate(prefab, placeForUIElements, false);
            AddGameObject(view);
            return view.GetComponent<MainMenuView>();
        }
    }
}