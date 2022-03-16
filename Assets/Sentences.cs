using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sentences : MonoBehaviour
{
    public GameObject SentencePrefab;
    public GameObject SentenceContent;

    private void Start()
    {
        TextAsset sentencesTextAsset = Resources.Load<TextAsset>("TextAssets/Sentences");
        string[] sentencesData = sentencesTextAsset.text.Split(new char[] { '\n' });
        for (int i = 0; i < sentencesData.Length; i++)
        {
            GameObject SentenceGO = GameObject.Instantiate(SentencePrefab);
            SentenceGO.transform.SetParent(SentenceContent.transform);
            string [] rows = sentencesData[i].Split(new char[] { ',' });
            SentenceGO.transform.Find("txtSentence").GetComponent<Text>().text = rows[0];
            SentenceGO.transform.Find("txtName").GetComponent<Text>().text = rows[1];
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(GameObject.FindObjectOfType<LoadingSystem>().LoadScene(0));
        }
    }
    public void btnSetting()
    {
        GameObject.FindObjectOfType<Setting>().OpenSetting();
    }
}
