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
            _rigidbodyEnemy.MovePosition(_rigidbodyEnemy.position + transform.forward * (moveSpeed * Time.deltaTime));
            
        }

        protected override void PlayAnimation()
        {
            
                _animator.SetTrigger("Run");
            
        }
    }

}
