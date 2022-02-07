using System;
using Racing.Tools;
using Racing.Transport;

namespace Racing.Game
{
    internal class GameController : BaseController
    {
        public GameController(GameInformation gameInformation)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, gameInformation.TransprortModel);
            AddController(inputGameController);

            var transportController = CreateTransportController(gameInformation.TransportType);
            
            AddController(transportController);
        }

        private TransportController CreateTransportController(TransportType transportType)
        {
            TransportController transportController;
            switch (transportType)
            {
                case TransportType.Car:
                    transportController = new CarController();
                    break;
                case TransportType.Boat:
                    transportController = new BoatController();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Not correct type {nameof(transportType)}");
                
            }

            return transportController;
        }
    }
}