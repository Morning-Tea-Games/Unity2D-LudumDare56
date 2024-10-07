using UnityEngine;
using UnityEngine.UI;

namespace SoundManager
{
    public class SoundManager : MonoBehaviour
    {
        public Slider Slider;
        public Slider SoundSlider;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = DontDestroyMusic.Instance.GetComponent<AudioSource>();
            Slider.value = _audioSource.volume;
            // SoundSlider.value = DontDestroyMusic.Instance.SoundVolume;
        }

        public void SetVolume()
        {
            _audioSource.volume = Slider.value;
        }

        public void SetSoundVolume()
        {
            DontDestroyMusic.Instance.SoundVolume = SoundSlider.value;
        }
    }
}
