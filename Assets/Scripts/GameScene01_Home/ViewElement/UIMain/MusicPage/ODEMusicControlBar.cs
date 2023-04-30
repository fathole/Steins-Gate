using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HomeScene.UIMain.MusicPage
{
    public class ODEMusicControlBar : MonoBehaviour
    {
        #region Declaration

        [Header("Text")]
        [SerializeField] private TMP_Text musicNameText001;
        [SerializeField] private TMP_Text progressBarCurrentTimeText001;
        [SerializeField] private TMP_Text progressBarTotalTimeText001;

        [Header("Child")]
        [SerializeField] private ODEMusicControlBarLoopButton loopButton;
        [SerializeField] private ODEMusicControlBarRandomButton randomButton;
        [SerializeField] private ODEMusicControlBarPreviousButton previousButton;
        [SerializeField] private ODEMusicControlBarNextButton nextButton;
        [SerializeField] private ODEMusicControlBarPlayButton playButton;
        [SerializeField] private ODEMusicControlBarProgressBar progressBar;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Child
            loopButton.InitElement();
            randomButton.InitElement();
            previousButton.InitElement();
            nextButton.InitElement();
            playButton.InitElement();
            progressBar.InitElement();

            // Init Text
            musicNameText001.text = "";
            progressBarCurrentTimeText001.text = "";
            progressBarTotalTimeText001.text = "";
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODEMusicControlBar textContent, bool isPlaying, bool isLoop, bool isRandom, Action onLoopButtonPointerClickCallback, Action onRandomButtonPointerClickCallback, Action onPreviousButtonPointerClickCallback, Action onNextButtonPointerClickCallback, Action onPlayButtonPointerClickCallback, Action onProgressBarValueChangeCallback, Action onProgressBarPointerDownCallback, Action onProgressBarPointerUpCallback)
        {
            // Setup Font Asset
            musicNameText001.font = fontAsset;
            progressBarCurrentTimeText001.font = fontAsset;
            progressBarTotalTimeText001.font = fontAsset;

            // Update Text Content
            textContent.musicNameText001 = textContent.musicNameText001.Replace("{0}", textContent.selectSongNotice);
            textContent.progressBarCurrentTimeText001 = textContent.progressBarCurrentTimeText001.Replace("{0}", "00").Replace("{1}", "00");
            textContent.progressBarTotalTimeText001 = textContent.progressBarTotalTimeText001.Replace("{0}", "00").Replace("{1}", "00");

            // Setup Text Content
            musicNameText001.text = textContent.musicNameText001;
            progressBarCurrentTimeText001.text = textContent.progressBarCurrentTimeText001;
            progressBarTotalTimeText001.text = textContent.progressBarTotalTimeText001;

            // Setup Child
            loopButton.SetupElement(onLoopButtonPointerClickCallback);
            randomButton.SetupElement(onRandomButtonPointerClickCallback);
            previousButton.SetupElement(onPreviousButtonPointerClickCallback);
            nextButton.SetupElement(onNextButtonPointerClickCallback);
            playButton.SetupElement(onPlayButtonPointerClickCallback);
            progressBar.SetupElement(onProgressBarValueChangeCallback, onProgressBarPointerDownCallback, onProgressBarPointerUpCallback);

            SetIsLoop(isLoop);
            SetIsRandom(isRandom);
            SetIsPlaying(isPlaying);
        }

        #endregion

        #region Main Function

        public void UpdateMusicInfo(TextContentBase.MusicPage.ODEMusicControlBar textContent ,AudioClip audioClip)
        {
            // Update Text Content
            textContent.musicNameText001 = textContent.musicNameText001.Replace("{0}", audioClip.name);
            textContent.progressBarCurrentTimeText001 = textContent.progressBarCurrentTimeText001.Replace("{0}", "00").Replace("{1}", "00");
            textContent.progressBarTotalTimeText001 = textContent.progressBarTotalTimeText001.Replace("{0}", ((int)audioClip.length/60).ToString("D2")).Replace("{1}", ((int)(audioClip.length) %60).ToString("D2"));

            // Setup Text Content
            musicNameText001.text = textContent.musicNameText001;
            progressBarCurrentTimeText001.text = textContent.progressBarCurrentTimeText001;
            progressBarTotalTimeText001.text = textContent.progressBarTotalTimeText001;
        }

        public void SetIsLoop(bool isLoop)
        {
            loopButton.SetSelected(isLoop);
        }

        public void SetIsRandom(bool isRandom)
        {
            randomButton.SetSelected(isRandom);
        }

        public void SetIsPlaying(bool isPlaying)
        {
            playButton.SetIcon(isPlaying);
        }

        public void UpdateProgressBar(TextContentBase.MusicPage.ODEMusicControlBar textContent, float currentTime, float clipLength)
        {
            // Update Text Content
            textContent.progressBarCurrentTimeText001 = textContent.progressBarCurrentTimeText001.Replace("{0}", ((int)currentTime / 60).ToString("D2")).Replace("{1}", ((int)(currentTime) % 60).ToString("D2"));
            progressBarCurrentTimeText001.text = textContent.progressBarCurrentTimeText001;

            // Update Progress Bar
            progressBar.UpdateProgressBar(clipLength, currentTime);
        }

        public float GetProgressBarValue()
        {
            return progressBar.GetProgressBarValue();
        }

        #endregion
    }
}