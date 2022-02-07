using Racing.Tools;
using Racing.Transport;

namespace Racing.Game
{
    internal class GameInformation
    {
        public SubscriptionProperty<GameState> CurrentGameState;
        public TransprortModel TransprortModel;
        public TransportType TransportType;

        public GameInformation(GameState currentGameState, float transportSpeed, TransportType transportType)
        {
            CurrentGameState = new SubscriptionProperty<GameState>();
            CurrentGameState.Value = currentGameState;
            TransportType = transportType;
            TransprortModel = new TransprortModel(transportSpeed);
        }
    }
}