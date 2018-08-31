using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startbutton : MonoBehaviour {

    public Animator transitionAnim;

    public void LoadScene(string name)
    {
        StartCoroutine(LoadSceneWait(name));
    }

    IEnumerator LoadSceneWait(string name)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name);
    }
}
