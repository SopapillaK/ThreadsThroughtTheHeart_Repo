using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public bool inSettings = false;
    public bool inConOrCred = false;
    public GameObject pausePanel;
    public GameObject settingPanel;
    public GameObject creditsPanel;
    public GameObject controlsPanel;
    public GameObject loseMenuScreen;

    void Update()
    {
        if (loseMenuScreen.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    Resume();

                    if (inSettings)
                    {
                        Pause();

                        if (inConOrCred)
                        {
                            Settings();
                        }
                    }
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        inSettings = false;
        settingPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        Debug.Log("Restarting level...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Settings()
    {
        settingPanel.SetActive(true);
        inSettings = true;
        inConOrCred = false;
        pausePanel.SetActive(false);
        creditsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        inConOrCred = true;
        settingPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void Controls()
    {
        controlsPanel.SetActive(true);
        inConOrCred = true;
        settingPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
}
