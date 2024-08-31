using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers.Scene
{
    public class AssetSceneManager
    {
    
        private static string _targetScene;
    
        public static void Exit()
        {
            Application.Quit();
        }
        public static void Tutorial()
        {
            //SceneManager.LoadNetworkScene("How To Play");
        }
    
        public static void Credit()
        {
        
        }

        public static void LoadLoadingScene()
        {
            SceneManager.LoadScene(AssetSceneEnum.LoadingScene.ToString(), LoadSceneMode.Additive);
        }

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            LoadLoadingScene();
        
        }
    
        public static void LoadTargetScene()
        {
            SceneManager.LoadScene(_targetScene);
        }
    
        public static void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }

        public static void RestartScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    
    
        public static void HomeScene()
        {
            SceneManager.LoadScene(0);
        }
    

    }
}
