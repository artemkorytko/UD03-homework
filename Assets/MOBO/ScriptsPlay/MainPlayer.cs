using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public class MainPlayer : AnimatePlayer
    {
        private Rigidbody _rigidbody; // присваиваем значение для тела , надо для того что бы его можно было задействовать
        private Joystick _joystick;  // присваиваем значение     


        private bool _isRun;

        protected override void Awake()
        {
            base.Awake();
            _joystick = FindObjectOfType<Joystick>(); // джойстик равно найти дждойстик на сцене
            _rigidbody = GetComponent<Rigidbody>(); // берем компонент тело 
        }

        private void Start()
        {
            SetActive(true);
        }

        protected override void Move() // расказываем что ты умеем в передвижении
        {
            if (_joystick.Direction != Vector2.zero) // если джойстик не равен вектор зеро
            {
                _rigidbody.MovePosition(_rigidbody.position + transform.forward * moveSpeed * Time.deltaTime); // то двигаемся прямо
            }
        }

        protected override void Rotate() //расказываем что умеем поварачиваться 
        {
            if (_joystick.Direction != Vector2.zero) // если направление джойстика не равно 0
            {
                Vector3 direction = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
                _rigidbody.MoveRotation(Quaternion.Lerp(_rigidbody.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime));
            }
        }

        protected override void PlayAnimation() // добовляем в метод играть анимацию 
        {
            if (!_isRun && _joystick.Direction != Vector2.zero) // если мы не бежим и джойстик не равен 0
            {
                _animator.SetTrigger("Run"); // то амиматор передат тригед бежать 
                _isRun = true;
            }

            if (_isRun && _joystick.Direction == Vector2.zero) // если мы бежим и джойстик у нас равен 0 
            {
                _animator.SetTrigger("Idle"); // то аниматор передает стоять 
                _isRun = false;
            }
        }
    }
}