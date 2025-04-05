using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void Start()
    {
        Invoke("Victory", 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Victory()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
