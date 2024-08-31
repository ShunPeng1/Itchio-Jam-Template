using System;
using UnityEngine;

namespace _Scripts.Managers.Audio
{
    [Serializable]
    public class AudioPack
    {
        public AudioTypeEnum Name;
        public AudioClip[] AudioClips;
        
        public float Volume = 1f;
        public float VolumeVariance = 0f;
        public float Pitch = 1f;
        public float PitchVariance = 0f;
        
    }
}