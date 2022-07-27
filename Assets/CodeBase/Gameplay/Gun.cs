using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _gunPoint;
        //private Bullet.Pool _bulletPool;

        /*[Inject]
        public void Construct(Bullet.Pool bulletPool)
        {
            //_bulletPool = bulletPool;
        }*/
        public void Shoot(Enemy enemy)
        {
            Debug.Log(nameof(Shoot));
            //var bullet = _bulletPool.Spawn();
            //bullet.Initialize(enemy, _bulletPool, _gunPoint);
        }
    }
}
