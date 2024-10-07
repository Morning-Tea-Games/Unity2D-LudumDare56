// Этот скрипт дублирует логику DragObject.cs TODO: переписать в более удобном виде
using System.Collections;
using System.Collections.Generic;
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
        private List<Sprite> _leafSprites;

        [SerializeField]
        private float _frameInterval;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private Camera _mainCamera;
        private InputService _input;
        private PlayerAnimationService _playerAnimation;
        private SoundsControlService _soundsControl;
        private bool _isPainted;

        private void OnValidate()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _spriteRenderer.color = _defaultColor;
            _mainCamera = Camera.main;
            _soundsControl =
                ServiceController_Game.ServiceLocator.GetService<SoundsControlService>();
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
            _playerAnimation =
                ServiceController_Game.ServiceLocator.GetService<PlayerAnimationService>();
            _input.OnMouseDown += OnMouseDown;
        }

        private void OnDestroy()
        {
            _input.OnMouseDown -= OnMouseDown;
        }

        private void OnMouseDown()
        {
            Debug.Log(_isPainted);
            if (!IsMouseOver() || _isPainted)
            {
                return;
            }

            _spriteRenderer.color = _newColor;
            _soundsControl.PlaySound("PaintLeaf");
            _playerAnimation.SetState(PlayerStates.Paint); // TODO: Не работает
            StartCoroutine(AnimateRoutine());
            gameObject.tag = "DoneLeaf";
            _isPainted = true;
        }

        private bool IsMouseOver()
        {
            Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            return hit.collider != null && hit.collider.gameObject == gameObject;
        }

        private IEnumerator AnimateRoutine()
        {
            foreach (var sprite in _leafSprites)
            {
                Debug.Log($"Painting {sprite.name}");
                _spriteRenderer.sprite = sprite;
                yield return new WaitForSeconds(_frameInterval);
            }
        }
    }
}
