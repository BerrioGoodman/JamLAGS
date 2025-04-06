using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class youDied : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Died", 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Died()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
