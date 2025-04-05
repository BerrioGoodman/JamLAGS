using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsAnimation : MonoBehaviour
{
    void Start()
    {
        Invoke("GoingtoMainMenu", 39.8f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) GoingtoMainMenu();
    }
    public void GoingtoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
