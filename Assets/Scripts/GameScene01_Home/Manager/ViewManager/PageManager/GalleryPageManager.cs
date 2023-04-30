using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using HomeScene.UIMain;
using TMPro;

namespace HomeScene
{
    public class GalleryPageManager : MonoBehaviour
    {
        #region Declaration

        private UIMain.GalleryPage.GalleryPage galleryPage;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset galleryPageMoveInTimeline;
        [SerializeField] private PlayableAsset galleryPageMoveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            galleryPage = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIMain.GalleryPage.GalleryPage galleryPage)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.galleryPage = galleryPage;
        }

        #endregion

        #region Main Function

        /* ----- Init Element ----- */

        public void InitElements()
        {
            galleryPage.oDEOtherImagesScrollView.InitElement();
            galleryPage.oDEPixivImagesScrollView.InitElement();
            galleryPage.oDEScopeButtonList.InitElement();
            galleryPage.oDESteinsGate0ImagesScrollView.InitElement();
            galleryPage.oDESteinsGateDarlingImagesScrollView.InitElement();
            galleryPage.oDESteinsGateImagesScrollView.InitElement();
            galleryPage.oDESteinsGatePhenogramImagesScrollView.InitElement();            
            galleryPage.oSEBackButton.InitElement();
            galleryPage.uSEBackground.InitElement();
        }

        /* ----- Setup Element ----- */

        public void SetupODEOtherImagesScrollView(List<Sprite> spriteList, Action<Sprite> onImageSlotPointerClickCallback)
        {
            galleryPage.oDEOtherImagesScrollView.SetupElement(spriteList, onImageSlotPointerClickCallback);
        }

        public void SetupODEPixivImagesScrollView(List<Sprite> spriteList, Action<Sprite> onImageSlotPointerClickCallback)
        {
            galleryPage.oDEPixivImagesScrollView.SetupElement(spriteList, onImageSlotPointerClickCallback);
        }

        public void SetupODEScopeButtonList(TMP_FontAsset fontAsset, TextContentBase.GalleryPage.ODEScopeButtonList textContent, Action<GalleryPageScopeOption> onScopeButtonPointerClickCallback)
        {
            galleryPage.oDEScopeButtonList.SetupElement(fontAsset, textContent, onScopeButtonPointerClickCallback);
        }

        public void SetupODESteinsGate0ImagesScrollView(List<Sprite> spriteList, Action<Sprite> onImageSlotPointerClickCallback)
        {
            galleryPage.oDESteinsGate0ImagesScrollView.SetupElement(spriteList, onImageSlotPointerClickCallback);
        }

        public void SetupODESteinsGateDarlingImagesScrollView(List<Sprite> spriteList, Action<Sprite> onImageSlotPointerClickCallback)
        {
            galleryPage.oDESteinsGateDarlingImagesScrollView.SetupElement(spriteList, onImageSlotPointerClickCallback);
        }

        public void SetupODESteinsGateImagesScrollView(List<Sprite> spriteList, Action<Sprite> onImageSlotPointerClickCallback)
        {
            galleryPage.oDESteinsGateImagesScrollView.SetupElement(spriteList, onImageSlotPointerClickCallback);
        }

        public void SetupODESteinsGatePhenogramImagesScrollView(List<Sprite> spriteList, Action<Sprite> onImageSlotPointerClickCallback)
        {
            galleryPage.oDESteinsGatePhenogramImagesScrollView.SetupElement(spriteList, onImageSlotPointerClickCallback);
        }

        public void SetupOSEBackButton(Action onPointerClickCallback)
        {
            galleryPage.oSEBackButton.SetupElement(onPointerClickCallback);
        }

        public void SetupUSEBackground()
        {
            galleryPage.uSEBackground.SetupElement();
        }

        /* ----- Function ----- */

        public void SetDisplayScope(GalleryPageScopeOption galleryPageScopeOption)
        {
            galleryPage.oDEScopeButtonList.SetSelectedScope(galleryPageScopeOption);

            galleryPage.oDEOtherImagesScrollView.gameObject.SetActive(galleryPageScopeOption == GalleryPageScopeOption.Other);
            galleryPage.oDEPixivImagesScrollView.gameObject.SetActive(galleryPageScopeOption == GalleryPageScopeOption.Pixiv);
            galleryPage.oDESteinsGate0ImagesScrollView.gameObject.SetActive(galleryPageScopeOption == GalleryPageScopeOption.SteinsGate0);
            galleryPage.oDESteinsGateDarlingImagesScrollView.gameObject.SetActive(galleryPageScopeOption == GalleryPageScopeOption.SteinsGateDaring);
            galleryPage.oDESteinsGateImagesScrollView.gameObject.SetActive(galleryPageScopeOption == GalleryPageScopeOption.SteinsGate);
            galleryPage.oDESteinsGatePhenogramImagesScrollView.gameObject.SetActive(galleryPageScopeOption == GalleryPageScopeOption.SteinsGatePhenogram);
        }

        /* ----- Timeline ----- */

        public void PlayGalleryPageMoveInTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(galleryPageMoveInTimeline, finishCallback);
        }

        public void PlayGalleryPageMoveOutTimeline(Action finishCallback)
        {
            UIMainManager.PlayTimeline(galleryPageMoveOutTimeline, finishCallback);
        }

        #endregion
    }
}