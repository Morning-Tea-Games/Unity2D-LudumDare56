using System.Collections.Generic;
using Entities;
using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public class LevelGeneratorService : IService
    {
        // Data
        public const float TRUNK_HEIGHT = 45.5625f;
        public const float TRUNK_OFFSET_X = -16f;

        // Using game objects
        private readonly IReadOnlyList<GameObject> _branchesPrefabs;
        private Trunk _trunk;

        // Current state
        private List<GameObject> _branches = new List<GameObject>();
        private float _currentHeight = -TRUNK_HEIGHT;
        private bool _flipped;

        public LevelGeneratorService(List<GameObject> branchesPrefabs, Trunk trunkPrefab)
        {
            _branchesPrefabs = branchesPrefabs;
            _trunk = trunkPrefab;
        }

        public void RiseTreeHigher()
        {
            _currentHeight += TRUNK_HEIGHT;
        }

        public GameObject GenerateTree()
        {
            _flipped = !_flipped;
            var trunk = GameObject.Instantiate(
                _trunk,
                new Vector3(TRUNK_OFFSET_X, _currentHeight, 0f),
                Quaternion.identity
            );

            trunk.Sr.flipY = _flipped;
            return trunk.gameObject;
        }

        public void GenerateBranch() { }
    }
}
