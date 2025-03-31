using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisibleBar : MonoBehaviour
{
    [SerializeField] private Image invisibleBar;
    [SerializeField] private float invisiblePoints = 2f;
    void Update()
    {
        invisiblePoints = Mathf.Clamp(invisiblePoints, 0f, 2f);
        if (PlayerMovement.isVisible == true)
        {
            invisiblePoints = 2f;
            invisibleBar.fillAmount = (invisiblePoints - Time.captureDeltaTime) / 2;
        }
        else
        {
            invisiblePoints = 0f;
            invisibleBar.fillAmount = (invisiblePoints + Time.captureDeltaTime) / 2;
        }
    }
}
