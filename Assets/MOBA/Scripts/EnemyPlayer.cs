using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace MOBA
{
    public class EnemyPlayer : MainPlayer
    {
        private Rigidbody _rigidbodyEnemy;
        private GameObject _target;
        private bool _isAtack;
        private float _distance;
        private int _playerDamage = 20;

        
        protected override void Awake()
        {
            base.Awake();
            
            _rigidbodyEnemy = GetComponent<Rigidbody>();
            _target = GameObject.FindWithTag("GreenBase");
        }

        protected override void BeActive()
        {
            base.BeActive();
            Rotate(_target);
            _distance = Vector3.Distance(_rigidbodyEnemy.gameObject.transform.position, _target.transform.position);
            if (_distance <= 2f)
            {
                _isAtack = true;
            }
            else
            {
                _isAtack = false;
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other != null && other.gameObject.tag == "Bot" || other.gameObject.tag == "Player")
            {
                _target = other.gameObject;
                
            }
            else
            {
                _target = GameObject.FindWithTag("GreenBase");
            }

            if (other != null && other.gameObject.tag == "PlayerSword")
            {
                GetDamage(_playerDamage);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other != null && other.gameObject.tag == "Bot" || other.gameObject.tag == "Player")
            {
                _target = GameObject.FindWithTag("GreenBase");

            }
        }
        
        protected void Rotate(GameObject target)
        {
            Vector3 direction = target.transform.position - _rigidbodyEnemy.transform.position;
            _rigidbodyEnemy.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        protected override void Move()
        {
            if (!_isAtack)
            {
                _rigidbodyEnemy.MovePosition(_rigidbodyEnemy.position + transform.forward * (moveSpeed * Time.deltaTime));
            }
            
        }

        protected override void PlayAnimation()
        {
            if (!_isAtack)
            {
                _animator.SetTrigger("Run");
            }
            else
            {
                _animator.SetTrigger("Atack");
            }
                
            
        }
    }

}
