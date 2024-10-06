using UnityEngine;

namespace SoundManager
{
    public class DontDestroyMusic : MonoBehaviour
    {
        public static DontDestroyMusic Instance { get; private set; }

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
