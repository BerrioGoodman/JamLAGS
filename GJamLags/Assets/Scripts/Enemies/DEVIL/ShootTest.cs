using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float shootCooldown = 0.2f;
    [SerializeField] private RadialShootSettings shootSettings;
    private float shootCooldownTimer = 0f;
    

    private void Update()
    {
        shootCooldownTimer -= Time.deltaTime;

        if (shootCooldownTimer <= 0f)
        {
            ShootAttack.RadialShoot(transform.position, transform.up, shootSettings);
            shootCooldownTimer += shootCooldown;
        }
    }

    
}
