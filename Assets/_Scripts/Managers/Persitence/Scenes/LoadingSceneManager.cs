using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Shun_Utilities;

namespace _Scripts.Managers.Persitence
{
    public class LoadingSceneManager : SingletonMonoBehaviour<LoadingSceneManager>
    {
        [SerializeField] private float _delayDuration = 1.5f;
        
        private void Start()
        {
            Invoke(nameof(DelayUnload),_delayDuration);
        }
        
        public void DelayUnload()
        {
            SceneManager.UnloadSceneAsync(AssetSceneManager.AssetScene.LoadingScene.ToString());
        }
    }
}