using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public class RigidbodyJumpService : IService
    {
        public void Jump(Rigidbody2D rigidbody2D, float force)
        {
            rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x, 0f);
            rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
