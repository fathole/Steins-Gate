using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HomeScene.UIMain.GalleryPage
{
    public class ODEImagesScrollViewImageSlot : ClickableObjectBase
    {
        #region Declaration

        [Header("Image")]
        [SerializeField] private Image image;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Sprite
            image.sprite = null;

            // Init action
            onPointerClickCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(Sprite sprite, Action onPointerClickCallback)
        {
            // Setup Sprite
            image.sprite = sprite;

            // Setup Action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}