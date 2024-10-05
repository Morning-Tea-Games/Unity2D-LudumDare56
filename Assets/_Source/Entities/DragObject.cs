using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;

    private Vector2 offset;
    private bool isDragging = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }

        if (isDragging)
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(mousePosition + offset);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    void OnMouseDown()
    {
        if (IsMouseOver())
        {
            isDragging = true;
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            offset = (Vector2)transform.position - mousePosition;
        }
    }

    private bool IsMouseOver()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        return hit.collider != null && hit.collider.gameObject == gameObject;
    }
}
