using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    [SerializeField]
    private float _minY = -30f;

    private void Update()
    {
        if (transform.position.y <= _minY)
        {
            Destroy(gameObject);
        }
    }
}
