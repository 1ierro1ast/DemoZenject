using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class Bullet : MonoBehaviour, IDisposable
    {
        private Enemy _enemy;
        private Pool _poolInstance;
        public void Initialize(Enemy enemy, Pool pool, Transform gunPoint)
        {
            transform.position = gunPoint.position;
            _enemy = enemy;
            _poolInstance = pool;
        }

        public void Dispose()
        {
            _poolInstance?.Dispose();
        }

        private void Update()
        {
            if (_enemy == null) return;
            if ((transform.position - _enemy.transform.position).sqrMagnitude <= 0.0)
            {
                _enemy.Dead();
                _poolInstance.Despawn(this);
                _enemy = null;
                return;
            }
            transform.position = Vector3.Lerp(transform.position, _enemy.transform.position, 0.4f * Time.deltaTime);
        }

        public class Pool : MemoryPool<Bullet>
        {
            
        }
    }
}