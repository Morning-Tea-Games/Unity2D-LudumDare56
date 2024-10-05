using Entities;
using GameData;
using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public class PlayerMovementService : MonoBehaviour, IService
    {
        [SerializeField]
        private Player _player;

        private TransformMovementService _movement;
        private RigidbodyJumpService _jump;
        private InputService _input;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = _player.GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _movement =
                ServiceController_Game.ServiceLocator.GetService<TransformMovementService>();
            _jump = ServiceController_Game.ServiceLocator.GetService<RigidbodyJumpService>();
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();

            _input.OnJump += Jump;
        }

        private void OnDestroy()
        {
            _input.OnJump -= Jump;
        }

        private void FixedUpdate()
        {
            var direction = _input.MoveDirection;
            _movement.Move(_player.transform, direction, _player.Speed, Time.fixedDeltaTime);
        }

        private void Jump()
        {
            _jump.Jump(_rigidbody2D, _player.JumpForce);
        }
    }
}
