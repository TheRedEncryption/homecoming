using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Gifzem");  // replace with your scene name
    }

    public void OpenSettings()
    {
        // You can load a settings menu, show a panel, etc.
        Debug.Log("Settings menu coming soon!");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game closed.");
    }
}