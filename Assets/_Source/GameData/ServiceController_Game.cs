using Entities;
using ServiceLocatorSystem;
using Services;
using UnityEngine;

namespace GameData
{
    public class ServiceController_Game : MonoBehaviour
    {
        public static ServiceLocator ServiceLocator;

        [SerializeField]
        private Player _player;

        [SerializeField]
        private PlayerMovementService _movement;

        [SerializeField]
        private InputService _input;

        private void Awake()
        {
            ServiceLocator = new ServiceLocator();

            // Register services
            ServiceLocator.Register(new TransformMovementService());
            ServiceLocator.Register(_input);
            ServiceLocator.Register(_movement);
        }

        private void OnDestroy()
        {
            // Unregister services
            ServiceLocator = null;
        }
    }
}
