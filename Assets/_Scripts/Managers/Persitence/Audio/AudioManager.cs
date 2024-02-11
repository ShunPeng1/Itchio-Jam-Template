using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Shun_Utilities;

public class AudioManager : PersistentSingletonMonoBehaviour<AudioManager> 
{
    [SerializeField] private AudioSource _bgmAudioSource;
    [SerializeField] private AudioSource _sfxAudioSource;
    
    
    public void PlaySfx(AudioClip clip)
    {
        _sfxAudioSource.PlayOneShot(clip);
    }
    public void PlayBgm(AudioClip clip)
    {
        _bgmAudioSource.Stop();
        _bgmAudioSource.clip = clip;
        _bgmAudioSource.Play();
    }
    public void ToggleBgm()
    {
        _bgmAudioSource.mute = !_bgmAudioSource.mute;
    }
    public void ToggleSfx()
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
