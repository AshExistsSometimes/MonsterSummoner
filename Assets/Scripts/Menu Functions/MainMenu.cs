using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()// needs to be replaced with functionality to load a saved game, and a seperate function to start a new save
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.UnloadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
