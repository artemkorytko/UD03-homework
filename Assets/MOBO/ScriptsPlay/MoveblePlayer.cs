using UnityEngine;

namespace MOBA
{
    public class MoveblePlayer : BasePlayer
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