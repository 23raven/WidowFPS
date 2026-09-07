using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "WidowFPS/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Damage")]
    public float minDamage = 12f;
    public float maxDamage = 125f;
    public float headMultiplier = 2.5f;

    [Header("Shooting")]
    public float fireRate = 1f;
    public float range = 1000f;

    [Header("Charge")]
    public float chargeTime = 0.9f;

    [Header("Ammo")]
    public int magazineSize = 35;
    public int ammoPerShot = 5;

    [Header("Aim")]
    public float aimFOV = 30f;
    public float aimTransitionSpeed = 10f;
}