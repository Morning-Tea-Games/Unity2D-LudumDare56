using System;
using GameData;
using Services;
using UnityEngine;

namespace Entities
{
    public class RottenLeaf : MonoBehaviour
    {
        [SerializeField]
        private bool _drawGizmos;

        [SerializeField]
        private int _jumps;

        [SerializeField]
        private HingeJoint2D _hingeJoint2D;

        [SerializeField]
        private float _activeRadius;

        private InputService _input;
        private PlayerTransformService _playerTransform;
        private SoundsControlService _soundsControl;
        private bool _isFalling;

        private void Start()
        {
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
            _soundsControl =
                ServiceController_Game.ServiceLocator.GetService<SoundsControlService>();
            _playerTransform =
                ServiceController_Game.ServiceLocator.GetService<PlayerTransformService>();
            DestroyWhenUsedAllJumps();
            _input.OnJump += OnJump;
        }

        private void OnDestroy()
        {
            _input.OnJump -= OnJump;
        }

        private void OnJump()
        {
            var playerTransform = _playerTransform.GetPlayerTransform();
            var distance = Vector3.Distance(transform.position, playerTransform.position);

            if (distance < _activeRadius && playerTransform.position.y >= transform.position.y)
            {
                _jumps--;
            }

            DestroyWhenUsedAllJumps();
        }

        private void DestroyWhenUsedAllJumps()
        {
            if (_jumps <= 0)
            {
                Destroy(_hingeJoint2D, 1f);
                Invoke("OnFall", 1f);
            }
        }

        private void OnDrawGizmos()
        {
            if (!_drawGizmos)
            {
                return;
            }

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _activeRadius);
        }

        private void OnFall()
        {
            if (_isFalling)
            {
                return;
            }

            _isFalling = true;
            _soundsControl.PlaySound("RippedLeaf");
            gameObject.tag = "DoneLeaf";
        }
    }
}
