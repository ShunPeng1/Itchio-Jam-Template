using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace _Scripts.Managers.Persitence
{
    public class SplashScreenSceneManager : MonoBehaviour
    {
        [SerializeField] private float _initialDelayDuration = 0f;
        [SerializeField] private VideoClip [] _videoClips;
        [SerializeField] private VideoPlayer _videoPlayer;

        [SerializeField] private AssetSceneManager.AssetScene _targetScene = AssetSceneManager.AssetScene.MainMenuScene;
        
        private void Start()
        {
            _videoPlayer.playOnAwake = true;
            _videoPlayer.isLooping = false;
            _videoPlayer.waitForFirstFrame = true;


            StartCoroutine(nameof(StartVideo));

        }

        IEnumerator StartVideo()
        {
            yield return new WaitForSeconds(_initialDelayDuration);

            foreach (var videoClip in _videoClips)
            {
                _videoPlayer.clip = videoClip;
                _videoPlayer.Play();
                yield return new WaitForSeconds((float)videoClip.length);
            }
            
            SceneManager.LoadScene(_targetScene.ToString());
        }
        
        
    }
}