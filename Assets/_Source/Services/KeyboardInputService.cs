using GameData;
using UnityEngine;

namespace Services
{
    public class KeyboardInputService : InputService
    {
        private GroundCheckService _groundCheck;

        private void Start()
        {
            _groundCheck = ServiceController_Game.ServiceLocator.GetService<GroundCheckService>();
        }

        private void Update()
        {
            ReadMovement();
            ReadJump();
        }

        private void ReadMovement()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var direction = new Vector3(horizontal, 0f);

            MoveDirection = direction;
        }

        private void ReadJump()
        {
            if (Input.GetButtonDown("Jump") && _groundCheck.IsGrounded())
            {
                OnJump.Invoke();
            }
        }
    }
}
