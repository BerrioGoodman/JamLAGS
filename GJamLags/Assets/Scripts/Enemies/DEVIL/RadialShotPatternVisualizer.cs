using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class RadialShotPatternVisualizer : MonoBehaviour
{
    [SerializeField] private RadialShootSettings testRadialShoot;
    [SerializeField] private float radius;
    [SerializeField] private Color color;
    [SerializeField, Range(0f, 5f)] private float testTime;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        DrawRadialShoot(testRadialShoot, testTime, transform.up);
    }

    private void DrawRadialShoot(RadialShootSettings settings, float lifeTime, Vector2 aimDirection) 
    {
        float angleBetweenBullets = 360f / settings.NumbersOfBullets;

        if (settings.AngleOffset != 0f || settings.PhaseOffset != 0)
            aimDirection = aimDirection.Rotate(settings.AngleOffset + (settings.PhaseOffset * angleBetweenBullets));

        for (int i = 0; i < settings.NumbersOfBullets; i++)
        {
            float bulletDirectionAngle = angleBetweenBullets * i;
            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            Vector2 bulletPosition = (Vector2)transform.position + (bulletDirection * settings.BulletSpped * lifeTime);

            Gizmos.DrawSphere(bulletPosition, radius);
        }
    }
}
