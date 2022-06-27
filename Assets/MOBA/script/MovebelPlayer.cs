using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Moba
{
    public class MovebelPlayer : BasePlayer
    {
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float rotateSpeed;
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
