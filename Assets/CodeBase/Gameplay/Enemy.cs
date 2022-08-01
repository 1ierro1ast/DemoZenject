using System;
using CodeBase.Extensions;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class Enemy : MonoBehaviour
    {
        private Player _player;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(Vector3 position, Player player, SignalBus signalBus)
        {
            transform.position = position;
            _signalBus = signalBus;
            _player = player;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, 0.1f * Time.deltaTime);
        }

        private void OnMouseDown()
        {
            Debug.Log(name);
            _signalBus.Fire(new ShootToEnemySignal() {Enemy = this});
        }

        public void Dead()
        {
            Debug.Log(nameof(Dead));
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Vector3, Enemy>
        {
            public override Enemy Create(Vector3 param)
            {
                return base.Create(param);
            }
        }

        [Serializable]
        public class Settings
        {
            [SerializeField] private float _uselessParameter;
        }
    }
}