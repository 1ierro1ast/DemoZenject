using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Gameplay
{
    public class LoadingCurtain : MonoBehaviour, IInitializable
    {
        public void Initialize()
        {
            Debug.Log("LoadScene");
            SceneManager.LoadScene("Scenes/GameScene");
            gameObject.SetActive(false);
        }
    }
}
