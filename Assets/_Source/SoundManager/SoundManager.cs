using UnityEngine;
using UnityEngine.UI;

namespace SoundManager
{
    public class SoundManager : MonoBehaviour
    {
        public Slider Slider;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = DontDestroyMusic.Instance.GetComponent<AudioSource>();
            Slider.value = _audioSource.volume;
        }

        public void SetVolume()
        {
            _audioSource.volume = Slider.value;
        }
    }
}
