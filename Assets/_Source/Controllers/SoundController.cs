using System.Collections.Generic;
using GameData;
using Services;
using UnityEngine;

namespace Controllers
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField]
        private List<Sound> _sounds;

        private SoundsControlService _soundsControl;

        private void Start()
        {
            _soundsControl =
                ServiceController_Game.ServiceLocator.GetService<SoundsControlService>();

            foreach (var sound in _sounds)
            {
                _soundsControl.Register(sound.Key, sound.Source);
            }
        }
    }
}
