using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y <= -30f)
        {
            Destroy(gameObject);
        }
    }
}
