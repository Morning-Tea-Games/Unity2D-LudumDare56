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
        private readonly IReadOnlyList<GameObject> _rightBranchesPrefabs;
        private readonly IReadOnlyList<GameObject> _leftBranchesPrefabs;
        private Trunk _trunkPrefab;

        // Current state
        private float _currentHeight = -TRUNK_HEIGHT;
        private bool _flipped;

        public LevelGeneratorService(
            List<GameObject> leftBranchesPrefabs,
            List<GameObject> rightBranchesPrefabs,
            Trunk trunkPrefab
        )
        {
            _leftBranchesPrefabs = leftBranchesPrefabs;
            _rightBranchesPrefabs = rightBranchesPrefabs;
            _trunkPrefab = trunkPrefab;
        }

        public void RiseTreeHigher()
        {
            _currentHeight += TRUNK_HEIGHT;
        }

        public GameObject GenerateTree()
        {
            _flipped = !_flipped;
            var trunk = GameObject.Instantiate(
                _trunkPrefab,
                new Vector3(TRUNK_OFFSET_X, _currentHeight, 0f),
                Quaternion.identity
            );

            trunk.SpriteRenderer.flipY = _flipped;
            GenerateBranch(trunk).transform.SetParent(trunk.transform);
            return trunk.gameObject;
        }

        public GameObject GenerateBranch(Trunk trunk)
        {
            var isRight = Random.Range(0, 2) == 0;

            // TODO: Пофиксить дубляж кода
            if (isRight)
            {
                var index = Random.Range(1, _rightBranchesPrefabs.Count) - 1;
                var positionIndex = Random.Range(0, trunk.RightBranchesStarts.Count);
                var targetPosition = trunk.RightBranchesStarts[positionIndex].transform.position;
                var branch = GameObject.Instantiate(
                    _rightBranchesPrefabs[index],
                    targetPosition,
                    Quaternion.identity
                );

                return branch;
            }
            else
            {
                var index = Random.Range(1, _leftBranchesPrefabs.Count) - 1;
                var positionIndex = Random.Range(0, trunk.LeftBranchesStarts.Count);
                var targetPosition = trunk.LeftBranchesStarts[positionIndex].transform.position;
                var branch = GameObject.Instantiate(
                    _leftBranchesPrefabs[index],
                    targetPosition,
                    Quaternion.identity
                );

                return branch;
            }
        }
    }
}
