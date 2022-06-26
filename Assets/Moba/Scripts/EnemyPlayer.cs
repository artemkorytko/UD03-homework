using UnityEngine;
using UnityEngine.AI;

namespace Moba
{
    public class EnemyPlayer : AnimatedPlayer
    {
        [SerializeField] protected GameObject _player;
        [SerializeField] protected float _distance;
        protected NavMeshAgent _agent;
        protected float _radius=15;
        
        
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        
        private void Update()
        {

            _distance = Vector3.Distance(_player.transform.position, transform.position);
            if (_distance > _radius)
            {
                _agent.enabled = false;
                gameObject.GetComponent<Animator>().SetTrigger("Idle");
            }

            if (_distance < _radius && _distance > 2f)
            {
                _agent.enabled = true;
                _agent.SetDestination(_player.transform.position);
                gameObject.GetComponent<Animator>().SetTrigger("Run");
            }

            if (_distance < 2f)
            {
                _agent.enabled = false;
                gameObject.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
    
}

