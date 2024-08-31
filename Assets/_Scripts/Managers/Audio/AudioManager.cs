using Shun_Utilities;
using System;
using UnityEngine;

namespace _Scripts.Managers.Audio
{
    public class AudioManager : PersistentSingletonMonoBehaviour<AudioManager> 
    {
        [SerializeField] private AudioSource _bgmAudioSource;
        [SerializeField] private AudioSource _sfxAudioSource;
        [SerializeField] private AudioList _audioList;

        private void Start()
        {
            if (_bgmAudioSource == null)
            {
                _bgmAudioSource = gameObject.AddComponent<AudioSource>();
            }
            if (_sfxAudioSource == null)
            {
                _sfxAudioSource = gameObject.AddComponent<AudioSource>();
            }
            if (_audioList == null)
            {
                Debug.LogError("AudioList is null");
            }
            
            AudioClip clip = _audioList.GetAudioClip(AudioTypeEnum.Music1, 0);
            if (clip != null)
            {
                _bgmAudioSource.clip = clip;
                _bgmAudioSource.loop = true;
                _bgmAudioSource.Play();
            }
        }

        public void PlaySFX(AudioTypeEnum audioTypeEnum, int index = 0)
        {
            AudioPack pack = _audioList.GetAudioPack(audioTypeEnum, index);

            if (pack == null)
            {
                Debug.LogError("AudioPack is null");
                return;
            }

            float volume = pack.Volume + UnityEngine.Random.Range(-pack.VolumeVariance, pack.VolumeVariance);
            float pitch = pack.Pitch + UnityEngine.Random.Range(-pack.PitchVariance, pack.PitchVariance);

            _sfxAudioSource.volume = volume;
            _sfxAudioSource.pitch = pitch;
            _sfxAudioSource.PlayOneShot(pack.AudioClips[0]);
        }

        public void PlayBGM(AudioTypeEnum audioTypeEnum, int index = 0)
        {
            AudioPack pack = _audioList.GetAudioPack(audioTypeEnum, index);

            if (pack == null)
            {
                Debug.LogError("AudioPack is null");
                return;
            }

            float volume = pack.Volume + UnityEngine.Random.Range(-pack.VolumeVariance, pack.VolumeVariance);
            float pitch = pack.Pitch + UnityEngine.Random.Range(-pack.PitchVariance, pack.PitchVariance);

            _bgmAudioSource.Stop();
            _bgmAudioSource.clip = pack.AudioClips[0];
            _bgmAudioSource.loop = true;
            _bgmAudioSource.volume = volume;
            _bgmAudioSource.pitch = pitch;
            _bgmAudioSource.Play();
        }
        
        public void ToggleBGM()
        {
            _bgmAudioSource.mute = !_bgmAudioSource.mute;
        }
        public void ToggleSFX()
        {
            _sfxAudioSource.mute = !_sfxAudioSource.mute;
        }
        public void ChangeVolume(float volume)
        {
            _bgmAudioSource.volume = volume;
            _sfxAudioSource.volume = volume;
        }

        public void ChangeBgmVolume(float volume)
        {
            _bgmAudioSource.volume = volume;
        }
    
        public void ChangeSfxVolume(float volume)
        {
            _sfxAudioSource.volume = volume;
        }

    }
}
