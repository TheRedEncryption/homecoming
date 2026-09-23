using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneTransition : MonoBehaviour 
{
    public Animator transition;

    public float transitionTime = 1f;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
