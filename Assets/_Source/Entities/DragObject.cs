using GameData;
using Services;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DragObject : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _dragForce = 5f;

        private Camera _mainCamera;

        private Vector2 _offset;
        private bool _isDragging = false;

        private InputService _input;

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
            _input.OnMouseDown += OnMouseDown;
            _input.OnMouseUp += OnMouseUp;
        }

        private void OnDestroy()
        {
            _input.OnMouseDown -= OnMouseDown;
            _input.OnMouseUp -= OnMouseUp;
        }

        private void Update()
        {
            if (_isDragging)
            {
                var target =
                    transform.position
                    + _dragForce
                        * (_input.GlobalMousePosition - transform.position)
                        / 100f
                        * Time.deltaTime;
                _rigidbody.MovePosition(target);
                _rigidbody.velocity = Vector2.zero;
            }
        }

        private void OnMouseDown()
        {
            if (IsMouseOver())
            {
                _isDragging = true;
                _offset = transform.position - _input.GlobalMousePosition;
            }
        }

        private void OnMouseUp()
        {
            _isDragging = false;
        }

        private bool IsMouseOver()
        {
            Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            return hit.collider != null && hit.collider.gameObject == gameObject;
        }
    }
}
