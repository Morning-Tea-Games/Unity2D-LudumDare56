using System.Collections.Generic;
using ServiceLocatorSystem;
using SoundManager;
using UnityEngine;

namespace Services
{
    public class SoundsControlService : IService
    {
        private readonly Dictionary<string, AudioSource> _audioSources =
            new Dictionary<string, AudioSource>();

        public void Register(string key, AudioSource audioSource)
        {
            _audioSources.Add(key, audioSource);
        }

        public void Unregister(string key)
        {
            _audioSources.Remove(key);
        }

        public AudioSource PlaySound(string key)
        {
            var current = _audioSources[key];
            //current.volume = DontDestroyMusic.Instance.SoundVolume;
            current.Play();
            return current;
        }
    }
}
