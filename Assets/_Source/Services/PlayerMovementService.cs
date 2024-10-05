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
        private InputService _input;

        private void Start()
        {
            _movement =
                ServiceController_Game.ServiceLocator.GetService<TransformMovementService>();
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
        }

        private void FixedUpdate()
        {
            var direction = _input.MoveDirection;
            _movement.Move(_player.transform, direction, _player.Speed, Time.fixedDeltaTime);
        }
    }
}
