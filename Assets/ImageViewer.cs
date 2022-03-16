using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageViewer : MonoBehaviour
{
    public List<Sprite> imageList = new List<Sprite>();
    private GameObject selectImage;
    public GameObject selectImagePrefab;
    public GameObject ImageViewerContent;

    public GameObject BigImageViewer;
    public Image BigImage;
    private int CurrentImageIndex;

    private void Start()
    {
        #region add Image to imageList
        foreach (Sprite image in Resources.LoadAll<Sprite>("Image/Steins;Gate"))
        {
            imageList.Add(image);
        }
        foreach (Sprite image in Resources.LoadAll<Sprite>("Image/Steins;Gate 0"))
        {
            imageList.Add(image);
        }
        foreach (Sprite image in Resources.LoadAll<Sprite>("Image/Steins;Gate Phenogram"))
        {
            imageList.Add(image);
        }
        foreach (Sprite image in Resources.LoadAll<Sprite>("Image/Steins;Gate Darling"))
        {
            imageList.Add(image);
        }
        foreach (Sprite image in Resources.LoadAll<Sprite>("Image/Pixiv"))
        {
            imageList.Add(image);
        }
        foreach (Sprite image in Resources.LoadAll<Sprite>("Image/Other"))
        {
            imageList.Add(image);
        }
        #endregion
        foreach(Sprite image in imageList)
        {
            selectImage = GameObject.Instantiate(selectImagePrefab);
            selectImage.transform.SetParent(ImageViewerContent.transform);
            selectImage.GetComponent<Image>().sprite = image;
            selectImage.GetComponent<Image>().preserveAspect = true;
            selectImage.GetComponent<Button>().onClick.AddListener(delegate () { BigPhotoViewer(image); });
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (BigImageViewer.activeSelf)
            {
                BigImageViewer.SetActive(false);
            }
            else
            {
                StartCoroutine(GameObject.FindObjectOfType<LoadingSystem>().LoadScene(0));
            }
        }
    }
    private void BigPhotoViewer(Sprite sprite)
    {
        BigImageViewer.SetActive(true);
        Sprite[] spriteArray = imageList.ToArray();
        for (int i = 0; i < spriteArray.Length; i++)
        {
            if (imageList[i] == sprite)
            {
                CurrentImageIndex = i;
            }
        }
        BigImage.sprite = sprite;
        BigImage.preserveAspect = true;
    }
    public void btnNextPhoto()
    {
        CurrentImageIndex++;
        if (CurrentImageIndex > imageList.Count - 1)
        {
            CurrentImageIndex = 0;
        }
            BigImage.sprite = imageList[CurrentImageIndex];
    }
    public void btnPreviousPhoto()
    {
        CurrentImageIndex--;
        if (CurrentImageIndex < 0)
        {
            CurrentImageIndex =imageList.Count-1;
        }
        BigImage.sprite = imageList[CurrentImageIndex];
    }
    public void btnQuitBigImage()
    {
        BigImageViewer.SetActive(false);
    }
    public void btnSetting()
    {
        GameObject.FindObjectOfType<Setting>().OpenSetting();
    }
}
