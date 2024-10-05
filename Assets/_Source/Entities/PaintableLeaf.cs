// Этот скрипт дублирует логику DragObject.cs TODO: переписать в более удобном виде
using GameData;
using Services;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PaintableLeaf : MonoBehaviour
    {
        [SerializeField]
        private Color _defaultColor = Color.green;

        [SerializeField]
        private Color _newColor = Color.yellow;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private Camera _mainCamera;
        private InputService _input;

        private void OnValidate()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _spriteRenderer.color = _defaultColor;
            _mainCamera = Camera.main;
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
            _input.OnMouseDown += OnMouseDown;
        }

        private void OnDestroy()
        {
            _input.OnMouseDown -= OnMouseDown;
        }

        private void OnMouseDown()
        {
            if (!IsMouseOver())
            {
                return;
            }

            _spriteRenderer.color = _newColor;
        }

        private bool IsMouseOver()
        {
            Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            return hit.collider != null && hit.collider.gameObject == gameObject;
        }
    }
}
