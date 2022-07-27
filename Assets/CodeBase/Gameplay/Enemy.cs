﻿using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class Enemy : MonoBehaviour
    {
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
            _signalBus.Fire(new ShootToEnemySignal() { Enemy = this });
        }

        public void Dead()
        {
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Enemy>
        {
            
        }
    }
}