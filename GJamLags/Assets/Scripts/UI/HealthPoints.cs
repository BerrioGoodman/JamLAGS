using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoints : MonoBehaviour
{
    [Header("Healt Points")]
    public static float healthPoints = 4f;
    [SerializeField] private Image healtView;
    private void Update()
    {
        healthPoints = Mathf.Clamp(healthPoints, 0, 4f);
        healtView.fillAmount = healthPoints / 4;
    }
}
