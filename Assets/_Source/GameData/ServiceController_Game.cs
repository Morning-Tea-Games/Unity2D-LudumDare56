using ServiceLocatorSystem;
using Services;
using UnityEngine;

namespace GameData
{
    public class ServiceController_Game : MonoBehaviour
    {
        public static ServiceLocator ServiceLocator;

        [SerializeField]
        private PlayerMovementService _movement;

        [SerializeField]
        private GroundCheckService _groundCheck;

        [SerializeField]
        private InputService _input;

        private void Awake()
        {
            ServiceLocator = new ServiceLocator();

            // Register services
            ServiceLocator.Register(new TransformMovementService());
            ServiceLocator.Register(new RigidbodyJumpService());
            ServiceLocator.Register(_input);
            ServiceLocator.Register(_movement);
            ServiceLocator.Register(_groundCheck);
        }

        private void OnDestroy()
        {
            // Unregister services
            ServiceLocator = null;
        }
    }
}
