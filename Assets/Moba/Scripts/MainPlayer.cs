using Unity.VisualScripting;
using UnityEngine;

namespace Moba
{
    public class MainPlayer : AnimatedPlayer
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

        protected virtual void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _animator.SetTrigger("Attack");
                _isRun = false;
            }
            if(Input.GetMouseButtonUp(1))
            {
                _animator.SetTrigger("Idle");
                _isRun = false;
            }
        }

        protected override void Move()
        {
            if (_joystick.Direction != Vector2.zero)
            {
                _rigidbody.MovePosition(_rigidbody.position+transform.forward*moveSpeed*Time.deltaTime);
            }
        }

        protected sealed override void Rotate()
        {
            if (_joystick.Direction != Vector2.zero)
            {
                Vector3 direction = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
                _rigidbody.MoveRotation(Quaternion.Lerp(_rigidbody.rotation,Quaternion.LookRotation(direction),rotationSpeed*Time.deltaTime ));
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
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword2"))
            {
                GetDamage(10);
            }
        }
    }
}

