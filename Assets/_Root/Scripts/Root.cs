using System;
using System.Collections;
using System.Collections.Generic;
using Racing.Game;
using UnityEngine;
using UnityEngine.Serialization;


namespace Racing
{
    internal class Root : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUIElements;
        [SerializeField] private GameState _initialGameState;
        [SerializeField] private float _speedForCar;
        [SerializeField] private TransportType _transportType;
        private MainController _gameController;

        private void Awake()
        {
            var gameInfo = new GameInformation(_initialGameState, _speedForCar, _transportType);
            _gameController = new MainController(_placeForUIElements, gameInfo);
        }

        private void Start()
        {
            
        }

        private void OnIAPInitialized()
        {
            
        }
        
        private void OnDestroy()
        {
            _gameController?.Dispose();
        }
    }
}