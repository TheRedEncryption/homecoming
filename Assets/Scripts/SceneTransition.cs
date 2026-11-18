using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneTransition : MonoBehaviour 
{
    //public Animator transition; //TODO: implement

    public float transitionTime = 1f;

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // in case game is paused
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        //transition.SetTrigger("Start"); //TODO: implement
        Debug.Log("Loading Scene: " + sceneName);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
