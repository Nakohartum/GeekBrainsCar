using Racing.Game;
using Racing.UI;
using UnityEngine;

namespace Racing
{
    internal class MainController : BaseController
    {
        private readonly Transform _placeForUIELement;
        private readonly GameInformation _gameInformation;

        private MainMenuController _mainMenuController;
        private GameController _gameController;
        private SetttingsMenuController _setttingsMenuController;

        public MainController(Transform placeForUiElement, GameInformation gameInformation)
        {
            _placeForUIELement = placeForUiElement;
            _gameInformation = gameInformation;
            _gameInformation.CurrentGameState.SubscribeOnChange(OnGameStateChange);
            OnGameStateChange(gameInformation.CurrentGameState.Value);
        }

        private void OnGameStateChange(GameState value)
        {
            DisposeAllControllers();
            switch (value)
            {
                case GameState.MainMenu:
                    _mainMenuController = new MainMenuController(_gameInformation, _placeForUIELement);
                    break;
                case GameState.Play:
                    _gameController = new GameController(_gameInformation);
                    break;
                case GameState.Options:
                    _setttingsMenuController = new SetttingsMenuController(_gameInformation, _placeForUIELement);
                    break;
                default:
                    DisposeAllControllers();
                    break;
            }
        }

        private void DisposeAllControllers()
        {
            _gameController?.Dispose();
            _mainMenuController?.Dispose();
            _setttingsMenuController?.Dispose();
        }

        protected override void OnDispose()
        {
            DisposeAllControllers();
            _gameInformation.CurrentGameState.UnSubscribeOnChange(OnGameStateChange);
        }
        
        
    }
}