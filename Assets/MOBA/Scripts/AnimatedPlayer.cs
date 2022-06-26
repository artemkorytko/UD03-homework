using UnityEngine;

namespace Moba
{
    public class AnimatedPlayer : MobilePlayer
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