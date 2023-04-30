using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.MusicPage
{
    public class ODEMusicScrollView : MonoBehaviour
    {
        #region Declaration

        [Header("Prefab")]
        [SerializeField] private ODEMusicScrollViewMusicSlot musicSlotPrefab;

        [Header("Parent")]
        [SerializeField] private Transform musicSlotParentTransform;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            foreach (Transform child in musicSlotParentTransform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODEMusicScrollViewMusicSlot textContent, List<AudioClip> audioList, Action<AudioClip> onMusicSlotPointerClickCallback)
        {
            foreach (AudioClip audio in audioList)
            {
                ODEMusicScrollViewMusicSlot musicSlot = Instantiate(musicSlotPrefab, musicSlotParentTransform);
                musicSlot.InitElement();
                musicSlot.SetupElement(fontAsset, textContent, audio.name, audio.length, ()=> { onMusicSlotPointerClickCallback(audio); });
            }
        }

        #endregion

        #region Main Function

        public void UpdateMusicScrollView(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODEMusicScrollViewMusicSlot textContent, List<AudioClip> audioList, Action<AudioClip> onMusicSlotPointerClickCallback)
        {
            // Clear Child
            foreach (Transform child in musicSlotParentTransform)
            {
                GameObject.Destroy(child.gameObject);
            }

            // Generate Music Slot
            foreach (AudioClip audio in audioList)
            {
                ODEMusicScrollViewMusicSlot musicSlot = Instantiate(musicSlotPrefab, musicSlotParentTransform);
                musicSlot.InitElement();
                musicSlot.SetupElement(fontAsset, textContent, audio.name, audio.length, () => { onMusicSlotPointerClickCallback(audio); });
            }
        }

        #endregion
    }
}