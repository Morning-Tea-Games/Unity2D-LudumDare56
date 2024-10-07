using System;
using UnityEngine;

namespace SceneManagement
{
    public class SceneManager : MonoBehaviour
    {
        public void SwitchScene(string sceneName) =>
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
