using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HomeScene.UIPopup.ZoomImagePopup
{
    public class UDEZoomImage : MonoBehaviour
    {
        #region Declaration

        [Header("Image")]
        [SerializeField] private Image image001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Image
            image001.sprite = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(Sprite sprite)
        {
            // Setup Sprite
            image001.sprite = sprite;
        }

        #endregion

        #region Main Function

        public void UpdateImage(Sprite sprite)
        {
            image001.sprite = sprite;
        }

        #endregion
    }
}