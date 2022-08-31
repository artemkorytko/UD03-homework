using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace Moba
{
    public class Bot : MovablePlayer
    {
        
        [SerializeField] GameObject _base;
        [SerializeField] private Transform _attackBase;
        private NavMeshAgent _navMeshAgent;

        protected override void Awake()
        {
            _base=FindObjectOfType<GameObject>(_attackBase);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.enabled = true;
            _navMeshAgent.SetDestination(_base.transform.position);
            
            base.Awake();
        }
        
        private void Start()
        {
            SetActive(true);
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

