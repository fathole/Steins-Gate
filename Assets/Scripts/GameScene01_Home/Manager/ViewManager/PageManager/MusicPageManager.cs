using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using HomeScene.UIMain;
using TMPro;

namespace HomeScene
{
    public class MusicPageManager : MonoBehaviour
    {
        #region Declaration

        private UIMain.MusicPage.MusicPage musicPage;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset musicPageMoveInTimeline;
        [SerializeField] private PlayableAsset musicPageMoveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            musicPage = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIMain.MusicPage.MusicPage musicPage)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.musicPage = musicPage;
        }

        #endregion

        #region Main Function

        /* ----- Init Element ----- */

        public void InitElements()
        {
            musicPage.oDEMusicControlBar.InitElement();
            musicPage.oDEMusicScrollView.InitElement();
            musicPage.oDESearchDataEntry.InitElement();
            musicPage.oDESortingButton.InitElement();
            musicPage.oDESortingPanal.InitElement();
            musicPage.oSEBackButton.InitElement();
            musicPage.uSEBackground.InitElement();
        }

        /* ----- Setup Element ----- */

        public void SetupODEMusicControlBar(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODEMusicControlBar textContent, bool isPlaying, bool isLoop, bool isRandom, Action onLoopButtonPointerClickCallback, Action onrandomButtonPointerClickCallback, Action onPreviousButtonPointerClickCallback, Action onNextButtonPointerClickCallback, Action onPlayButtonPointerClickCallback, Action onProgressBarValueChangeCallback, Action onProgressPointerDownCallback, Action onProgressPointerUpCallback)
        {
            musicPage.oDEMusicControlBar.SetupElement(fontAsset, textContent, isPlaying, isLoop, isRandom, onLoopButtonPointerClickCallback, onrandomButtonPointerClickCallback, onPreviousButtonPointerClickCallback, onNextButtonPointerClickCallback, onPlayButtonPointerClickCallback, onProgressBarValueChangeCallback, onProgressPointerDownCallback, onProgressPointerUpCallback);
        }

        public void SetupODEMusicScrollView(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODEMusicScrollViewMusicSlot textContent, List<AudioClip> audioList, Action<AudioClip> onMusicSlotPointerClickCallback)
        {
            musicPage.oDEMusicScrollView.SetupElement(fontAsset, textContent, audioList, onMusicSlotPointerClickCallback);
        }

        public void SetupODESearchDataEntry(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODESearchDataEntry textContent, Action onValueChangeCallback)
        {
            musicPage.oDESearchDataEntry.SetupElement(fontAsset, textContent, onValueChangeCallback);
        }

        public void SetupODESortingButton(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODESortingButton textContent, Action onPointerClickCallback)
        {
            musicPage.oDESortingButton.SetupElement(fontAsset, textContent, onPointerClickCallback);
        }

        public void SetupODESortingPanal(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODESortingPanal textContent, MusicPageSortingOption musicPageSortingOption, Action onPointerClickCallback, Action onNameButtonPointerClickCallback, Action onLengthButtonPointerClickCallback)
        {
            musicPage.oDESortingPanal.SetupElement(fontAsset, textContent, musicPageSortingOption, onPointerClickCallback, onNameButtonPointerClickCallback, onLengthButtonPointerClickCallback);
        }

        public void SetupOSEBackButton( Action onPointerClickCallback)
        {
            musicPage.oSEBackButton.SetupElement(onPointerClickCallback);
        }

        public void SetupUDEMusicPlayer(Action onAudioPlayingCallback, Action onAudioFinishedCallback)
        {
            musicPage.uDEMusicPlayer.SetupElement(onAudioPlayingCallback, onAudioFinishedCallback);
        }

        public void SetupUSEBackground()
        {
            musicPage.uSEBackground.SetupElement();
        }

        /* ----- Function ----- */

        public void PlayAudio(TextContentBase.MusicPage.ODEMusicControlBar textContent, AudioClip audioClip)
        {
            musicPage.oDEMusicControlBar.UpdateMusicInfo(textContent, audioClip);
            musicPage.uDEMusicPlayer.PlayAudio(audioClip);
            musicPage.oDEMusicControlBar.SetIsPlaying(true);
        }

        public void ResumeAudio()
        {
            musicPage.uDEMusicPlayer.ResumeAudio();
            musicPage.oDEMusicControlBar.SetIsPlaying(true);
        }

        public void PauseAudio()
        {
            musicPage.uDEMusicPlayer.PauseAudio();
            musicPage.oDEMusicControlBar.SetIsPlaying(false);
        }

        public float GetCurrentTime()
        {
            return musicPage.uDEMusicPlayer.GetCurrentTime();
        }

        public void SetAudioTime(TextContentBase.MusicPage.ODEMusicControlBar textContent, float newTime, float clipLength)
        {
            musicPage.uDEMusicPlayer.SetAudioTime(newTime);
            UpdateProgressBarValue(textContent, newTime, clipLength);
        }

        public void SetIsLoop(bool isLoop)
        {
            musicPage.oDEMusicControlBar.SetIsLoop(isLoop);
        }

        public void SetIsRandom(bool isRandom)
        {
            musicPage.oDEMusicControlBar.SetIsRandom(isRandom);
        }        

        public void UpdateProgressBarValue(TextContentBase.MusicPage.ODEMusicControlBar textContent, float currentTime, float clipLength)
        {
            musicPage.oDEMusicControlBar.UpdateProgressBar(textContent, currentTime, clipLength);
        }

        public float GetProgressBarValue()
        {
            return musicPage.oDEMusicControlBar.GetProgressBarValue();
        }

        public string GetSearchContent()
        {
            return musicPage.oDESearchDataEntry.GetSearchContent();
        }

        public void ShowSortingPanel(MusicPageSortingOption sortingOption)
        {
            musicPage.oDESortingPanal.gameObject.SetActive(true);
            musicPage.oDESortingPanal.SetSelected(sortingOption);
        }

        public void CloseSortingPanel()
        {
            musicPage.oDESortingPanal.gameObject.SetActive(false);
            musicPage.oDESortingPanal.gameObject.SetActive(false);
        }

        public void UpdateScrollView(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODEMusicScrollViewMusicSlot textContent, List<AudioClip> audioList, Action<AudioClip> onMusicSlotPointerClickCallback)
        {
            musicPage.oDEMusicScrollView.UpdateMusicScrollView(fontAsset, textContent, audioList, onMusicSlotPointerClickCallback);
        }

        /* ----- Timeline ----- */

        public void PlayMusicPageMoveInTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(musicPageMoveInTimeline, finishCallback);
        }

        public void PlayMusicPageMoveOutTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(musicPageMoveOutTimeline, finishCallback);
        }

        #endregion
    }
}