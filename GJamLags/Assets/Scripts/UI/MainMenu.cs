using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Main Menu button send the player to the main menu
    public void GotoMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        PauseMenu.isPaused = false;
    }
    //Go to the credits Scene
    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1.0f;
        PauseMenu.isPaused = false;
    }
    //Start to play the videogame
    public void PlayButton()
    {
        SceneManager.LoadScene("Probe1");
        Time.timeScale = 1.0f;
        PauseMenu.isPaused = false;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
