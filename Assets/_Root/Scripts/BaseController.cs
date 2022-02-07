using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Racing
{
    internal class BaseController : IDisposable
    {
        private List<BaseController> _baseControllers;
        private List<GameObject> _gameObjects;
        private bool _isDisposed;

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;

            DisposeAllGameObject();
            DisposeAllBaseControllers();
            OnDispose();
        }

        protected virtual void OnDispose()
        {
            
        }

        private void DisposeAllBaseControllers()
        {
            if (_baseControllers == null)
            {
                return;
            }

            for (int i = 0; i < _baseControllers.Count; i++)
            {
                _baseControllers[i].Dispose();
            }
            _baseControllers.Clear();
        }

        private void DisposeAllGameObject()
        {
            if (_gameObjects == null)
            {
                return;
            }
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                Object.Destroy(_gameObjects[i]);
            }
            _gameObjects.Clear();
        }
        
        
        protected void AddController(BaseController baseController)
        {
            _baseControllers ??= new List<BaseController>();
            _baseControllers.Add(baseController);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            _gameObjects ??= new List<GameObject>();
            _gameObjects.Add(gameObject);
        }
    }
}