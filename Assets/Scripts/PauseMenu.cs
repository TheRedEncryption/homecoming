using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;   // Freeze gameplay
        isPaused = true;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;   // Resume gameplay
        isPaused = false;
    }
}

