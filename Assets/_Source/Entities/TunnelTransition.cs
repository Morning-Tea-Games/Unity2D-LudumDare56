using System.Collections;
using DG.Tweening;
using GameData;
using Services;
using UnityEngine;

namespace Entities
{
    public class TunnelTransition : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _playerLayer;

        [SerializeField]
        private Transform _destination;

        [SerializeField]
        private TunnelTransition _nextTunnel;

        [SerializeField]
        private Player _player;

        [SerializeField]
        private Transform _myBranch;

        [SerializeField]
        private string _noTransitionMessage;

        private bool _canTeleport;
        private static bool _isTeleporting;

        private InputService _input;
        private DialogueService _dialogue;

        private void Start()
        {
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
            _dialogue = ServiceController_Game.ServiceLocator.GetService<DialogueService>();
            _input.OnActivate += Activate;
        }

        private void OnDestroy()
        {
            _input.OnActivate -= Activate;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((_playerLayer & 1 << other.gameObject.layer) != 0)
            {
                _canTeleport = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((_playerLayer & 1 << other.gameObject.layer) != 0)
            {
                _canTeleport = false;
            }
        }

        private void Activate()
        {
            if (!_canTeleport || _isTeleporting)
                return;

            if (LeafOff("Leaf", _myBranch))
            {
                _dialogue.Display(_noTransitionMessage, 0.5f, 1f);
                return;
            }

            Debug.Log("Invoke animation");
            StartCoroutine(AnimateRoutine());
        }

        private IEnumerator AnimateRoutine()
        {
            Debug.Log("Starting animation");
            _isTeleporting = true;

            Debug.Log("Disabling player control");
            // Отключаем возможность что-либо делать
            _input.Enabled = false;
            _player.Rigidbody2D.velocity = Vector2.zero;
            _player.Rigidbody2D.bodyType = RigidbodyType2D.Static;

            Debug.Log("First moving player");
            // Перемешение в первый тунель
            _player
                .transform.DOMove(transform.position, 1f)
                .OnUpdate(
                    () =>
                        Debug.Log(
                            $"Velocity: {_player.Rigidbody2D.velocity} | TargetX: {transform.position.x} | PlayerX: {_player.transform.position.x} | ComplitedPercent: {_player.transform.position.x / transform.position.x * 100f}%"
                        )
                );
            yield return new WaitForSeconds(1f);

            Debug.Log("Player fade out");
            Debug.Log("Velocity: " + _player.Rigidbody2D.velocity);
            // Затухание
            _player.SpriteRenderer.DOFade(0f, 1f);
            yield return new WaitForSeconds(1f);

            Debug.Log("Teleporting");
            // Телепортация во второй тунель
            _player.transform.position = _nextTunnel.transform.position;
            yield return new WaitForSeconds(2f); // Пока камера доедет

            Debug.Log("Player fade in");
            // Появление
            _player.SpriteRenderer.DOFade(1f, 1f);
            yield return new WaitForSeconds(1f);

            Debug.Log("Second moving player");
            // Выход из тунеля
            _player.transform.DOMove(_destination.position, 1f);
            yield return new WaitForSeconds(1f);

            Debug.Log("Enable player control");
            // Возвращаем возможность взаимодействовать
            _player.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _input.Enabled = true;

            _isTeleporting = false;
            Debug.Log("Done");
        }

        /// <summary>
        /// Проверяет, есть ли у указанного трансформа дочерние объекты с заданным тегом.
        /// </summary>
        /// <param name="tag">Тег для поиска.</param>
        /// <param name="transformToCheck">Трансформ, в дочерних объектах которого будет происходить поиск.</param>
        /// <returns>True, если найден хотя бы один объект с заданным тегом; иначе false.</returns>
        private bool LeafOff(string tag, Transform transformToCheck)
        {
            // Проверяем все дочерние объекты
            foreach (Transform child in transformToCheck)
            {
                // Если найден объект с заданным тегом, возвращаем true
                if (child.CompareTag(tag))
                {
                    return true;
                }
            }

            // Если ничего не найдено, возвращаем false
            return false;
        }
    }
}
