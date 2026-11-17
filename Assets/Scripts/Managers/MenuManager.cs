using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public SceneTransition transition;
    [SerializeField] private string gameSceneName = "School";
    [SerializeField] private string optionsSceneName = "Options";
    [SerializeField] private string creditsSceneName = "Credits";

    public void NewGame()
    {
        transition.LoadScene(gameSceneName);
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
    }
    public void LoadGame()
    {
        Debug.Log("LoadGame");
    }
    public void Options()
    {
        SceneManager.LoadScene(optionsSceneName);
    }
    public void Credits()
    {
        SceneManager.LoadScene(creditsSceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
