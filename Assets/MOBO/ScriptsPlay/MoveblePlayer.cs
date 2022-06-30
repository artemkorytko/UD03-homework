using UnityEngine;

namespace MOBA
{
    public class MoveblePlayer : BasePlayer
    {
        [SerializeField] protected float moveSpeed; // переменная в которой мы ставим скорость передвижения 
        [SerializeField] protected float rotateSpeed; // переменнная в которой мы ставим скорость поворота
        
        protected override void BeActive() // в методе быть активным 
        {
            Rotate();// передали метод
            Move();// передали метод
        }

        protected virtual void Move() // метод движения 
        {
            
        }
        
        protected virtual void Rotate() // метод вращения
        {
            
        }
    }
}