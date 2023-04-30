using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.MusicPage
{
    public class ODESearchDataEntry : MonoBehaviour
    {
        #region Declaration
        
        [Header("Input Field")]
        [SerializeField] private TMP_InputField searchInputField;        

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Action
            searchInputField.onValueChanged.RemoveAllListeners();

            // Init Input Field
            searchInputField.text = "";
            searchInputField.placeholder.GetComponent<TMP_Text>().text = "";            
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODESearchDataEntry textContent, Action onValueChangeCallback)
        {
            // Setup Font Asset
            searchInputField.textComponent.font = fontAsset;
            searchInputField.placeholder.GetComponent<TMP_Text>().font = fontAsset;

            // Setup Text Content
            searchInputField.placeholder.GetComponent<TMP_Text>().text = textContent.searchInputFieldPlaceHolderText001;

            // Setup Action
            searchInputField.onValueChanged.AddListener(delegate { onValueChangeCallback?.Invoke(); });
        }

        #endregion

        #region Main Function

        public string GetSearchContent()
        {
            return searchInputField.text;
        }

        #endregion
    }
}