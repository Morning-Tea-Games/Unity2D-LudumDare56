using GameData;
using UnityEngine;

namespace Services
{
    public class KeyboardInputService : InputService
    {
        private GroundCheckService _groundCheck;
        private Camera _camera;

        private void Start()
        {
            _groundCheck = ServiceController_Game.ServiceLocator.GetService<GroundCheckService>();
            _camera = Camera.main;
        }

        private void Update()
        {
            if (!Enabled)
            {
                MoveDirection = Vector3.zero;
                return;
            }

            ReadMovement();
            ReadJump();
            ReadMousePosition();
            ReadMousePress();
            ReadActivate();
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
                OnJump?.Invoke();
            }
        }

        private void ReadMousePosition()
        {
            GlobalMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        private void ReadMousePress()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseDown?.Invoke();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                OnMouseUp?.Invoke();
            }
        }

        private void ReadActivate()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnActivate?.Invoke();
            }
        }
    }
}
