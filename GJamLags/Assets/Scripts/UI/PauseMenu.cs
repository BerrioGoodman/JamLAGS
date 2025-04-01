using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu Button and Panel")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;
    public static bool isPaused;
    //We stop the time and active the pause panel
    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
        pauseButton.SetActive(false);
    }
    //Resume button continue with the game and the time scale is 1f again
    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        isPaused = false;
        pauseButton.SetActive(true);
    }
    //Main Menu button send the player to the main menu
    public void GotoMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    //Go to the credits Scene
    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1.0f;
        isPaused = false;
    }
}
