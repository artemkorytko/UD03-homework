using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Moba
{
    public class EnemyPlayer : AnimatedPlayer
    {
        [SerializeField] protected GameObject _EnemyPlayer;
        [SerializeField] protected float _distance;
        NavMeshAgent nav;
        public float Radius = 20;

        private void Start()
        {
            nav = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            _distance = Vector3.Distance(_EnemyPlayer.transform.position, transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("Idle");

            if (_distance > Radius)
            {
                nav.enabled = false;
            }
            if (_distance > Radius)
            {
                nav.enabled = true;
                nav.SetDestination(_EnemyPlayer.transform.position);
                gameObject.GetComponent<Animator>().SetTrigger("Run");
            }
        }


    }
}
