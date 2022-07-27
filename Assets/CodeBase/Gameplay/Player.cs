using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    [RequireComponent(typeof(Gun))]
    public class Player : MonoBehaviour
    {
        private Gun _gun;

        private void Awake()
        {
            _gun = GetComponent<Gun>();
        }

        public void Shoot(ShootToEnemySignal shootToEnemySignal)
        {
            _gun.Shoot(shootToEnemySignal.Enemy);
        }
    }
}