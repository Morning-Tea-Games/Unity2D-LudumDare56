using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
