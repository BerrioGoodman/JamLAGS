using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SurviveFinalFigth", 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SurviveFinalFigth() 
    {
        SceneManager.LoadScene("FinalBoss");
    }

}
