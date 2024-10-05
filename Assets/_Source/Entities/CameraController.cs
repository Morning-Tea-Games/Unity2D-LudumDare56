using GameData;
using Services;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;
    private InputService _input;

    private void Start()
    {
        _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
    }

    private void LateUpdate()
    {
        var targetPosition = target.position;
        var distance = Vector3.Distance(transform.position, targetPosition);
        var scaleFactor = Mathf.Clamp01(1 / (distance + 1));
        transform.position =
            targetPosition + (_input.GlobalMousePosition - transform.position) * scaleFactor;
    }
}
