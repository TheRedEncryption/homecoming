using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public SceneTransition transition;

    public void NewGame() 
    {
        transition.LoadScene("01_Mysterious Forest");
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
        SceneManager.LoadScene("Options");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
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
