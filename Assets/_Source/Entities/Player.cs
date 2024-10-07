using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public float JumpForce { get; private set; }

        [field: SerializeField]
        public SpriteRenderer SpriteRenderer { get; private set; }

        [field: SerializeField]
        public Rigidbody2D Rigidbody2D { get; private set; }

        private void OnValidate()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
