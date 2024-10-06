using GameData;
using Services;
using UnityEngine;

namespace Controllers
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private InputService _input;
        private GroundCheckService _groundCheck;
        private PlayerAnimationService _playerAnimation;

        private void Start()
        {
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
            _groundCheck = ServiceController_Game.ServiceLocator.GetService<GroundCheckService>();
            _playerAnimation =
                ServiceController_Game.ServiceLocator.GetService<PlayerAnimationService>();
            _input.OnJump += OnJump;
        }

        private void OnDestroy()
        {
            _input.OnJump -= OnJump;
        }

        private void Update()
        {
            if (!_groundCheck.IsGrounded())
            {
                _playerAnimation.SetState(PlayerStates.Fly);
                return;
            }
            var currentAnimation = _playerAnimation.Animator.GetCurrentAnimatorStateInfo(0);

            if (currentAnimation.IsName("Cut") || currentAnimation.IsName("Paint"))
                return;

            if (_input.MoveDirection.x > 0f)
            {
                _spriteRenderer.flipX = false;
                _playerAnimation.SetState(PlayerStates.Walk);
            }
            else if (_input.MoveDirection.x < 0f)
            {
                _spriteRenderer.flipX = true;
                _playerAnimation.SetState(PlayerStates.Walk);
            }
            else
            {
                _playerAnimation.SetState(PlayerStates.Idle);
            }
        }

        private void OnJump()
        {
            _playerAnimation.SetState(PlayerStates.Jump);
        }
    }
}
