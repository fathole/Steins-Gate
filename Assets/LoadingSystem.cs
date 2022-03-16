using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSystem : MonoBehaviour
{
    public Animator animator;
    public IEnumerator LoadScene(int SceneIndex)
    {
        animator.SetTrigger("LoadingStart");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneIndex);
    }
}
