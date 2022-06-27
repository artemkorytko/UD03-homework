using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moba
{
    public enum PlayerType
    {
        None,
        MainPlayer,
        EnemyPlayer,
        Bot
    }


    public abstract class BasePlayer : MonoBehaviour
    {
        [SerializeField] private PlayerType _type;
        [SerializeField] private int _maxHealth;
        [SerializeField] private bool _isActiveInUpdate;

        private int _currentHealth;
        private bool _isActive;

        public bool IsAlive => _currentHealth > 0;


        protected virtual void Aweke()
        {
            _currentHealth = _maxHealth;
        }

        private void Update()
        {
            if (!_isActiveInUpdate)
                return;

            if (!_isActive)
            {
                return;
            }

            BeActive();
        }

        private void FixedUpdate()
        {
            if (_isActiveInUpdate)
                return;

            if (!_isActive)
            
                return;
            BeActive();

        }
        protected abstract void BeActive();

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
        }
        public virtual void GetDamage(int value)
        {
            _currentHealth -= value;
            if (!IsAlive)
            {
                OnDeath();
            }
        }
        protected virtual void OnDeath()
        {
            _isActive = false;
            gameObject.SetActive(false);
        }
    }
}