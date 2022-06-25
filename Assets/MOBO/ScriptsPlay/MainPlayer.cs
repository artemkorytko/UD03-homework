using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public class MainPlayer : AnimatePlayer
    {
        private Rigidbody _rigidbody;
        private Joystick _joystick;

        private bool _isRun;

        protected override void Awake()
        {
            base.Awake();
            _joystick = FindObjectOfType<Joystick>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            SetActive(true);
        }

        protected override void Move()
        {
            if (_joystick.Direction != Vector2.zero)
            {
                
                _rigidbody.MovePosition(_rigidbody.position + transform.forward * moveSpeed * Time.deltaTime);
            }
        }

        protected sealed override void Rotate()
        {
            Vector3 direction = new Vector3(_joystick.Direction.x, y: 0, z: _joystick.Direction.y);
            _rigidbody.MoveRotation(Quaternion.Lerp(_rigidbody.rotation, Quaternion.LookRotation(direction), rotateSpeed* Time.deltaTime));
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
        }
    }
}