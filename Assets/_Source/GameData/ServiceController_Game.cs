using System.Collections.Generic;
using Entities;
using ServiceLocatorSystem;
using Services;
using UnityEngine;

namespace GameData
{
    public class ServiceController_Game : MonoBehaviour
    {
        public const string ENVIRONMENT_GROUP_NAME = "---Environment---";

        public static ServiceLocator ServiceLocator;

        [SerializeField]
        private Transform _playerTransform;

        [SerializeField]
        private Animator _playerAnimator;

        [SerializeField]
        private PlayerMovementService _movement;

        [SerializeField]
        private GroundCheckService _groundCheck;

        [SerializeField]
        private InputService _input;

        [SerializeField]
        private DialogueService _dialogue;

        [SerializeField]
        private List<GameObject> _rightBranchesPrefabs;

        [SerializeField]
        private List<GameObject> _leftBranchesPrefabs;

        [SerializeField]
        private List<Transform> _groups;

        [SerializeField]
        private Trunk _trunkPrefab;

        private void Awake()
        {
            ServiceLocator = new ServiceLocator();

            // Register services
            ServiceLocator.Register(new TransformMovementService());
            ServiceLocator.Register(new RigidbodyJumpService());
            ServiceLocator.Register(new GroupHierarchyService(_groups));
            ServiceLocator.Register(new PlayerTransformService(_playerTransform));
            ServiceLocator.Register(new PlayerAnimationService(_playerAnimator));
            ServiceLocator.Register(_input);
            ServiceLocator.Register(_movement);
            ServiceLocator.Register(_groundCheck);
            ServiceLocator.Register(_dialogue);
            ServiceLocator.Register(new SoundsControlService());
            // ServiceLocator.Register(
            //     new LevelGeneratorService(_leftBranchesPrefabs, _rightBranchesPrefabs, _trunkPrefab)
            // );
        }

        // Map Generation (unused)
        // private void Start()
        // {
        //     var levelGenerator = ServiceLocator.GetService<LevelGeneratorService>();
        //     var groupHierarchy = ServiceLocator.GetService<GroupHierarchyService>();

        //     for (int i = 0; i < 50; i++)
        //     {
        //         var trunk = levelGenerator.GenerateTree();
        //         levelGenerator.RiseTreeHigher();
        //         trunk.transform.SetParent(groupHierarchy.GetGroup(ENVIRONMENT_GROUP_NAME));
        //     }
        // }

        private void OnDestroy()
        {
            // Unregister services
            ServiceLocator = null;
        }
    }
}
