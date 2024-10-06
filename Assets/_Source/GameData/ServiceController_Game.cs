using System.Collections.Generic;
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
        private Transform _playerTransform;

        [SerializeField]
        private PlayerMovementService _movement;

        [SerializeField]
        private GroundCheckService _groundCheck;

        [SerializeField]
        private InputService _input;

        [SerializeField]
        private List<GameObject> _branchesPrefabs;

        [SerializeField]
        private Trunk _trunk;

        private void Awake()
        {
            ServiceLocator = new ServiceLocator();

            // Register services
            ServiceLocator.Register(new TransformMovementService());
            ServiceLocator.Register(new RigidbodyJumpService());
            ServiceLocator.Register(new PlayerTransformService(_playerTransform));
            ServiceLocator.Register(_input);
            ServiceLocator.Register(_movement);
            ServiceLocator.Register(_groundCheck);
            ServiceLocator.Register(new LevelGeneratorService(_branchesPrefabs, _trunk));
        }

        private void Start()
        {
            var levelGenerator = ServiceLocator.GetService<LevelGeneratorService>();

            for (int i = 0; i < 50; i++)
            {
                levelGenerator.GenerateTree();
                levelGenerator.RiseTreeHigher();
            }
        }

        private void OnDestroy()
        {
            // Unregister services
            ServiceLocator = null;
        }
    }
}
