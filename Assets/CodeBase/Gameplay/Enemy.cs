using System;
using CodeBase.Extensions;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class Enemy : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Vector3, Enemy>
        {
            public override Enemy Create(Vector3 param)
            {
                var enemy = base.Create(param);
                enemy.SetStartPoint(param);
                return enemy;
            }
        }

        private void SetStartPoint(Vector3 vector3)
        {
            transform.position = vector3;
        }

        private Player _player;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(Player player, SignalBus signalBus)
        {
            _player = player;
            _signalBus = signalBus;
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
    }
}