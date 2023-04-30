using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.GalleryPage
{
    public class ODEScopeButtonList : MonoBehaviour
    {
        #region Declaration

        [Header("Child")]
        [SerializeField]
        private ODEScopeButtonListScopeButton steinsGateButton;
        [SerializeField]
        private ODEScopeButtonListScopeButton steinsGate0Button;
        [SerializeField]
        private ODEScopeButtonListScopeButton steinsGatePhenogram;
        [SerializeField]
        private ODEScopeButtonListScopeButton steinsGateDaringButton;
        [SerializeField]
        private ODEScopeButtonListScopeButton pixivButton;
        [SerializeField]
        private ODEScopeButtonListScopeButton otherButton;

        [Header("Text")]
        [SerializeField]
        private TMP_Text steinsGateButtonContentText001;
        [SerializeField]
        private TMP_Text steinsGate0ButtonContentText001;
        [SerializeField]
        private TMP_Text steinsGatePhenogramContentText001;
        [SerializeField]
        private TMP_Text steinsGateDaringButtonnContentText001;
        [SerializeField]
        private TMP_Text pixivButtonContentText001;
        [SerializeField]
        private TMP_Text otherButtonContentText001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Text
            steinsGateButtonContentText001.text = "";
            steinsGate0ButtonContentText001.text = "";
            steinsGatePhenogramContentText001.text = "";
            steinsGateDaringButtonnContentText001.text = "";
            pixivButtonContentText001.text = "";
            otherButtonContentText001.text = "";

            // Init child
            steinsGateButton.InitElement();
            steinsGate0Button.InitElement();
            steinsGatePhenogram.InitElement();
            steinsGateDaringButton.InitElement();
            pixivButton.InitElement();
            otherButton.InitElement();
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.GalleryPage.ODEScopeButtonList textContent, Action<GalleryPageScopeOption> onScopeButtonPointerClickCallback)
        {
            // Setup textAsset
            steinsGateButtonContentText001.font = fontAsset;
            steinsGate0ButtonContentText001.font = fontAsset;
            steinsGatePhenogramContentText001.font = fontAsset;
            steinsGateDaringButtonnContentText001.font = fontAsset;
            pixivButtonContentText001.font = fontAsset;
            otherButtonContentText001.font = fontAsset;

            // Setup textContent
            steinsGateButtonContentText001.text = textContent.steinsGateButtonContentText001;
            steinsGate0ButtonContentText001.text = textContent.steinsGate0ButtonContentText001;
            steinsGatePhenogramContentText001.text = textContent.steinsGatePhenogramContentText001;
            steinsGateDaringButtonnContentText001.text = textContent.steinsGateDaringButtonnContentText001;
            pixivButtonContentText001.text = textContent.pixivButtonContentText001;
            otherButtonContentText001.text = textContent.otherButtonContentText001;

            // Setup Child
            steinsGateButton.SetupElement(() => { onScopeButtonPointerClickCallback(GalleryPageScopeOption.SteinsGate); });
            steinsGate0Button.SetupElement(() => { onScopeButtonPointerClickCallback(GalleryPageScopeOption.SteinsGate0); });
            steinsGatePhenogram.SetupElement(() => { onScopeButtonPointerClickCallback(GalleryPageScopeOption.SteinsGatePhenogram); });
            steinsGateDaringButton.SetupElement(() => { onScopeButtonPointerClickCallback(GalleryPageScopeOption.SteinsGateDaring); });
            pixivButton.SetupElement(() => { onScopeButtonPointerClickCallback(GalleryPageScopeOption.Pixiv); });
            otherButton.SetupElement(() => { onScopeButtonPointerClickCallback(GalleryPageScopeOption.Other); });
        }

        #endregion

        #region Main Function

        public void SetSelectedScope(GalleryPageScopeOption selectedScope)
        {
            steinsGateButton.SetSelected(selectedScope == GalleryPageScopeOption.SteinsGate);
            steinsGate0Button.SetSelected(selectedScope == GalleryPageScopeOption.SteinsGate0);
            steinsGatePhenogram.SetSelected(selectedScope == GalleryPageScopeOption.SteinsGatePhenogram);
            steinsGateDaringButton.SetSelected(selectedScope == GalleryPageScopeOption.SteinsGateDaring);
            pixivButton.SetSelected(selectedScope == GalleryPageScopeOption.Pixiv);
            otherButton.SetSelected(selectedScope == GalleryPageScopeOption.Other);
        }

        #endregion
    }
}