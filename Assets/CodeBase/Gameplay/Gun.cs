using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _gunPoint;
        private Bullet.Factory _bulletFactory;
        private Bullet.Settings _bulletSettings;

        [Inject]
        public void Construct(Bullet.Factory bulletFactory, Bullet.Settings bulletSettings)
        {
            _bulletFactory = bulletFactory;
            _bulletSettings = bulletSettings;
        }
        public void Shoot(Enemy enemy)
        {
            _bulletFactory.Create(_bulletSettings.Speed, enemy, _gunPoint);
        }
    }
}
