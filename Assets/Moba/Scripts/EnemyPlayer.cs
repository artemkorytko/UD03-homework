using UnityEngine;
using UnityEngine.AI;

namespace Moba
{
    public class EnemyPlayer : AnimatedPlayer
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private float _distance;
        [SerializeField]private Rigidbody _enemyrb;
        protected NavMeshAgent _agent;
        protected float _radius=15;
        private bool _nearbyenemy;
        
        protected override void Awake()
        {
            base.Awake();
            
            _enemyrb = GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.SetDestination(_player.transform.position);
            _agent.enabled = true;
        }
        
        protected virtual void Start()
        {
            SetActive(true);
        }

        protected override void BeActive()
        {
            base.BeActive();
            Rotate(_player);
            
            _distance = Vector3.Distance(_enemyrb.gameObject.transform.position, _player.transform.position);
            if (_distance < _radius && _distance > 2f)
            {
                _nearbyenemy = false;
            }

            if (_distance < 2f)
            {
                _nearbyenemy = true;
            }
            if (_distance > 2f)
            {
                _nearbyenemy = false;
            }
        }

        protected override void Move()
        {
            if (!_nearbyenemy)
            {
                _agent.enabled = true;
                _enemyrb.MovePosition(_enemyrb.position + transform.forward * (moveSpeed * Time.deltaTime));
            }

            if (_nearbyenemy)
            {
                _agent.enabled = false;
            }
        }

        protected void Rotate(GameObject player)
        {
            Vector3 direction = _player.transform.position - _enemyrb.transform.position;
            _enemyrb.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        protected override void PlayAnimation()
        {
            if (!_nearbyenemy)
            {
                _agent.enabled = true;
                _animator.SetTrigger("Run");
            }
            if (_nearbyenemy)
            {
                _agent.enabled = true;
                _animator.SetTrigger("Attack");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword1"))
            {
                GetDamage(10);
            }
        }
    }
    
}

