using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Managers.Audio
{
    [CreateAssetMenu(fileName = "AudioList", menuName = "Audio/AudioList")]
    public class AudioList : ScriptableObject
    {
        public AudioPack[] AudioPacks;
        
        public AudioClip GetAudioClip(AudioTypeEnum audioTypeEnum, int index = 0)
        {
            if (index >= AudioPacks[(int)audioTypeEnum].AudioClips.Length)
            {
                Debug.LogError("Index out of range");
                return null;
            }
            return AudioPacks[(int)audioTypeEnum].AudioClips[index];
        }
        
        public AudioPack GetAudioPack(AudioTypeEnum audioTypeEnum, int index = 0)
        {
            if (index >= AudioPacks[(int)audioTypeEnum].AudioClips.Length)
            {
                Debug.LogError("Index out of range");
                return null;
            }
            return AudioPacks[(int)audioTypeEnum];
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            AudioPacks ??= Array.Empty<AudioPack>();
            
            string[] names = Enum.GetNames(typeof(AudioTypeEnum));
            Array.Resize(ref AudioPacks, names.Length);
            for (int i = 0; i < names.Length; i++)
            {
                if (AudioPacks[i] == null)
                {
                    AudioPacks[i] = new AudioPack();
                }
                AudioPacks[i].Name = (AudioTypeEnum)i;
            }
        }
#endif
    }
}