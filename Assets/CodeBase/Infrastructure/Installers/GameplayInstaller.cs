using CodeBase.Gameplay;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private LoadingCurtain _loadingCurtainPrefab;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Bullet _bulletPrefab;

        public override void InstallBindings()
        {
            RegisterSignals();

            RegisterPlayer();
            RegisterEnemiesFactory();
            //RegisterBulletPool();
            RegisterLoadingCurtain();
            RegisterEnemySpawner();
        }

        private void RegisterSignals()
        {
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<ShootToEnemySignal>();
            Container
                .BindSignal<ShootToEnemySignal>()
                .ToMethod<Player>(player => player.Shoot)
                .FromResolve();
        }

        private void RegisterEnemySpawner()
        {
            Container
                .Bind<EnemySpawner>()
                .FromComponentInNewPrefab(_enemySpawner)
                .WithGameObjectName("EnemySpawner")
                .AsSingle()
                .NonLazy();
        }

        private void RegisterLoadingCurtain()
        {
            Container
                .BindInterfacesAndSelfTo<LoadingCurtain>()
                .FromComponentInNewPrefab(_loadingCurtainPrefab)
                .AsSingle()
                .NonLazy();
        }

        private void RegisterBulletPool()
        {
            Container
                .BindMemoryPool<Bullet, Bullet.Pool>()
                .FromComponentInNewPrefab(_bulletPrefab)
                .AsSingle()
                .NonLazy();
        }

        private void RegisterEnemiesFactory()
        {
            Container
                .BindFactory<Enemy, Enemy.Factory>()
                .FromComponentInNewPrefab(_enemyPrefab)
                .AsSingle()
                .NonLazy();
        }

        private void RegisterPlayer()
        {
            Container
                .Bind<Player>()
                .FromComponentInNewPrefab(_playerPrefab)
                .WithGameObjectName("Player")
                .AsSingle()
                .NonLazy();
        }
    }
}
