using System;
using UnityEngine;

namespace Racing
{
    internal class DontDestroyOnLoadObject : MonoBehaviour
    {
        private void Awake()
        {
            if (enabled)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}