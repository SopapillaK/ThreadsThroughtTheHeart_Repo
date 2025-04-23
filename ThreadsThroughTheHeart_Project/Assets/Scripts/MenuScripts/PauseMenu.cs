using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    bool gameIsPaused = false;
    bool inSettings = false;
    bool inConOrCred = false;
    [Header("Menus")]
    public GameObject pausePanel;
    public GameObject settingPanel;
    public GameObject creditsPanel;
    public GameObject controlsPanel;
    public GameObject loseMenuScreen;
    public GameObject winMenuScreen;
    [Header("Audio")]
    public AudioMixer negThoughtMixer;
    public AudioMixer posThoughtMixer;
    [Header("MouseSensitivity")]
    public Slider mouseSensitivitySlider;



    void Update()
    {
        if (loseMenuScreen.activeSelf || winMenuScreen.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
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
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        MuteAudio();
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
        UnmuteAudio();
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

    public void ToHeartHub()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HeartHub");
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

    void MuteAudio()
    {
        negThoughtMixer.SetFloat("NegThoughtVolume", -80f);
        posThoughtMixer.SetFloat("PosThoughtVolume", -80f);
    }

    void UnmuteAudio()
    {
        negThoughtMixer.SetFloat("NegThoughtVolume", 0f);
        posThoughtMixer.SetFloat("PosThoughtVolume", 0f);
    }
}
