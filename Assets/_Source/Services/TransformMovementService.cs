using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public class TransformMovementService : IService
    {
        public void Move(Transform transform, Vector3 direction, float speed, float delta)
        {
            transform.position += direction * speed * delta;
        }
    }
}
