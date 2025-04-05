using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RadialShootSettings
{
    [Header("Base Settings")]
    public int NumbersOfBullets = 5;
    public float BulletSpped = 10f;
    public float CooldownAfterShot;

    [Header("Offsets")]
    [Range(-1f, 1f)] public float PhaseOffset = 0f;
    [Range(-180f, 180f)] public float AngleOffset = 0f;
}
