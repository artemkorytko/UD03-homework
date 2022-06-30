using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public enum PlayerType    // создание типа игрока, енам - именнованое цифровое значение

    {
        None = -1,
        MainPlayer,
        EnemyPlayer,
        Bot,
        transform,
        position
    }

    public abstract class BasePlayer : MonoBehaviour
    {
        [SerializeField] public PlayerType _type; // переменная  типа игрока .. можем указывать из редактора
        [SerializeField] private int _maxHealth; // перемнная максимального знвчения здоровья 
        [SerializeField] private bool _isActiveInUpdate; // 
        private int _currentHealth; // переменная текущее ззначение здоровья
        private bool _isActive; // переменная говорит активны ли мы

        protected abstract void BeActive(); //  метод говорит что мы активны
        public bool IsAlive => _currentHealth > 0; // переменная которая говорит, что игрок жив если текущее значение здоровья больше 0

        protected virtual void Awake() //  метод 
        {
            _currentHealth = _maxHealth; //  текущее значение здоровья равно максимальному значению здоровья
        }

        private void Update() // метод который отрабатывает каждый кадр 
        {
            if (!_isActiveInUpdate) //  есне активен в апдате
                return; // то возвращаемся 
            if (!_isActive)//  если мы не активны 
            {
                return; //  то не чего не происходит
            }

            BeActive(); //  в противном случае мы активны
        }

        private void FixedUpdate()
        {
            if (_isActiveInUpdate)
                return;
            if (!_isActive)
                return;
            BeActive();
        }

        

        public void SetActive(bool isActive) //  метод который сделает нас активными
        {
            _isActive = isActive; // ??
        }

        public virtual void GetDamage (int value) // метод в котором гооврится сколько урона мы наносим
        {
            _currentHealth -= value; // текущее значение здоровья минус значение урона (-= отнять и присвоить)
            if (!IsAlive) //  если мы не живы 
            {
                OnDeath();//  мы умираем
            }
        }

        protected virtual void OnDeath()  //
        {
            _isActive = false; // выключаем активность
            gameObject.SetActive(false); // отключаем себя когда проусхоит смерть
        }
       
    }
}