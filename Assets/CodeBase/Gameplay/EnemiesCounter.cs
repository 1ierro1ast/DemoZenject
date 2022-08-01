using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Gameplay
{
    public class EnemiesCounter : MonoBehaviour
    {
        private Text _text;
        private EnemySpawner _enemySpawner;
        
        [Inject] private DiContainer _container;

        private void Start()
        {
            _enemySpawner = _container.Resolve<EnemySpawner>();
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            _text.text = "Enemies: " + _enemySpawner.EnemiesAmount;
        }
    }
}
