using System;
using UnityEngine;

namespace Moba
{
    public class PatrollingMob : Mob
    {
        [SerializeField] private Transform[] _movingPoints;
        
        private int _currentPoint;
        private Vector3 _pointVector;

        protected override void Start()
        {
            _currentPoint = 0;
            SetPointVector();
            base.Start();
        }

        protected override void Move()
        {
            AtPoint();
            if (!IsHaveTarget()) MovePosition();
            base.Move();
        }

        protected override void Rotate()
        {
            if (!IsHaveTarget()) MoveRotation(_pointVector);
            base.Rotate();
        }

        protected override void PlayAnimation()
        {
            if (!IsReadyToAttack()) _animator.SetTrigger("Walk");
            if (IsHaveTarget() & IsReadyToAttack()) _animator.SetTrigger("Attack");
        }

        private void AtPoint()
        {
            if (Vector3.Distance(_rigidbody.position, _movingPoints[_currentPoint].position)<=1f)
            {
                _currentPoint++;
                
                if (_currentPoint>=_movingPoints.Length)
                {
                    _currentPoint %= _movingPoints.Length;
                }
                SetPointVector();
            }
        }

        private void SetPointVector()
        {
            _pointVector = _movingPoints[_currentPoint].position - _rigidbody.position;
        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            SetPointVector();
        }
        
    }
}