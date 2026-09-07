using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "WidowFPS/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Damage")]
    public float damage = 120f;

    [Header("Shooting")]
    public float fireRate = 1f;
    public float range = 1000f;

    [Header("Spread")]
    public float spread = 0f;
}