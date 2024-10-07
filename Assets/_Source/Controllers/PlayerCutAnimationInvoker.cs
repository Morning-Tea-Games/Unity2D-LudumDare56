using GameData;
using Services;
using UnityEngine;

namespace Controllers
{
    public class PlayerCutAnimationInvoker : MonoBehaviour
    {
        private PlayerAnimationService _playerAnimation;
        private SoundsControlService _soundsControl;

        private void Start()
        {
            _playerAnimation =
                ServiceController_Game.ServiceLocator.GetService<PlayerAnimationService>();
            _soundsControl =
                ServiceController_Game.ServiceLocator.GetService<SoundsControlService>();
        }

        private void OnJointBreak2D(Joint2D brokenJoint)
        {
            Debug.Log("Cut");
            _playerAnimation.SetState(PlayerStates.Cut); // TODO: не работает
            _soundsControl.PlaySound("CutLeaf");
            gameObject.tag = "DoneLeaf";
            Destroy(brokenJoint);
        }
    }
}
