using UnityEngine;

namespace Services
{
    public class KeyboardInputService : InputService
    {
        private void Update()
        {
            ReadMovement();
        }

        private void ReadMovement()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var direction = new Vector3(horizontal, 0f);

            MoveDirection = direction;
        }
    }
}
