using System;
using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public abstract class InputService : MonoBehaviour, IService
    {
        public Action OnJump;
        public Action OnMouseDown;
        public Action OnMouseUp;
        public Action OnActivate;
        public bool Enabled { get; set; } = true;
        public Vector3 MoveDirection { get; protected set; }
        public Vector3 GlobalMousePosition { get; protected set; }
    }
}
