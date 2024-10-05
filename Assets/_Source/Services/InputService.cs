using System;
using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public abstract class InputService : MonoBehaviour, IService
    {
        public Action OnJump;
        public Vector3 MoveDirection { get; protected set; }
    }
}
