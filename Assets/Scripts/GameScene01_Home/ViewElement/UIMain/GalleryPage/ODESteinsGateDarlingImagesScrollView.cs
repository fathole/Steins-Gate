using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HomeScene.UIMain.GalleryPage
{
    public class ODESteinsGateDarlingImagesScrollView : MonoBehaviour
    {
        #region Declaration

        [Header("Prefab")]
        [SerializeField] private ODEImagesScrollViewImageSlot imageSlotPrefab;

        [Header("Parent")]
        [SerializeField] private Transform imageSlotParentTransform;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            foreach (Transform child in imageSlotParentTransform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        #endregion

        #region Setup Stage

        public void SetupElement(List<Sprite> spriteList, Action<Sprite> onImageSlotPointerClickCallback)
        {
            foreach (Sprite sprite in spriteList)
            {
                ODEImagesScrollViewImageSlot imageSlot = Instantiate(imageSlotPrefab, imageSlotParentTransform);
                imageSlot.InitElement();
                imageSlot.SetupElement(sprite, ()=> { onImageSlotPointerClickCallback(sprite); });
            }

            // Setup ScrollView
            GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}