using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMenegment
{
    public class SceneMeneger : MonoBehaviour
    {
        public void SwitchScene(string sceneName) => SceneManager.LoadScene(sceneName);
    }
}
