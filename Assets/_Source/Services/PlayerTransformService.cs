using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public class PlayerTransformService : IService
    {
        private Transform _playerTransform;

        public PlayerTransformService(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public Transform GetPlayerTransform()
        {
            return _playerTransform;
        }
    }
}
