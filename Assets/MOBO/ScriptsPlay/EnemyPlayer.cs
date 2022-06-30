using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MOBA
{
    public class EnemyPlayer : AnimatePlayer
    {
        [SerializeField] protected GameObject _player;
        [SerializeField] protected float _triggerDistance;
        protected NavMeshAgent _agent;
        protected float _radius = 20;


        protected override void Move()
        {
            base.Move();
            
            _triggerDistance = Vector3.Distance(_player.transform.position, transform.position);
            if (_triggerDistance < _radius)
            {
                _agent.enabled = false;
                gameObject.GetComponent<Animator>().SetTrigger("Idle");
            }
            else if  (_triggerDistance < _radius && _triggerDistance > 2f)
            {
                _agent.enabled = true;
                _agent.SetDestination(_player.transform.position);
                gameObject.GetComponent<Animator>().SetTrigger("Run");
            }

            else if (_triggerDistance < 2f)
            {
                _agent.enabled = false;
                gameObject.GetComponent<Animator>().SetTrigger("Attack");
            }
        }

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _triggerDistance = Vector3.Distance(_player.transform.position, transform.position);
            if (_triggerDistance < _radius)
            {
                _agent.enabled = false;
                gameObject.GetComponent<Animator>().SetTrigger("Idle");
            }
            else if  (_triggerDistance < _radius && _triggerDistance > 2f)
            {
                _agent.enabled = true;
                _agent.SetDestination(_player.transform.position);
                gameObject.GetComponent<Animator>().SetTrigger("Run");
            }

            else if (_triggerDistance < 2f)
            {
                _agent.enabled = false;
                gameObject.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
}