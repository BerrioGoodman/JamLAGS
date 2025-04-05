using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletHell System/Radial shot pattern")]

public class RadialShootPattern : ScriptableObject
{
    public int Repetitions;
    public float StartWait = 0f;
    public float EndWait = 1f;
    public RadialShootSettings[] PatternSetting;
}
