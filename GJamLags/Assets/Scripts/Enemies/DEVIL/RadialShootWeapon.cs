using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialShootWeapon : MonoBehaviour
{
    [SerializeField] private RadialShootPattern shotPattern;
    private bool onShotPattern = false;

    private void Update()
    {
        if(onShotPattern)
            return;

        StartCoroutine(ExecuteRadialShotPattern(shotPattern));
    }

    private IEnumerator ExecuteRadialShotPattern(RadialShootPattern pattern) 
    {
        onShotPattern = true;

        int lap = 0;
        Vector2 aimDirection = transform.up;
        Vector2 center = transform.position;

        yield return new WaitForSeconds(pattern.StartWait);

        while (lap < pattern.Repetitions) 
        {
            for (int i = 0; i < pattern.PatternSetting.Length; i++) 
            {
                ShootAttack.RadialShoot(center, aimDirection, pattern.PatternSetting[i]);
                yield return new WaitForSeconds(pattern.PatternSetting[i].CooldownAfterShot);
            }
            lap++;
        }

        yield return new WaitForSeconds(pattern.EndWait);


        onShotPattern = false;
    }
}
