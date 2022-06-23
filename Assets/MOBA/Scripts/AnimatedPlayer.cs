using UnityEngine;

namespace MOBA
{
    public class AnimatedPlayer : MoveblePlayer
    {
        protected Animator _animator;

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponentInChildren<Animator>();
        }

        protected override void BeActive()
        {
            base.BeActive();
            PlayAnimation();
        }

        protected virtual void PlayAnimation()
        {
            
        }
    }
}