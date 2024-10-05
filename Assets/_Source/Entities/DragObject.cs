using GameData;
using Services;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DragObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Camera mainCamera;

    private Vector2 offset;
    private bool isDragging = false;

    private InputService _input;

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        mainCamera = Camera.main;
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
        if (isDragging)
        {
            _rigidbody.MovePosition(_input.GlobalMousePosition + (Vector3)offset);
        }
    }

    private void OnMouseDown()
    {
        if (IsMouseOver())
        {
            isDragging = true;
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            offset = (Vector2)transform.position - mousePosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private bool IsMouseOver()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        return hit.collider != null && hit.collider.gameObject == gameObject;
    }
}
