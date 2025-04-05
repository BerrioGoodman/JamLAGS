using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class ShootAttack 
{
    public static void Simpleshoot(Vector2 origin, Vector2 velocity)
    {
        Bullet bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.velocity = velocity;
    }

    public static void RadialShoot(Vector2 origin, Vector2 aimDirection, RadialShootSettings settings)
    {
        float angleBetweenBullets = 360f / settings.NumbersOfBullets;

        if (settings.AngleOffset != 0f || settings.PhaseOffset != 0)
            aimDirection = aimDirection.Rotate(settings.AngleOffset + (settings.PhaseOffset * angleBetweenBullets));

        for (int i = 0; i < settings.NumbersOfBullets; i++) 
        {
            float bulletDirectionAngle = angleBetweenBullets * i;
            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            Simpleshoot(origin, bulletDirection * settings.BulletSpped);
        }
    }
}
