using UnityEngine;

namespace Entities
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public float JumpForce { get; private set; }
    }
}
