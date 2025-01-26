using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;

    public UnityEvent EventPauseGame;
    public UnityEvent EventUnpauseGame;

    [Header("References")]
    public PlayerCamera PlayerCam;

    private void Update()
    {
        PauseMenuToggle();
    }

    private void PauseMenuToggle()
    {
        if (isPaused)
        {
            PlayerCam.CursorLocked = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = false;
                UnPauseGame();
            }
        }

        else if (!isPaused)
        {
            PlayerCam.CursorLocked = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        EventPauseGame.Invoke();
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        EventUnpauseGame.Invoke();
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
