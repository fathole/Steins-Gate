using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene.UIMain.MusicPage
{
    public class UDEMusicPlayer : MonoBehaviour
    {
        #region Declaration

        [Header("Audio Source")]
        [SerializeField] private AudioSource audioSource;

        private Action onAudioFinishedCallback;
        private Action onAudioPlayingCallback;

        private int interval = 1;
        private float nextTime = 0;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Action
            onAudioPlayingCallback = null;
            onAudioFinishedCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(Action onAudioPlayingCallback, Action onAudioFinishedCallback)
        {
            // Setup Action
            this.onAudioPlayingCallback = onAudioPlayingCallback;
            this.onAudioFinishedCallback = onAudioFinishedCallback;
        }

        #endregion

        #region Main Function

        public void PlayAudio(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void ResumeAudio()
        {
            audioSource.Play();
        }

        public void PauseAudio()
        {
            audioSource.Pause();
        }

        public void SetAudioTime(float time)
        {
            audioSource.time = time;         
        }

        public float GetCurrentTime()
        {
            return audioSource.time;
        }

        #endregion

        private void Update()
        {
            if(audioSource.isPlaying == true)
            {
                if (Time.time >= nextTime)
                {
                    onAudioPlayingCallback?.Invoke();

                    nextTime += interval;
                }
            }

            if(audioSource.clip!=null && audioSource.time >= audioSource.clip.length)
            {
                onAudioFinishedCallback?.Invoke();
            }
        }
    }
}