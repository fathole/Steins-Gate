using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void btnImage()
    {
        StartCoroutine(LoadScene(1));
    }

    public void btnMusic()
    {
        StartCoroutine(LoadScene(2));
    }

    public void btnSentence()
    {
        StartCoroutine(LoadScene(3));
    }

    public void btnInfo()
    {
        StartCoroutine(LoadScene(4));
    }

    public void btnSetting()
    {
        GameObject.FindObjectOfType<Setting>().OpenSetting();
    }

    IEnumerator LoadScene(int index)
    {
        animator.SetTrigger("LoadOtherScene");
        yield return new WaitForSeconds(2);//animation length
        SceneManager.LoadScene(index);
    }
}
