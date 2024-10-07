using System.Collections;
using DG.Tweening;
using GameData;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace Entities
{
    public class ClickableUnit : MonoBehaviour
    {
        [SerializeField]
        private int _containsClick;

        [SerializeField]
        private Image _screenFade;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private string _soundName;

        private InputService _input;
        private SoundsControlService _soundsControl;

        private void OnValidate()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Awake()
        {
            _screenFade.DOFade(0f, 0f);
        }

        private void Start()
        {
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
            _soundsControl =
                ServiceController_Game.ServiceLocator.GetService<SoundsControlService>();
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

            _containsClick--;

            if (_containsClick <= 0)
            {
                StartCoroutine(AnimateRoutine());
            }
        }

        private bool IsMouseOver()
        {
            RaycastHit2D hit = Physics2D.Raycast(_input.GlobalMousePosition, Vector2.zero);
            return hit.collider != null && hit.collider.gameObject == gameObject;
        }

        private IEnumerator AnimateRoutine()
        {
            _input.Enabled = false;
            _screenFade.DOFade(1f, 1f);
            yield return new WaitForSeconds(1f);
            Destroy(_spriteRenderer);
            _soundsControl.PlaySound(_soundName);
            yield return new WaitForSeconds(1f);
            _screenFade.DOFade(0f, 1f);
            yield return new WaitForSeconds(1f);
            _input.Enabled = true;
            Destroy(gameObject);
        }
    }
}
