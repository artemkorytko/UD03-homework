using System;
using UnityEngine;

namespace Moba
{
    public class Mob : AnimatedPlayer
    {
        [SerializeField] private Transform[] _patrolPoints;
        [SerializeField] private float _minDistanceToPlayer;
        
        private Rigidbody _rigidbody;
        private bool _isRun;
        private Vector3 _targetVector;
        private float _distanceToPlayer;

        protected override void Awake()
        {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            SetActive(true);
        }

        protected override void Move()
        {
            if (_targetVector != Vector3.zero & _distanceToPlayer > _minDistanceToPlayer)
            {
                _rigidbody.MovePosition(_rigidbody.position + transform.forward * (moveSpeed * Time.deltaTime));
            }
        }

        protected override void Rotate()
        {
            if (_targetVector != Vector3.zero & _distanceToPlayer > _minDistanceToPlayer)
            {
                _rigidbody.MoveRotation(Quaternion.Lerp(_rigidbody.rotation, Quaternion.LookRotation(_targetVector), rotateSpeed * Time.deltaTime));
            }
        }

        protected override void PlayAnimation()
        {
            if (_targetVector != Vector3.zero && _distanceToPlayer > _minDistanceToPlayer)
            {
                _animator.SetTrigger("Walk");
                _isRun = true;
            }

            if (_targetVector != Vector3.zero && _distanceToPlayer <= _minDistanceToPlayer)
            {
                _animator.SetTrigger("Attack");
                _isRun = false;
            }

            if (_targetVector == Vector3.zero)
            {
                _animator.SetTrigger("Idle");
            }
            
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

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _targetVector = new Vector3(0, 0, 0);
            }
        }
    }
}