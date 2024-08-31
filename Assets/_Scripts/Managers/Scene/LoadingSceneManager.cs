using Shun_Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers.Scene
{
    public class LoadingSceneManager : SingletonMonoBehaviour<LoadingSceneManager>
    {
        [SerializeField] private float _delayDuration = 1.5f;
        private bool _isFirstUpdate = true;
        private void Update()
        {
            if (_isFirstUpdate)
            {
                _isFirstUpdate = false;
                
                Invoke(nameof(DelayUnload),_delayDuration);
            }
        }
        
        public void DelayUnload()
        {
            SceneManager.UnloadSceneAsync(AssetSceneEnum.LoadingScene.ToString());
        }
    }
}