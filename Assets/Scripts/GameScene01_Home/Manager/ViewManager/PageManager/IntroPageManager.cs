using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using HomeScene.UIMain;

namespace HomeScene
{
    public class IntroPageManager : MonoBehaviour
    {
        #region Declaration

        private UIMain.IntroPage.IntroPage introPage;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset introPageMoveInTimeline;
        [SerializeField] private PlayableAsset introPageMoveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            introPage = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIMain.IntroPage.IntroPage introPage)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.introPage = introPage;
        }

        #endregion

        #region Main Function

        public void InitElements()
        {

        }

        // ToDo: Setup Element

        /* ----- Timeline ----- */

        public void PlayIntroPageMoveInTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(introPageMoveInTimeline, finishCallback);
        }

        public void PlayIntroPageMoveOutTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(introPageMoveOutTimeline, finishCallback);
        }
        #endregion
    }
}