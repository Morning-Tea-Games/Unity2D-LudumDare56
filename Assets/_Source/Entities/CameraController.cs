using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        var targetPosition = target.position;
        var distance = Vector3.Distance(transform.position, targetPosition);
        var scaleFactor = Mathf.Clamp01(1 / (distance + 1));
        var mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position =
            targetPosition + (mouseWorldPosition - transform.position) * scaleFactor;
    }
}
