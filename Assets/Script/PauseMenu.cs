using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    public GameObject pauseMenuCanvas;

    public GameObject resumeButton;

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            EventSystem.current.SetSelectedGameObject(resumeButton);
        }
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
