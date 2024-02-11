using UnityEngine;
using UnityEngine.SceneManagement;
using Shun_Utilities;

namespace _Scripts.Managers.Persitence
{
    public class LoadPersistenceSceneManager : MonoBehaviour
    {
        [SerializeField] private AssetSceneManager.AssetScene _persistenceScene = AssetSceneManager.AssetScene.PersistenceScene;
        
        private void Start()
        {
            if (SceneManager.GetSceneByName(_persistenceScene.ToString()).isLoaded) return;
            
            SceneManager.LoadScene(_persistenceScene.ToString(), LoadSceneMode.Additive);
        }
        

    }
}