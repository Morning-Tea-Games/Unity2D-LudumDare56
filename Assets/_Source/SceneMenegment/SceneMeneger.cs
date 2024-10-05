using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMeneger : MonoBehaviour
{
    public void SwitchScene(string sceneName) => SceneManager.LoadScene(sceneName);
}
