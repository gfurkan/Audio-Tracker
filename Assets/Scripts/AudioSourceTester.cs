using System;
using UnityEngine;

namespace Audio.Test
{
    public class AudioSourceTester: MonoBehaviour
    {
        public float sensitivity = 100f;
        public float beatThreshold = 0.1f;
        public float beatDelay = 0.1f;

        public AudioSource audioSource;
        private float tempTime = 0;
        
        public static event Action onBeated;
        public static event Action onAudioFinished;

        private bool _isFinished = false;
        
        void Update()
        {
            GetBeat();
            CheckIsAudioFinished();
        }

        void GetBeat()
        {
            float[] spectrumData = new float[256];
            audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

            float average = 0f;
            for (int i = 0; i < spectrumData.Length; i++)
            {
                average += spectrumData[i];
            }
            average /= spectrumData.Length;

            float adjustedThreshold = beatThreshold * sensitivity;
            float beatTime = Time.time;

            if (Mathf.Abs(tempTime- beatTime)>beatDelay)
            {
                if (average > adjustedThreshold)
                {
                    tempTime = beatTime;
                    onBeated?.Invoke();
                }
            }
        }

        void CheckIsAudioFinished()
        {
            if (!audioSource.isPlaying && !_isFinished)
            {
                _isFinished = true;
                onAudioFinished?.Invoke();
            }
        }
    }
}