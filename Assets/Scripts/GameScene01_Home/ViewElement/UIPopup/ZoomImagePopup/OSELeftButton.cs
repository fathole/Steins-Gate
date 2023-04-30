using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene.UIPopup.ZoomImagePopup
{
    public class OSELeftButton : ClickableObjectBase
    {
        #region Declaration

        // Comment: Nothing Declaration

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init action
            onPointerClickCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(Action onPointerClickCallback)
        {
            // Setup action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}