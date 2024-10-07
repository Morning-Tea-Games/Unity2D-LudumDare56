using GameData;
using Services;
using UnityEngine;

namespace Entities
{
    public class BackgroundParallax : MonoBehaviour
    {
        [SerializeField]
        private Transform _fore;

        [SerializeField]
        private Transform _middle;

        [SerializeField]
        private Transform _back;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = ServiceController_Game
                .ServiceLocator.GetService<PlayerTransformService>()
                .GetPlayerTransform();
        }

        private void Update()
        {
            _fore.position = _playerTransform.position / 5f;
            _middle.position = _playerTransform.position / 15f;
            _back.position = _playerTransform.position / 25f;
        }
    }
}
