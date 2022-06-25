using UnityEngine;

namespace Moba
{
    public class Mob : AnimatedPlayer
    {
        protected Rigidbody _rigidbody;
        private Vector3 _targetVector;
        private float _distanceToPlayer;
        private float _minDistanceToPlayer = 1.6f;

        protected override void Awake()
        {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected virtual void Start()
        {
            SetActive(true);
        }

        protected override void Move()
        {
            if (IsHaveTarget() & !IsReadyToAttack())
            {
                MovePosition();
            }
        }

        protected void MovePosition()
        {
            _rigidbody.MovePosition(_rigidbody.position + transform.forward * (moveSpeed * Time.deltaTime));
        }

        protected override void Rotate()
        {
            if (IsHaveTarget() & !IsReadyToAttack())
            {
                MoveRotation(_targetVector);
            }
        }

        protected void MoveRotation(Vector3 target)
        {
            _rigidbody.MoveRotation(Quaternion.Lerp(_rigidbody.rotation, Quaternion.LookRotation(target), rotateSpeed * Time.deltaTime));
        }

        protected override void PlayAnimation()
        {
            if (IsHaveTarget() & !IsReadyToAttack())
            {
                _animator.SetTrigger("Walk");
            }

            if (IsHaveTarget() & IsReadyToAttack())
            {
                _animator.SetTrigger("Attack");
            }

            if (!IsHaveTarget())
            {
                _animator.SetTrigger("Idle");
            }
        }

        protected bool IsReadyToAttack()
        {
            return _distanceToPlayer <= _minDistanceToPlayer;
        }
        
        protected bool IsHaveTarget()
        {
            return _targetVector != Vector3.zero;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Vector3 target = new Vector3(other.transform.position.x, 0, other.transform.position.z);
                _targetVector = target - _rigidbody.position;
                _distanceToPlayer = Vector3.Distance(_rigidbody.position, target);
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _targetVector = new Vector3(0, 0, 0);
            }
        }
    }
}