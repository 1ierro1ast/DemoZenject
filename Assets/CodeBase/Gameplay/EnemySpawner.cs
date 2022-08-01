using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        private Enemy.Factory _enemyFactory;

        public int EnemiesAmount => _spawnPoints.Length;

        [Inject]
        public void Construct(Enemy.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void Start()
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                _enemyFactory.Create(spawnPoint.position);
            }
        }
    }
}