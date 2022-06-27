using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Moba
{ 
public class AnimatedPlayer : MovebelPlayer
    {
        private Animator _animator;

        protected override void Aweke()
        {
            base.Aweke();
            _animator = GetComponentInChildren<Animator>();
        }




        protected override void BeActive()
        {
            base.BeActive();
            
        }
        protected virtual void PlayAnimation()
        {

        }
    }

}
