using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace MOBA
{
    public class MainPlayer : AnimatedPlayer
    {
        private Rigidbody _rigidbody;
        private Joystick _joystick;

        private bool _isRun;
        //private bool _isAtack;
        protected override void Awake()
        {
            base.Awake();
            _joystick = FindObjectOfType<Joystick>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Start()
        {
            SetActive(true);
        }
        

        protected override void Move()
        {
            if (_joystick.Direction != Vector2.zero)
            {
                _rigidbody.MovePosition(_rigidbody.position + transform.forward * (moveSpeed * Time.deltaTime));
            }
        }

        protected override void Rotate()
        {
            if (_joystick.Direction != Vector2.zero)
            {
                Vector3 direction = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
                _rigidbody.MoveRotation(Quaternion.Lerp(_rigidbody.rotation, Quaternion.LookRotation(direction), rotateSpeed*Time.deltaTime)); 
            }
            
        }

        protected override void PlayAnimation()
        {
            if (!_isRun && _joystick.Direction != Vector2.zero)
            {
                _animator.SetTrigger("Run");
                _isRun = true;
                

            }

            if (_isRun && _joystick.Direction == Vector2.zero)
            {
                _animator.SetTrigger("Idle");
                _isRun = false;
                
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _animator.SetTrigger("Atack");
                
            }
        }
    }
}

