using System;
using UnityEngine;

namespace Moba
{
    public class MovablePlayer : BasePlayer
    {
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float rotationSpeed;


        protected override void BeActive()
        {
            Rotate();
            Move();
        }

        protected virtual void Move()
        {
            
        }

        protected virtual void Rotate()
        {
            
        }
        
    }
}