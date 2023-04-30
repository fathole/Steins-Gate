using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HomeScene.UIMain;
using HomeScene.UIPopup;

namespace HomeScene
{
    public class HomeView : MonoBehaviour
    {
        #region Declaration

        [Header("Sorting Layer Manager")]
        public UIMainManager uIMainManager;
        public UIPopupManager uIPopupManager;

        [Header("Page Manager")]
        public HomePageManager homePageManager;
        public GalleryPageManager galleryPageManager;
        public MusicPageManager musicPageManager;
        public SentencePageManager sentencePageManager;
        public IntroPageManager introPageManager;

        [Header("Popup Manager")]
        public ZoomImagePopupManager zoomImagePopupManager;

        #endregion

        #region Init Stage

        public void InitView()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitSortingLayerManager();

            InitPageManager();

            InitPopupManager();
        }

        private void InitSortingLayerManager()
        {
            uIMainManager.InitManager();
            uIPopupManager.InitManager();
        }

        private void InitPageManager()
        {
            homePageManager.InitManager();
            galleryPageManager.InitManager();
            musicPageManager.InitManager();
            sentencePageManager.InitManager();
            introPageManager.InitManager();
        }

        private void InitPopupManager()
        {
            zoomImagePopupManager.InitManager();
        }

        #endregion

        #region Setup Stage

        public void SetupView(Camera mainCamera, ScreenPropertiesData screenPropertiesData)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupSortingLayerManager(mainCamera, screenPropertiesData);

            SetupPageManager();

            SetupPopupManager();
        }

        private void SetupSortingLayerManager(Camera mainCamera, ScreenPropertiesData screenPropertiesData)
        {
            uIMainManager.SetupManager(mainCamera, screenPropertiesData, SortingLayerOption.UI_Main);
            uIPopupManager.SetupManager(mainCamera, screenPropertiesData, SortingLayerOption.UI_Popup);
        }

        private void SetupPageManager()
        {
            homePageManager.SetupManager(uIMainManager.homePage);
            galleryPageManager.SetupManager(uIMainManager.galleryPage);
            musicPageManager.SetupManager(uIMainManager.musicPage);
            sentencePageManager.SetupManager(uIMainManager.sentencePage);
            introPageManager.SetupManager(uIMainManager.introPage);
        }

        private void SetupPopupManager()
        {
            zoomImagePopupManager.SetupManager(uIPopupManager.zoomImagePopup);
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}