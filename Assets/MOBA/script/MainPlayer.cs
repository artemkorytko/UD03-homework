using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moba
{
    public class MainPlayer : AnimatedPlayer
    {
        private Rigidbody _rigidbody;
        private Joystick _joystick;

        protected override void Aweke()
        {
            base.Aweke();
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
        protected override void Rotate()
        {
          
            Vector3 direction = new(_joystick.Direction.x, y: 0, z: _joystick.Direction.y);
            _rigidbody.MoveRotation(Quaternion.Lerp(a: _rigidbody.rotation, b: Quaternion.LookRotation(direction), t: rotateSpeed * Time.deltaTime));

        }



    }


}