using System.Runtime.InteropServices;
using CodeBase.Gameplay;
using Test.CodeBase;
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
            RegisterBulletFactory();
            RegisterLoadingCurtain();
            RegisterEnemySpawner();
            
            RegisterWithoutAbstractions();
        }

        private void RegisterSomeNonMonoBehaviour()
        {
            Container
                .Bind<IMovements>()
                .To<Movements>()
                .AsSingle();
        }

        private void RegisterWithoutAbstractions()
        {
            Container
                .Bind<TestSevice>()
                .AsSingle();
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

        private void RegisterBulletFactory()
        {
            Container
                .BindFactory<float, Enemy, Transform, Bullet, Bullet.Factory>()
                .FromPoolableMemoryPool<float, Enemy, Transform, Bullet, BulletPool>(poolBinder => poolBinder
                    .WithInitialSize(12)
                    .WithMaxSize(20)
                    .FromComponentInNewPrefab(_bulletPrefab)
                    .UnderTransformGroup("Bullets"));
        }

        private void RegisterEnemiesFactory()
        {
            Container
                .BindFactory<Vector3, Enemy, Enemy.Factory>()
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

        class BulletPool : MonoPoolableMemoryPool<float, Enemy, Transform, IMemoryPool, Bullet>
        {
            
        }
    }
}
