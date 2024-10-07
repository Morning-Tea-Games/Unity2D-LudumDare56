using UnityEngine;

namespace Controllers
{
    [System.Serializable]
    public class Sound
    {
        [field: SerializeField]
        public string Key { get; private set; }

        [field: SerializeField]
        public AudioSource Source { get; private set; }
    }
}
