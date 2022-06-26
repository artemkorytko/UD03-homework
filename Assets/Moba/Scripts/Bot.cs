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
        private GameObject _base;
        public string tag_point;
        private NavMeshAgent _navMeshAgent;

        private void Update()
        {
            _base=GameObject.FindGameObjectWithTag(tag_point);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.enabled = true;
            _navMeshAgent.SetDestination(_base.transform.position);
        }
    }
}

