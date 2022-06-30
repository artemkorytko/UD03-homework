using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MOBA
{
    public class Bot : MoveblePlayer
    {
        [SerializeField] protected GameObject _player;
        [SerializeField] protected float _triggerDistance;
        private Rigidbody _rigidbody;
        protected NavMeshAgent _agent;
        protected float _radius = 20;
        
        protected override void Move()
        {
            base.Move();
            if (_triggerDistance < _radius) // если джойстик не равен вектор зеро
            {
                _rigidbody.MovePosition(_rigidbody.position + transform.forward * moveSpeed * Time.deltaTime); // то двигаемся прямо
            }
            
        }
        
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        
        private void Update()
        {
            _triggerDistance = Vector3.Distance(_player.transform.position, transform.position);
            if (_triggerDistance > _radius)
            {
                _agent.enabled = false;
                Debug.Log("1");
        
            }
        
            if (_triggerDistance < _radius && _triggerDistance > 2f)
            {
                _agent.enabled = true;
                _agent.SetDestination(_player.transform.position);
                Debug.Log("2");
        
            }
        
            if (_triggerDistance < 2f)
            {
                _agent.enabled = false;
                Debug.Log("3");
                
        
            }
        }
    }
}