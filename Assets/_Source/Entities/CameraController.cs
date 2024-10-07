using GameData;
using Services;
using UnityEngine;

namespace Entities
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        Transform _target;

        [SerializeField]
        private float _smoothTime;

        [SerializeField]
        private float _sizeFactor;

        private InputService _input;
        private Camera _camera;

        private void Start()
        {
            _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            var targetPosition = _target.position;
            var distance = Vector3.Distance(transform.position, targetPosition);
            var scaleFactor = Mathf.Clamp01(1f / (distance + 1f));
            var desiredPosition =
                targetPosition + (_input.GlobalMousePosition - transform.position) * scaleFactor;

            transform.position +=
                _smoothTime * (desiredPosition - transform.position) / 100f * Time.deltaTime;

            _camera.orthographicSize +=
                _smoothTime
                * (
                    Mathf.Clamp(
                        _sizeFactor / 2f
                            + Vector3.Distance(transform.position, _input.GlobalMousePosition)
                                / 100f
                                * _sizeFactor,
                        5f,
                        10f
                    ) - _camera.orthographicSize
                )
                / 50f
                * Time.deltaTime;
        }
    }
}
