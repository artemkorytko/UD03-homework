using UnityEngine;

namespace MOBA
{
    public class AnimatePlayer : MoveblePlayer
    {
        protected Animator _animator;// присваиваем переменную аниматору 

        protected override void Awake() // говорит что мы берем тот метод что есть у BasePlayer  и добовляем дополнительный функционал
        {
            base.Awake(); // базовое значение у BasePlayer
            _animator = GetComponentInChildren<Animator>(); // аниматор берет компонент из детища аниматора
        }


        protected override void BeActive() // метод наследован от MoveblePlayer
        {
            base.BeActive(); // базовое значение 
            PlayAnimation();// передали метод PlayAnimation
        }

        protected virtual void PlayAnimation() // метод проиграть анимацию
        {
            
        }
    }
}