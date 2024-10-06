using GameData;
using Services;
using UnityEngine;

namespace Controllers
{
    public class PlayerCutAnimationInvoker : MonoBehaviour
    {
        private PlayerAnimationService _playerAnimation;

        private void Start()
        {
            _playerAnimation =
                ServiceController_Game.ServiceLocator.GetService<PlayerAnimationService>();
        }

        private void OnJointBreak2D(Joint2D brokenJoint)
        {
            Debug.Log("Cut");
            _playerAnimation.SetState(PlayerStates.Cut); // TODO: не работает
            Destroy(brokenJoint);
        }
    }
}
