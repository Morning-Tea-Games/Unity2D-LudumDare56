using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public class GroundCheckService : MonoBehaviour, IService
    {
        [SerializeField]
        private bool _drawGizmos;

        [SerializeField]
        private Collider2D _collider;

        [SerializeField]
        private LayerMask _groundLayer;

        [SerializeField]
        private float _overlapCircleRadius;

        private Vector2 _overlapCirclePosition;

        public bool IsGrounded()
        {
            _overlapCirclePosition = new Vector2(
                transform.position.x,
                transform.position.y - _collider.bounds.extents.y
            );
            var colliders = Physics2D.OverlapCircleAll(
                _overlapCirclePosition,
                _overlapCircleRadius,
                _groundLayer
            );

            foreach (var collider in colliders)
            {
                if ((_groundLayer & 1 << collider.gameObject.layer) != 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void OnDrawGizmos()
        {
            if (!_drawGizmos)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_overlapCirclePosition, _overlapCircleRadius);
        }
    }
}
