using GameData;
using Services;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    [SerializeField]
    private float _smoothTime;
    private InputService _input;

    private void Start()
    {
        _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
    }

    private void LateUpdate()
    {
        var targetPosition = _target.position;
        var distance = Vector3.Distance(transform.position, targetPosition);
        var scaleFactor = Mathf.Clamp01(1 / (distance + 1));
        var desiredPosition =
            targetPosition + (_input.GlobalMousePosition - transform.position) * scaleFactor;

        transform.position +=
            (_smoothTime * (desiredPosition - transform.position) / 100) * Time.deltaTime;
    }
}
