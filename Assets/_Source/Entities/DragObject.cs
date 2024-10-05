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
                _rigidbody.MovePosition(_input.GlobalMousePosition + (Vector3)_offset);
                _rigidbody.velocity = Vector2.zero;
            }
        }

        private void OnMouseDown()
        {
            if (IsMouseOver())
            {
                _isDragging = true;
                Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                _offset = (Vector2)transform.position - mousePosition;
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
