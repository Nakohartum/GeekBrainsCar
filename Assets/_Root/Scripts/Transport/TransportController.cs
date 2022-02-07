using UnityEngine;

namespace Racing.Transport
{
    internal abstract class TransportController : BaseController
    {
        public abstract GameObject ViewGameObject { get; }
    }
}