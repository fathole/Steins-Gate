using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using HomeScene.UIMain;
using TMPro;

namespace HomeScene
{
    public class SentencePageManager : MonoBehaviour
    {
        #region Declaration

        private UIMain.SentencePage.SentencePage sentencePage;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset sentencePageMoveInTimeline;
        [SerializeField] private PlayableAsset sentencePageMoveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            sentencePage = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIMain.SentencePage.SentencePage sentencePage)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.sentencePage = sentencePage;
        }

        #endregion

        #region Main Function

        /* ----- Init Element ----- */

        public void InitElements()
        {
            sentencePage.oDESentenceScrollView.InitElement();
            sentencePage.oSEBackButton.InitElement();
            sentencePage.uDETitle.InitElement();
            sentencePage.uSEBackground.InitElement();
        }

        /* ----- Setup Element ----- */

        public void SetupODESentenceScrollView(TMP_FontAsset fontAsset, List<TextContentBase.SentencePage.UDESentenceScrollViewSentenceSlot> sentenceList, Action<TextContentBase.SentencePage.UDESentenceScrollViewSentenceSlot> onSentencePointerClickCallback)
        {
            sentencePage.oDESentenceScrollView.SetupElement(fontAsset, sentenceList, onSentencePointerClickCallback);
        }

        public void SetupOSEBackButton(Action onPointerClickCallback)
        {
            sentencePage.oSEBackButton.SetupElement(onPointerClickCallback);
        }

        public void SetupUDETitle(TMP_FontAsset fontAsset, TextContentBase.SentencePage.UDETitle textContent)
        {
            sentencePage.uDETitle.SetupElement(fontAsset, textContent);
        }

        public void SetupUSEBackground()
        {
            sentencePage.uSEBackground.SetupElement();
        }

        /* ----- Timeline ----- */

        public void PlaySentencePageMoveInTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(sentencePageMoveInTimeline, finishCallback);
        }

        public void PlaySentencePageMoveOutTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(sentencePageMoveOutTimeline, finishCallback);
        }

        #endregion
    }
}