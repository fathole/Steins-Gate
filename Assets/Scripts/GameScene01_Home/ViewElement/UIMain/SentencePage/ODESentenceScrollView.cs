using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.SentencePage
{
    public class ODESentenceScrollView : MonoBehaviour
    {
        #region Declaration

        [Header("Prefab")]
        [SerializeField] private ODESentenceScrollViewSentenceSlot sentenceSlotPrefab;

        [Header("Parent")]
        [SerializeField] private Transform sentenceSlotParentTransform;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            foreach (Transform child in sentenceSlotParentTransform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, List<TextContentBase.SentencePage.UDESentenceScrollViewSentenceSlot> sentenceList, Action<TextContentBase.SentencePage.UDESentenceScrollViewSentenceSlot> onSentencePointerClickCallback)
        {
            foreach (TextContentBase.SentencePage.UDESentenceScrollViewSentenceSlot sentence in sentenceList)
            {
                ODESentenceScrollViewSentenceSlot sentenceSlot = Instantiate(sentenceSlotPrefab, sentenceSlotParentTransform);
                sentenceSlot.InitElement();
                sentenceSlot.SetupElement(fontAsset, sentence, () =>{ onSentencePointerClickCallback(sentence); });
            }
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}