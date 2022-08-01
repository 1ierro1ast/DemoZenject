using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        private Enemy.Factory _enemyFactory;

        [Inject]
        public void Construct(Enemy.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void Start()
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                var enemy = _enemyFactory.Create(spawnPoint.position);
                //enemy.transform.position = spawnPoint.position;
            }
        }
    }
}