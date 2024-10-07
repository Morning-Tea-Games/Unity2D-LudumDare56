using ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public enum PlayerStates
    {
        Idle = 0,
        Walk = 1,
        Jump = 2,
        Fly = 3,
        Landing = 4,
        Cut = 5,
        Paint = 6,
    }

    public class PlayerAnimationService : IService
    {
        public Animator Animator { get; private set; }

        public PlayerAnimationService(Animator animator)
        {
            Animator = animator;
        }

        public void SetState(PlayerStates state)
        {
            Animator.SetInteger("State", (int)state);
        }
    }
}
