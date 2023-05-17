using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene
{
    public class HomeController : MonoBehaviour
    {
        #region Declaration

        #region Declaration - Enum

        private enum ControllerModeOption
        {
            None = 0,
            EnterSceneMode = 1,
            RunSceneMode = 2,
            ExitSceneMode = 3,
        }

        private enum PageOption
        {
            None = 0,
            HomePage = 1,
            GalleryPage = 2,
            MusicPage = 3,
            SentencePage =4,
            IntroPage = 5,
        }

        #endregion

        #region Declaration - Class

        private class HomePageValue
        {
            public bool isUserInputProcessFinished = false;

            public bool isGoToGalleryPage = false;
            public bool isGoToMusicPage = false;
            public bool isGoToSentencePage = false;
            public bool isGoToIntroPage = false;
        }

        private class GalleryPageValue
        {
            public bool isUserInputProcessFinished = false;

            public bool isGoToHomePage = false;

            public GalleryPageScopeOption galleryPageScopeOption = GalleryPageScopeOption.SteinsGate;
            public Sprite zoomingSprite = null;
        }
        
        public class MusicPageValue
        {
            public bool isUserInputProcessFinished = false;

            public bool isGoToHomePage = false;

            public List<AudioClip> showingAudioClipList = null;
            public List<AudioClip> playingAudioClipList = null;

            public MusicPageSortingOption musicPageSortingOption = MusicPageSortingOption.Name;

            public AudioClip playingAudio = null;

            public bool isLoop = false;
            public bool isRandom = false;
            public bool isPlaying = false;
        }

        private class SentencePageValue
        {
            public bool isUserInputProcessFinished = false;

            public bool isGoToHomePage = false;
        }

        private class IntroPageValue
        {
            public bool isUserInputProcessFinished = false;

            public bool isGoToHomePage = false;
        }

        private class StoredDataValue
        {
            public List<AudioClip> audioList = null;

            public List<Sprite> gallerySpriteList = null;

            public List<Sprite> steinsGateSpriteList = null;
            public List<Sprite> steinsGate0SpriteList = null;
            public List<Sprite> steinsGatePhenogramSpriteList = null;
            public List<Sprite> steinsGateDaringSpriteList = null;
            public List<Sprite> pixivSpriteList = null;
            public List<Sprite> otherSpriteList = null;
        }

        #endregion

        #region Declaration - Variable

        [Header("MVC")]       
        public static HomeController instance;
        private GameManager.GameManager gameManager = null;
        [SerializeField] private HomeView view;

        [Header("Controller Manager")]
        [SerializeField] private TextManager textManager;

        [Header("Font and Text")]
        private TMP_FontAsset fontAsset = null;
        private TextContentBase textContent = null;

        [Header("Camera And Canvas")]
        private Camera mainCamera = null;
        private ScreenPropertiesData screenPropertiesData = null;

        [Header("Page Value")]
        private HomePageValue homePageValue = null;
        private GalleryPageValue galleryPageValue = null;
        private MusicPageValue musicPageValue = null;
        private SentencePageValue sentencePageValue = null;
        private IntroPageValue introPageValue = null;

        private StoredDataValue storedDataValue = null;

        [Header("Game Manager Callback Function")]
        public Action gameManagerOnEnterSceneModeFinishedCallback = null;
        public Action gameManagerOnRunSceneModeFinishedCallback = null;
        public Action<SceneOption> gameManagerOnExitSceneModeFinishedCallback = null;        

        private ControllerModeOption currentMode = ControllerModeOption.None;
        private PageOption currentPage = PageOption.None;
        private PageOption previousPage = PageOption.None;

        private bool isSceneFinished = false;

        // Won't Use, Get From GameManager.cs Update Variable
        private HomeSceneOperationValue operationValue = null;


        #endregion

        #endregion

        #region Init Stage

        private void Awake()
        {
            instance = this;
        }

        private void InitScene()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitController();

            view.InitView();
        }

        private void InitController()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitControllerManager();

            InitStoreDataValue();
        }

        private void InitControllerManager()
        {
            textManager.InitManager();
        }

        private void InitStoreDataValue()
        {
            storedDataValue = new StoredDataValue();
        }

        #endregion

        #region Setup Stage

        private void SetupScene()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupController();

            view.SetupView(mainCamera, screenPropertiesData);
        }

        private void SetupController()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupByOperationValue();

            SetupControllerManager();

            SetupStoreDataValue();
        }

        private void SetupByOperationValue()
        {
            gameManager = operationValue.gameManager;
            mainCamera = operationValue.mainCamera;
            screenPropertiesData = operationValue.screenPropertiesData;
            fontAsset = operationValue.fontAsset;
            gameManagerOnEnterSceneModeFinishedCallback = operationValue.onEnterSceneModeFinishedCallback;
            gameManagerOnRunSceneModeFinishedCallback = operationValue.onRunSceneModeFinishedCallback;
            gameManagerOnExitSceneModeFinishedCallback = operationValue.onExitSceneModeFinishedCallback;
        }

        private void SetupControllerManager()
        {
            textManager.SetupManager();
        }

        private void SetupStoreDataValue()
        {
            storedDataValue.gallerySpriteList = Resources.LoadAll<Sprite>("Gallery").ToList();

            storedDataValue.steinsGateSpriteList = storedDataValue.gallerySpriteList.FindAll(x => x.name.StartsWith("SteinsGate_"));
            storedDataValue.steinsGate0SpriteList = storedDataValue.gallerySpriteList.FindAll(x => x.name.StartsWith("SteinsGate0_"));
            storedDataValue.steinsGatePhenogramSpriteList = storedDataValue.gallerySpriteList.FindAll(x => x.name.StartsWith("SteinsGatePhenogram_"));
            storedDataValue.steinsGateDaringSpriteList = storedDataValue.gallerySpriteList.FindAll(x => x.name.StartsWith("SteinsGateDarling_"));
            storedDataValue.pixivSpriteList = storedDataValue.gallerySpriteList.FindAll(x => x.name.StartsWith("Pixiv_"));
            storedDataValue.otherSpriteList = storedDataValue.gallerySpriteList.FindAll(x => x.name.StartsWith("Other"));

            storedDataValue.audioList = Resources.LoadAll<AudioClip>("Music").ToList();            
        }

        #endregion

        #region Main Function

        private void Main()
        {
            if (currentMode == ControllerModeOption.EnterSceneMode)
            {
                StartCoroutine(EnterSceneMode(EnterSceneModeFinishCallback));
            }
            else if (currentMode == ControllerModeOption.RunSceneMode)
            {
                StartCoroutine( RunSceneMode(RunSceneModeFinishCallback));
            }
            else if (currentMode == ControllerModeOption.ExitSceneMode)
            {
                StartCoroutine(ExitSceneMode(ExitSceneModeFinishCallback));
            }
        }

        #region Main - Enter Scene Mode

        private IEnumerator EnterSceneMode(Action finishCallback)
        {
            Debug.Log("----- Home Controller: Enter Scene Mode -----");

            InitScene();

            SetupScene();

            ReadyScene();

            yield return null;

            finishCallback?.Invoke();
        }

        private void EnterSceneModeFinishCallback()
        {
            gameManagerOnEnterSceneModeFinishedCallback?.Invoke();
        }

        private void ReadyScene()
        {
            // Setup Text Content
            textContent = textManager.GetTextContent(gameManager.GetDisplayLanguageOption());
        }

        #endregion

        #region Main - Run Scene Mode

        private IEnumerator RunSceneMode(Action finishCallback)
        {
            Debug.Log("----- Home Controller: Run Scene Mode -----");

            // Get First Page
            currentPage = GetFirstPage();

            // Go To First Page
            GoToPage(currentPage);

            yield return new WaitUntil(() => isSceneFinished == true);

            finishCallback?.Invoke();
        }

        private void RunSceneModeFinishCallback()
        {
            gameManagerOnRunSceneModeFinishedCallback?.Invoke();
        }

        private PageOption GetFirstPage()
        {
            return PageOption.HomePage;
        }

        private void GoToPage(PageOption nextPage)
        {
            previousPage = currentPage;
            currentPage = nextPage;

            switch (currentPage)
            {
                case PageOption.HomePage:
                    StartCoroutine(HomePage());
                    break;
                case PageOption.GalleryPage:
                    StartCoroutine(GalleryPage());
                    break;
                case PageOption.MusicPage:
                    StartCoroutine(MusicPage());
                   break;
                case PageOption.SentencePage:
                    StartCoroutine(SentencePage());
                    break;
                case PageOption.IntroPage:
                    StartCoroutine(IntroPage());
                    break;
                default:
                    Debug.LogError("<color=red>----- Page Option: " + nextPage + ", Not Found -----</color>");
                    break;
            }
        }

        #endregion

        #region Main - Exit Scene Mode

        private IEnumerator ExitSceneMode(Action finishCallback)
        {
            Debug.Log("----- Home Controller: Exit Scene Mode -----");

            yield return null;

            finishCallback?.Invoke();
        }

        private void ExitSceneModeFinishCallback()
        {
            gameManagerOnExitSceneModeFinishedCallback?.Invoke(SceneOption.None);
        }

        #endregion

        #region Page Function - Home Page

        private IEnumerator HomePage()
        {
            Debug.Log("----- Home Page -----");

            // Enter process
            yield return StartCoroutine(HomePageEnterProcess());

            // Move in process
            yield return StartCoroutine(HomePageMoveInProcess());

            // User input process
            Debug.Log("----- Home Page: User Response Process -----");
            yield return new WaitUntil(() => homePageValue.isUserInputProcessFinished == true);

            // Move out process
            yield return StartCoroutine(HomePageMoveOutProcess());

            // Exit process
            yield return StartCoroutine(HomePageExitProcess());
        }

        /* ----- Home Page: Enter Process ----- */

        private IEnumerator HomePageEnterProcess()
        {
            Debug.Log("----- Home Page: Enter Process -----");

            // Init Page Value
            HomePageEnterProcessInitPageValue();

            // Init Elements
            HomePageEnterProcessInitElements();

            // Setup Elements
            HomePageEnterProcessSetupElements();

            yield return null;
        }

        private void HomePageEnterProcessInitPageValue()
        {
            homePageValue = new HomePageValue();
        }

        private void HomePageEnterProcessInitElements()
        {
            view.homePageManager.InitElements();
        }

        private void HomePageEnterProcessSetupElements()
        {
            view.homePageManager.SetupODEGalleryButton(fontAsset, textContent.homePage.oDEGalleryButton, HomePageODEGalleryButtonPointerClickCallback);
            view.homePageManager.SetupODEIntroButton(fontAsset, textContent.homePage.oDEIntroButton, HomePageODEIntroButtonPointerClickCallback);
            view.homePageManager.SetupODEMusicButton(fontAsset, textContent.homePage.oDEMusicButton, HomePageODEMusicButtonPointerClickCallback);
            view.homePageManager.SetupODESentenceButton(fontAsset, textContent.homePage.oDESentenceButton, HomePageODESentenceButtonPointerClickCallback);
            view.homePageManager.SetupUDEHeader(fontAsset, textContent.homePage.uDEHeader);
            view.homePageManager.SetupUSEBackground();
        }

        /* ----- Home Page: Move In Process ----- */

        private IEnumerator HomePageMoveInProcess()
        {
            Debug.Log("----- Home Page: Move In Process -----");

            bool isHomePageMoveInFinished = false;

            view.homePageManager.PlayHomePageMoveInTimeline(() => isHomePageMoveInFinished = true);

            yield return new WaitUntil(() => isHomePageMoveInFinished);
        }

        /* ----- Home Page: Move Out Process ----- */

        private IEnumerator HomePageMoveOutProcess()
        {
            Debug.Log("----- Home Page: Move Out Process -----");

            bool isHomePageMoveOutFinished = false;

            view.homePageManager.PlayHomePageMoveOutTimeline(() => isHomePageMoveOutFinished = true);

            yield return new WaitUntil(() => isHomePageMoveOutFinished);
        }

        /* ----- Home Page: Exit Process ----- */

        private IEnumerator HomePageExitProcess()
        {
            Debug.Log("----- Home Page: Exit Process -----");

            if (homePageValue.isGoToGalleryPage == true)
            {
                GoToPage(PageOption.GalleryPage);
            }
            else if (homePageValue.isGoToMusicPage == true)
            {
                GoToPage(PageOption.MusicPage);
            }
            else if (homePageValue.isGoToSentencePage == true)
            {
                GoToPage(PageOption.SentencePage);
            }
            else if (homePageValue.isGoToIntroPage == true)
            {
                GoToPage(PageOption.IntroPage);
            }

            yield return null;
        }

        /* ----- Home Page: User Input Process (Page Callback Function)----- */

        private void HomePageODEGalleryButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                homePageValue.isUserInputProcessFinished = true;
                homePageValue.isGoToGalleryPage = true;
            }
        }

        private void HomePageODEMusicButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                homePageValue.isUserInputProcessFinished = true;
                homePageValue.isGoToMusicPage = true;
            }
        }

        private void HomePageODESentenceButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                homePageValue.isUserInputProcessFinished = true;
                homePageValue.isGoToSentencePage = true;
            }
        }

        private void HomePageODEIntroButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (homePageValue.isUserInputProcessFinished != true)
            {
                gameManager.OpenSmallPopup("ComingSoonPopup", fontAsset,  textContent.comingSoonPopup, HomePageComingSoonPopupPrimaryButtonPointerClickCallback, null, null);

                //homePageValue.isUserInputProcessFinished = true;
                //homePageValue.isGoToIntroPage = true;
            }
        }

        /* ----- Home Page: User Input Process (Popup Callback Function)----- */

        private void HomePageComingSoonPopupPrimaryButtonPointerClickCallback()
        {
            gameManager.CloseSmallPopup("ComingSoonPopup", null);
        }

        #endregion

        #region Page Function - Gallery Page

        private IEnumerator GalleryPage()
        {
            Debug.Log("----- Gallery Page -----");

            // Enter process
            yield return StartCoroutine(GalleryPageEnterProcess());

            // Move in process
            yield return StartCoroutine(GalleryPageMoveInProcess());

            // User input process
            Debug.Log("----- Gallery Page: User Response Process -----");
            yield return new WaitUntil(() => galleryPageValue.isUserInputProcessFinished == true);

            // Move out process
            yield return StartCoroutine(GalleryPageMoveOutProcess());

            // Exit process
            yield return StartCoroutine(GalleryPageExitProcess());
        }

        /* ----- Gallery Page: Enter Process ----- */

        private IEnumerator GalleryPageEnterProcess()
        {
            Debug.Log("----- Gallery Page: Enter Process -----");

            // Init Page Value
            GalleryPageEnterProcessInitPageValue();

            // Init Elements
            GalleryPageEnterProcessInitElements();

            // Setup Elements
            GalleryPageEnterProcessSetupElements();

            yield return null;
        }

        private void GalleryPageEnterProcessInitPageValue()
        {
            galleryPageValue = new GalleryPageValue();
        }

        private void GalleryPageEnterProcessInitElements()
        {
            view.galleryPageManager.InitElements();
        }

        private void GalleryPageEnterProcessSetupElements()
        {
            view.galleryPageManager.SetupODEOtherImagesScrollView(storedDataValue.otherSpriteList, GalleryPageODEImagesScrollViewImageButtonPointerClickCallback);
            view.galleryPageManager.SetupODEPixivImagesScrollView(storedDataValue.pixivSpriteList, GalleryPageODEImagesScrollViewImageButtonPointerClickCallback);
            view.galleryPageManager.SetupODEScopeButtonList(fontAsset, textContent.galleryPage.oDEScopeButtonList, GalleryPageODEScopeButtonListScopeButtonPointerClickCallback);
            view.galleryPageManager.SetupODESteinsGate0ImagesScrollView(storedDataValue.steinsGate0SpriteList, GalleryPageODEImagesScrollViewImageButtonPointerClickCallback);
            view.galleryPageManager.SetupODESteinsGateDarlingImagesScrollView(storedDataValue.steinsGateDaringSpriteList, GalleryPageODEImagesScrollViewImageButtonPointerClickCallback);
            view.galleryPageManager.SetupODESteinsGateImagesScrollView(storedDataValue.steinsGateSpriteList, GalleryPageODEImagesScrollViewImageButtonPointerClickCallback);
            view.galleryPageManager.SetupODESteinsGatePhenogramImagesScrollView(storedDataValue.steinsGatePhenogramSpriteList, GalleryPageODEImagesScrollViewImageButtonPointerClickCallback);            
            view.galleryPageManager.SetupOSEBackButton(GalleryPageOSEBackButtonPointerClickCallback);
            view.galleryPageManager.SetupUSEBackground();

            view.galleryPageManager.SetDisplayScope(galleryPageValue.galleryPageScopeOption);
        }

        /* ----- Gallery Page: Move In Process ----- */

        private IEnumerator GalleryPageMoveInProcess()
        {
            Debug.Log("----- Gallery Page: Move In Process -----");

            bool isGalleryPageMoveInFinished = false;

            view.galleryPageManager.PlayGalleryPageMoveInTimeline(() => isGalleryPageMoveInFinished = true);

            yield return new WaitUntil(() => isGalleryPageMoveInFinished);
        }

        /* ----- Gallery Page: Move Out Process ----- */

        private IEnumerator GalleryPageMoveOutProcess()
        {
            Debug.Log("----- Gallery Page: Move Out Process -----");

            bool isGalleryPageMoveOutFinished = false;

            view.galleryPageManager.PlayGalleryPageMoveOutTimeline(() => isGalleryPageMoveOutFinished = true);

            yield return new WaitUntil(() => isGalleryPageMoveOutFinished);
        }

        /* ----- Gallery Page: Exit Process ----- */

        private IEnumerator GalleryPageExitProcess()
        {
            Debug.Log("----- Gallery Page: Exit Process -----");

            if (galleryPageValue.isGoToHomePage == true)
            {
                GoToPage(PageOption.HomePage);
            }

            yield return null;
        }

        /* ----- Gallery Page: User Input Process (Page Callback Function)----- */

        private void GalleryPageOSEBackButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (galleryPageValue.isUserInputProcessFinished != true)
            {
                galleryPageValue.isUserInputProcessFinished = true;
                galleryPageValue.isGoToHomePage = true;
            }
        }

        private void GalleryPageODEImagesScrollViewImageButtonPointerClickCallback(Sprite sprite)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (galleryPageValue.isUserInputProcessFinished != true)
            {
                GalleryPageOpenZoomImagePopup(sprite);
                galleryPageValue.zoomingSprite = sprite;
            }
        }

        private void GalleryPageODEScopeButtonListScopeButtonPointerClickCallback(GalleryPageScopeOption galleryPageScopeOption)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (galleryPageValue.isUserInputProcessFinished != true)
            {
                // If Click Different Scope, Change Scope
                if (galleryPageValue.galleryPageScopeOption != galleryPageScopeOption)
                {
                    view.galleryPageManager.SetDisplayScope(galleryPageScopeOption);
                    galleryPageValue.galleryPageScopeOption = galleryPageScopeOption;
                }
            }
        }

        /* ----- Gallery Page: User Input Process (Popup Callback Function)----- */

        private void GalleryPageZoomImagePopupOSECrossButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            view.zoomImagePopupManager.PlayZoomImagePopupMoveOutTimeline(null);
        }

        private void GalleryPageZoomImagePopupOSELeftButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Get Sprite List
            List<Sprite> spriteList = GalleryPageGetCurrentScopeSpriteList(galleryPageValue.galleryPageScopeOption);

            // Get Current Sprite Index
            int currentSpriteIndex = spriteList.FindIndex(x => x.name == galleryPageValue.zoomingSprite.name);

            // Get Next Sprite Index
            int newSpriteIndex = currentSpriteIndex - 1;
            if (newSpriteIndex < 0)
            {
                newSpriteIndex = spriteList.Count - 1;
            }

            // Get Next Sprite
            Sprite newSprite = spriteList[newSpriteIndex];

            // Update Page Value
            galleryPageValue.zoomingSprite = newSprite;

            // Update Popup
            view.zoomImagePopupManager.UpdateImage(newSprite);
        }

        private void GalleryPageZoomImagePopupOSERightButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Get Sprite List
            List<Sprite> spriteList = GalleryPageGetCurrentScopeSpriteList(galleryPageValue.galleryPageScopeOption);
            
            // Get Current Sprite Index
            int currentSpriteIndex = spriteList.FindIndex(x=>x.name == galleryPageValue.zoomingSprite.name);
            
            // Get Next Sprite Index
            int newSpriteIndex = currentSpriteIndex + 1;
            if(newSpriteIndex > spriteList.Count - 1)
            {
                newSpriteIndex = 0;
            }

            // Get Next Sprite
            Sprite newSprite = spriteList[newSpriteIndex];

            // Update Page Value
            galleryPageValue.zoomingSprite = newSprite;

            // Update Popup
            view.zoomImagePopupManager.UpdateImage(newSprite);
        }

        /* ----- Gallery Page: User Input Process (Support Function)----- */

        private void GalleryPageOpenZoomImagePopup(Sprite sprite)
        {
            // Init Popup Element
            view.zoomImagePopupManager.InitElements();

            // Setup Popup Element
            view.zoomImagePopupManager.SetupOSECrossButton(GalleryPageZoomImagePopupOSECrossButtonPointerClickCallback);
            view.zoomImagePopupManager.SetupOSELeftButton(GalleryPageZoomImagePopupOSELeftButtonPointerClickCallback);
            view.zoomImagePopupManager.SetupOSERightButton(GalleryPageZoomImagePopupOSERightButtonPointerClickCallback);
            view.zoomImagePopupManager.SetupUDEZoomImage(sprite);

            // Move In Popup
            view.zoomImagePopupManager.PlayZoomImagePopupMoveInTimeline(null);
        }

        private List<Sprite> GalleryPageGetCurrentScopeSpriteList(GalleryPageScopeOption galleryPageScopeOption)
        {
            switch (galleryPageScopeOption)
            {
                case GalleryPageScopeOption.Other:
                    return storedDataValue.otherSpriteList;
                case GalleryPageScopeOption.Pixiv:
                    return storedDataValue.pixivSpriteList;
                    case GalleryPageScopeOption.SteinsGate:
                    return storedDataValue.steinsGateSpriteList;
                case GalleryPageScopeOption.SteinsGate0:
                    return storedDataValue.steinsGate0SpriteList;
                case GalleryPageScopeOption.SteinsGateDaring:
                    return storedDataValue.steinsGateDaringSpriteList;
                case GalleryPageScopeOption.SteinsGatePhenogram:
                    return storedDataValue.steinsGatePhenogramSpriteList;
                default:
                    Debug.LogError("<color=red>----- Gallery Page Scope Option: " + galleryPageScopeOption + ", Not Found -----</color>");
                    return null;
            }
        }


        #endregion

        #region Page Function - Music Page

        private IEnumerator MusicPage()
        {
            Debug.Log("----- Music Page -----");

            // Enter process
            yield return StartCoroutine(MusicPageEnterProcess());

            // Move in process
            yield return StartCoroutine(MusicPageMoveInProcess());

            // User input process
            Debug.Log("----- Music Page: User Response Process -----"); 
            yield return new WaitUntil(() => musicPageValue.isUserInputProcessFinished == true);

            // Move out process
            yield return StartCoroutine(MusicPageMoveOutProcess());

            // Exit process
            yield return StartCoroutine(MusicPageExitProcess());
        }

        /* ----- Music Page: Enter Process ----- */

        private IEnumerator MusicPageEnterProcess()
        {
            Debug.Log("----- Music Page: Enter Process -----");

            // Init Page Value
            MusicPageEnterProcessInitPageValue();

            // Init Elements
            MusicPageEnterProcessInitElements();

            // Setup Elements
            MusicPageEnterProcessSetupElements();

            yield return null;
        }

        private void MusicPageEnterProcessInitPageValue()
        {
            musicPageValue = new MusicPageValue();
        }

        private void MusicPageEnterProcessInitElements()
        {
            view.musicPageManager.InitElements();
        }

        private void MusicPageEnterProcessSetupElements()
        {
            musicPageValue.showingAudioClipList = storedDataValue.audioList;

            view.musicPageManager.SetupODEMusicControlBar(fontAsset, textContent.musicPage.oDEMusicControlBar, musicPageValue.isPlaying, musicPageValue.isLoop, musicPageValue.isRandom, MusicPageODEMusicControlBarLoopButtonPointerClickCallback, MusicPageODEMusicControlBarRandomButtonPointerClickCallback,
                MusicPageODEMusicControlBarPreviousButtonPointerClickCallback, MusicPageODEMusicControlBarNextButtonPointerClickCallback, MusicPageODEMusicControlBarPlayButtonPointerClickCallback, MusicPageODEMusicControlBarProgressBarValueChangeCallback, MusicPageODEMusicControlBarProgressBarPointerDownCallback, MusicPageODEMusicControlBarProgressBarPointerUpCallback);
            view.musicPageManager.SetupODEMusicScrollView(fontAsset, textContent.musicPage.oDEMusicScrollViewMusicSlot, musicPageValue.showingAudioClipList, MusicPageODEMusicScrollViewMusicSlotButtonPointerClickCallback);
            view.musicPageManager.SetupODESearchDataEntry(fontAsset, textContent.musicPage.oDESearchDataEntry, MusicPageODESearchDataEntryValueChangeCallback);
            view.musicPageManager.SetupODESortingButton(fontAsset, textContent.musicPage.oDESortingButton, MusicPageODESortingButtonPointerClickCallback);
            view.musicPageManager.SetupODESortingPanal(fontAsset, textContent.musicPage.oDESortingPanal, MusicPageSortingOption.Name, MusicPageODESortingPanalPointerClickCallback, MusicPageODESortingPanalNameButtonPointerClickCallback, MusicPageODESortingPanalLengthButtonPointerClickCallback);
            view.musicPageManager.SetupOSEBackButton(MusicPageOSEBackButtonPointerClickCallback);
            view.musicPageManager.SetupUDEMusicPlayer(MusicPageUDEMusicPlayerAudioPlayingCallback, MusicPageUDEMusicPlayerAudioFinishedCallback);
            view.musicPageManager.SetupUSEBackground();
        }

        /* ----- Music Page: Move In Process ----- */

        private IEnumerator MusicPageMoveInProcess()
        {
            Debug.Log("----- Music Page: Move In Process -----");

            bool isMusicPageMoveInFinished = false;

            view.musicPageManager.PlayMusicPageMoveInTimeline(() => isMusicPageMoveInFinished = true);

            yield return new WaitUntil(() => isMusicPageMoveInFinished);
        }

        /* ----- Music Page: Move Out Process ----- */

        private IEnumerator MusicPageMoveOutProcess()
        {
            Debug.Log("----- Music Page: Move Out Process -----");

            bool isMusicPageMoveOutFinished = false;

            view.musicPageManager.PlayMusicPageMoveOutTimeline(() => isMusicPageMoveOutFinished = true);

            yield return new WaitUntil(() => isMusicPageMoveOutFinished);
        }

        /* ----- Music Page: Exit Process ----- */

        private IEnumerator MusicPageExitProcess()
        {
            Debug.Log("----- Music Page: Exit Process -----");

            if (musicPageValue.isGoToHomePage == true)
            {
                GoToPage(PageOption.HomePage);
            }

            yield return null;
        }

        /* ----- Music Page: User Input Process (Page Callback Function)----- */

        private void MusicPageUDEMusicPlayerAudioPlayingCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                view.musicPageManager.UpdateProgressBarValue(textContent.musicPage.oDEMusicControlBar, view.musicPageManager.GetCurrentTime(), musicPageValue.playingAudio.length);
            }
        }

        private void MusicPageUDEMusicPlayerAudioFinishedCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                // If Looping, Loop The Song
                if (musicPageValue.isLoop)
                {
                    view.musicPageManager.SetAudioTime(textContent.musicPage.oDEMusicControlBar, 0f, musicPageValue.playingAudio.length);
                    view.musicPageManager.ResumeAudio();
                }
                // Else, Play Next Song
                else
                {
                    MusicPageODEMusicControlBarNextButtonPointerClickCallback();
                }
            }
        }

        private void MusicPageODEMusicControlBarLoopButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                musicPageValue.isLoop = !musicPageValue.isLoop;
                view.musicPageManager.SetIsLoop(musicPageValue.isLoop);
            }
        }

        private void MusicPageODEMusicControlBarRandomButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                musicPageValue.isRandom = !musicPageValue.isRandom;
                view.musicPageManager.SetIsRandom(musicPageValue.isRandom);
            }
        }

        private void MusicPageODEMusicControlBarPreviousButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                // If Playing Audio List == null, Get Current List
                if(musicPageValue.playingAudioClipList == null)
                {
                    musicPageValue.playingAudioClipList = musicPageValue.showingAudioClipList;
                }

                if (musicPageValue.playingAudioClipList.Count>0)
                {
                    // Get New Audio
                    AudioClip newAudio = null;
                    if (musicPageValue.playingAudio == null)
                    {
                        newAudio = musicPageValue.playingAudioClipList[0];
                    }
                    else
                    {
                        int currentMusicIndex = musicPageValue.playingAudioClipList.FindIndex(x => x == musicPageValue.playingAudio);
                        int newAudioIndex = currentMusicIndex - 1;
                        if (newAudioIndex < 0) 
                        {
                            newAudioIndex = musicPageValue.playingAudioClipList.Count - 1;
                        }
                        newAudio = musicPageValue.playingAudioClipList[newAudioIndex];
                    }

                    // Update Page Value
                    musicPageValue.playingAudio = newAudio;
                    musicPageValue.isPlaying = true;

                    // Play Audio
                    view.musicPageManager.SetAudioTime(textContent.musicPage.oDEMusicControlBar, 0f, musicPageValue.playingAudio.length);
                    view.musicPageManager.PlayAudio(textContent.musicPage.oDEMusicControlBar, musicPageValue.playingAudio);
                }
            }
        }

        private void MusicPageODEMusicControlBarNextButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                // If Playing Audio List == null, Get Current List
                if (musicPageValue.playingAudioClipList == null)
                {
                    musicPageValue.playingAudioClipList = musicPageValue.showingAudioClipList;
                }

                if (musicPageValue.playingAudioClipList.Count > 0)
                {
                    // Get New Audio
                    AudioClip newAudio = null;
                    if (musicPageValue.playingAudio == null)
                    {
                        newAudio = musicPageValue.playingAudioClipList[0];
                    }
                    else
                    {
                        if (musicPageValue.isRandom == true)
                        {
                            // If Only Have One Song In List, Play It
                            if(musicPageValue.playingAudioClipList.Count == 1)
                            {
                                newAudio = musicPageValue.playingAudio;
                            }
                            // Else Random Another Song
                            else
                            {
                                List<AudioClip> newRandomList = new List<AudioClip>(musicPageValue.playingAudioClipList);
                                newRandomList.Remove(musicPageValue.playingAudio);

                                int newAudioIndex = UnityEngine.Random.Range(0, newRandomList.Count -1);
                                newAudio = newRandomList[newAudioIndex];
                            }
                        }
                        else
                        {
                            int currentMusicIndex = musicPageValue.playingAudioClipList.FindIndex(x => x == musicPageValue.playingAudio);
                            int newAudioIndex = currentMusicIndex + 1;
                            if (newAudioIndex > musicPageValue.playingAudioClipList.Count - 1)
                            {
                                newAudioIndex = 0;
                            }

                            newAudio = musicPageValue.playingAudioClipList[newAudioIndex];
                        }
                    }

                    // Update Page Value
                    musicPageValue.playingAudio = newAudio;
                    musicPageValue.isPlaying = true;

                    // Play Audio
                    view.musicPageManager.SetAudioTime(textContent.musicPage.oDEMusicControlBar, 0f, musicPageValue.playingAudio.length);
                    view.musicPageManager.PlayAudio(textContent.musicPage.oDEMusicControlBar, musicPageValue.playingAudio); 
                }
            }
        }

        private void MusicPageODEMusicControlBarPlayButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                if(musicPageValue.isPlaying == true)
                {
                    musicPageValue.isPlaying = false ;
                    view.musicPageManager.PauseAudio();
                }
                else
                {
                    // If Playing Audio List == null, Get Current List
                    if (musicPageValue.playingAudioClipList == null)
                    {
                        musicPageValue.playingAudioClipList = musicPageValue.showingAudioClipList;
                    }

                    if (musicPageValue.playingAudioClipList.Count > 0 )
                    {
                        // If No Playing Audio, Play New Audio
                        if (musicPageValue.playingAudio == null)
                        {
                            // Get New Audio
                            AudioClip newAudio = musicPageValue.playingAudioClipList[0];

                            // Update Page Value
                            musicPageValue.playingAudio = newAudio;
                            musicPageValue.isPlaying = true;

                            // Play Audio
                            view.musicPageManager.SetAudioTime(textContent.musicPage.oDEMusicControlBar, 0f, musicPageValue.playingAudio.length);
                            view.musicPageManager.PlayAudio(textContent.musicPage.oDEMusicControlBar, musicPageValue.playingAudio);
                        }
                        // Else Resume Audio
                        else
                        {
                            musicPageValue.isPlaying = true;
                            view.musicPageManager.ResumeAudio();
                        }
                    }
                }
            }
        }

        private void MusicPageODEMusicControlBarProgressBarValueChangeCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                view.musicPageManager.SetAudioTime(textContent.musicPage.oDEMusicControlBar, view.musicPageManager.GetProgressBarValue(), musicPageValue.playingAudio.length);         
            }
        }

        private void MusicPageODEMusicControlBarProgressBarPointerDownCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                if (musicPageValue.playingAudio != null)
                {
                    musicPageValue.isPlaying = false;
                    view.musicPageManager.PauseAudio();
                }
            }
        }

        private void MusicPageODEMusicControlBarProgressBarPointerUpCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                if (musicPageValue.playingAudio != null)
                {
                    musicPageValue.isPlaying = true;
                    view.musicPageManager.ResumeAudio();
                }
            }
        }

        private void MusicPageODEMusicScrollViewMusicSlotButtonPointerClickCallback(AudioClip audioClip)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                musicPageValue.playingAudioClipList = musicPageValue.showingAudioClipList;                
                musicPageValue.playingAudio = audioClip;
                view.musicPageManager.SetAudioTime(textContent.musicPage.oDEMusicControlBar, 0f, musicPageValue.playingAudio.length);
                view.musicPageManager.PlayAudio(textContent.musicPage.oDEMusicControlBar, audioClip);
            }
        }

        private void MusicPageODESearchDataEntryValueChangeCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                if (string.IsNullOrEmpty(view.musicPageManager.GetSearchContent()))
                {
                    musicPageValue.showingAudioClipList = storedDataValue.audioList;
                    view.musicPageManager.UpdateScrollView(fontAsset, textContent.musicPage.oDEMusicScrollViewMusicSlot, musicPageValue.showingAudioClipList, MusicPageODEMusicScrollViewMusicSlotButtonPointerClickCallback);
                }
                else
                {
                    List<AudioClip> newAudioClipList = new List<AudioClip>();
                    foreach (AudioClip clip in storedDataValue.audioList)
                    {
                        string clipName = clip.name.ToUpper();
                        if (clipName.Contains(view.musicPageManager.GetSearchContent().ToUpper()))
                        {
                            newAudioClipList.Add(clip);
                        }
                    }
                    musicPageValue.showingAudioClipList = newAudioClipList;

                    // Update ScrollView
                    view.musicPageManager.UpdateScrollView(fontAsset, textContent.musicPage.oDEMusicScrollViewMusicSlot, musicPageValue.showingAudioClipList, MusicPageODEMusicScrollViewMusicSlotButtonPointerClickCallback);
                }
            }
        }

        private void MusicPageODESortingButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                view.musicPageManager.ShowSortingPanel(musicPageValue.musicPageSortingOption);
            }
        }

        private void MusicPageODESortingPanalPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                view.musicPageManager.CloseSortingPanel();
            }
        }

        private void MusicPageODESortingPanalNameButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                musicPageValue.musicPageSortingOption = MusicPageSortingOption.Name;
                view.musicPageManager.CloseSortingPanel();

                musicPageValue.showingAudioClipList = musicPageValue.showingAudioClipList.OrderBy(x => x.name).ToList();
                view.musicPageManager.UpdateScrollView(fontAsset, textContent.musicPage.oDEMusicScrollViewMusicSlot, musicPageValue.showingAudioClipList, MusicPageODEMusicScrollViewMusicSlotButtonPointerClickCallback);
            }
        }

        private void MusicPageODESortingPanalLengthButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                musicPageValue.musicPageSortingOption = MusicPageSortingOption.Length;
                view.musicPageManager.CloseSortingPanel();

                musicPageValue.showingAudioClipList = musicPageValue.showingAudioClipList.OrderBy(x => x.length).ToList();
                view.musicPageManager.UpdateScrollView(fontAsset, textContent.musicPage.oDEMusicScrollViewMusicSlot, musicPageValue.showingAudioClipList, MusicPageODEMusicScrollViewMusicSlotButtonPointerClickCallback);
            }
        }

        private void MusicPageOSEBackButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (musicPageValue.isUserInputProcessFinished != true)
            {
                musicPageValue.isUserInputProcessFinished = true;
                musicPageValue.isGoToHomePage = true;
            }
        }

        #endregion

        #region Page Function - Sentence Page

        private IEnumerator SentencePage()
        {
            Debug.Log("----- Sentence Page -----");

            // Enter process
            yield return StartCoroutine(SentencePageEnterProcess());

            // Move in process
            yield return StartCoroutine(SentencePageMoveInProcess());

            // User input process
            yield return new WaitUntil(() => sentencePageValue.isUserInputProcessFinished == true);

            // Move out process
            yield return StartCoroutine(SentencePageMoveOutProcess());

            // Exit process
            yield return StartCoroutine(SentencePageExitProcess());
        }

        /* ----- Sentence Page: Enter Process ----- */

        private IEnumerator SentencePageEnterProcess()
        {
            Debug.Log("----- Sentence Page: Enter Process -----");

            // Init Page Value
            SentencePageEnterProcessInitPageValue();

            // Init Elements
            SentencePageEnterProcessInitElements();

            // Setup Elements
            SentencePageEnterProcessSetupElements();

            yield return null;
        }

        private void SentencePageEnterProcessInitPageValue()
        {
            sentencePageValue = new SentencePageValue();
        }

        private void SentencePageEnterProcessInitElements()
        {
            view.sentencePageManager.InitElements();
        }

        private void SentencePageEnterProcessSetupElements()
        {
            view.sentencePageManager.SetupODESentenceScrollView(fontAsset, textContent.sentencePage.sentenceList, SentencePageODESentenceScrollViewSentenceSlotPointerClickCallback);
            view.sentencePageManager.SetupOSEBackButton(SentencePageOSEBackButtonPointerClickCallback);
            view.sentencePageManager.SetupUDETitle(fontAsset, textContent.sentencePage.uDETitle);
            view.sentencePageManager.SetupUSEBackground();
        }

        /* ----- Sentence Page: Move In Process ----- */

        private IEnumerator SentencePageMoveInProcess()
        {
            Debug.Log("----- Sentence Page: Move In Process -----");

            bool isSentencePageMoveInFinished = false;

            view.sentencePageManager.PlaySentencePageMoveInTimeline(() => isSentencePageMoveInFinished = true);

            yield return new WaitUntil(() => isSentencePageMoveInFinished);
        }

        /* ----- Sentence Page: Move Out Process ----- */

        private IEnumerator SentencePageMoveOutProcess()
        {
            Debug.Log("----- Sentence Page: Move In Process -----");

            bool isSentencePageMoveOutFinished = false;

            view.sentencePageManager.PlaySentencePageMoveOutTimeline(() => isSentencePageMoveOutFinished = true);

            yield return new WaitUntil(() => isSentencePageMoveOutFinished);
        }

        /* ----- Sentence Page: Exit Process ----- */

        private IEnumerator SentencePageExitProcess()
        {
            Debug.Log("----- Sentence Page: Exit Process -----");

            if (sentencePageValue.isGoToHomePage == true)
            {
                GoToPage(PageOption.HomePage);
            }

            yield return null;
        }

        /* ----- Sentence Page: User Input Process (Page Callback Function)----- */

        private void SentencePageODESentenceScrollViewSentenceSlotPointerClickCallback(TextContentBase.SentencePage.UDESentenceScrollViewSentenceSlot sentenceSlot)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (sentencePageValue.isUserInputProcessFinished != true)
            {
                // Update Text Content
                GameManager.TextContentBase.LargePopup updatedTextContent = textContent.sentencePopup;
                updatedTextContent.uDEContent.text001 = updatedTextContent.uDEContent.text001.Replace("{0}", sentenceSlot.contentSentenceText001).Replace("{1}", sentenceSlot.contentSpeakerText001);

                gameManager.OpenLargePopup("SentencePopup", fontAsset, updatedTextContent, SentencePageSentencePopupPrimaryButtonPointerClickCallback, null, null);
            }
        }

        private void SentencePageOSEBackButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            if (sentencePageValue.isUserInputProcessFinished != true)
            {
                sentencePageValue.isUserInputProcessFinished = true;
                sentencePageValue.isGoToHomePage = true;
            }
        }

        /* ----- Sentence Page: User Input Process (Popup Callback Function)----- */

        private void SentencePageSentencePopupPrimaryButtonPointerClickCallback()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            gameManager.CloseLargePopup("SentencePopup", null);
        }

        #endregion

        #region Page Function - Intro Page

        private IEnumerator IntroPage()
        {
            Debug.Log("----- Intro Page -----");

            // Enter process
            yield return StartCoroutine(IntroPageEnterProcess());

            // Move in process
            yield return StartCoroutine(IntroPageMoveInProcess());

            // User input process
            yield return new WaitUntil(() => introPageValue.isUserInputProcessFinished == true);

            // Move out process
            yield return StartCoroutine(IntroPageMoveOutProcess());

            // Exit process
            yield return StartCoroutine(IntroPageExitProcess());
        }

        /* ----- Intro Page: Enter Process ----- */

        private IEnumerator IntroPageEnterProcess()
        {
            Debug.Log("----- Intro Page: Enter Process -----");

            // Init Page Value
            IntroPageEnterProcessInitPageValue();

            // Init Elements
            IntroPageEnterProcessInitElements();

            // Setup Elements
            IntroPageEnterProcessSetupElements();

            yield return null;
        }

        private void IntroPageEnterProcessInitPageValue()
        {
            introPageValue = new IntroPageValue();
        }

        private void IntroPageEnterProcessInitElements()
        {
            view.introPageManager.InitElements();
        }

        private void IntroPageEnterProcessSetupElements()
        {

        }

        /* ----- Intro Page: Move In Process ----- */

        private IEnumerator IntroPageMoveInProcess()
        {
            Debug.Log("----- Intro Page: Move In Process -----");

            bool isIntroPageMoveInFinished = false;

            view.introPageManager.PlayIntroPageMoveInTimeline(() => isIntroPageMoveInFinished = true);

            yield return new WaitUntil(() => isIntroPageMoveInFinished);
        }

        /* ----- Intro Page: Move Out Process ----- */

        private IEnumerator IntroPageMoveOutProcess()
        {
            Debug.Log("----- Intro Page: Move In Process -----");

            bool isIntroPageMoveOutFinished = false;

            view.introPageManager.PlayIntroPageMoveOutTimeline(() => isIntroPageMoveOutFinished = true);

            yield return new WaitUntil(() => isIntroPageMoveOutFinished);
        }

        /* ----- Intro Page: Exit Process ----- */

        private IEnumerator IntroPageExitProcess()
        {
            Debug.Log("----- Intro Page: Exit Process -----");

            if (introPageValue.isGoToHomePage == true)
            {
                GoToPage(PageOption.HomePage);
            }

            yield return null;
        }

        /* ----- Intro Page: User Input Process (Page Callback Function)----- */

        #endregion

        #endregion

        #region Game Manager Helper Function

        public void RunEnterSceneMode(HomeSceneOperationValue operationValue)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Get Operation Value
            this.operationValue = operationValue;

            currentMode = ControllerModeOption.EnterSceneMode;
            Main();
        }

        public void RunExitSceneMode()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            currentMode = ControllerModeOption.ExitSceneMode;
            Main();
        }

        public void RunRunSceneMode()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            currentMode = ControllerModeOption.RunSceneMode;
            Main();
        }
        
        #endregion
    }
}