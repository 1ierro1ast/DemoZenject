using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class Bullet : MonoBehaviour, IPoolable<float, Enemy, Transform, IMemoryPool>
    {
        [Serializable]
        public class Settings
        {
            public float Speed;
        }

        private IMemoryPool _pool;

        private Enemy _enemy;

        private float _speed;

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(float speed, Enemy enemy, Transform gunPoint, IMemoryPool pool)
        {
            _speed = speed;
            _pool = pool;
            _enemy = enemy;
            transform.position = gunPoint.position;
        }

        private void Update()
        {
            if (_enemy == null)
            {
                _pool.Despawn(this);
                return;
            }
            if ((transform.position - _enemy.transform.position).sqrMagnitude <= 0.01f)
            {
                _enemy.Dead();
                _pool.Despawn(this);
                _enemy = null;
                return;
            }
            transform.position = Vector3.Lerp(transform.position, _enemy.transform.position, 0.1f * _speed * Time.deltaTime);
        }

        public class Factory : PlaceholderFactory<float, Enemy, Transform, Bullet>
        {
            
        }
    }
}