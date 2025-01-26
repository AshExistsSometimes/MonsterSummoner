using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;

    public UnityEvent OpenPauseMenu;
    public UnityEvent ClosePauseMenu;

    public UnityEvent WhenSomethingPausesGame;

    [Header("References")]
    public PlayerCamera PlayerCam;



    private void Update()
    {
        PauseMenuToggle();
        if(!isPaused)
        {
            Time.timeScale = 1.0f;
        }
    }

    private void PauseMenuToggle()
    {
        if (isPaused)
        {
            PlayerCam.CursorLocked = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = false;
                ResumeGame();
            }
        }

        else if (!isPaused)
        {
            PlayerCam.CursorLocked = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                PauseMenuOpen();
            }
        }
    }

    public void GeneralPauseGame()
    {
        isPaused = true;
        WhenSomethingPausesGame.Invoke();
        Time.timeScale = 0f;
    }

    public void PauseMenuOpen()
    {
        Time.timeScale = 0f;
        OpenPauseMenu.Invoke();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        ClosePauseMenu.Invoke();
    }


    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }

}
