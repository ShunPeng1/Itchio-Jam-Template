using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Shun_Utilities;

public class AssetSceneManager
{
    public enum AssetScene
    {
        SplashScreenScene,
        LoadingScene,
        LobbyScene,
        GameScene,
        LevelSelectScene,
        CharacterSelectScene,
        MainMenuScene,
        TutorialScene,
        CreditScene,
        LevelCompleteScene,
        GameOverScene,
        PersistenceScene,
        LevelScene,
    }

    
    private static string targetScene;
    
    public static void Exit()
    {
        Application.Quit();
    }
    
    public static void Tutorial()
    {
        SceneManager.LoadScene(AssetScene.TutorialScene.ToString());
    }
    
    public static void Credit()
    {
        SceneManager.LoadScene(AssetScene.CreditScene.ToString());
    }
    
    public static string GetLevelScene(int i)
    {
        return (AssetScene.LevelScene.ToString() + " " + i);
    }

    public static void LoadLoadingScene()
    {
        SceneManager.LoadScene(AssetScene.LoadingScene.ToString(), LoadSceneMode.Additive);
    }
    

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        LoadLoadingScene();
        
    }
    
    public static void LoadTargetScene()
    {
        SceneManager.LoadScene(targetScene);
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
