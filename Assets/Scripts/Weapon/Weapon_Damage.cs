using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
[RequireComponent(typeof(Weapon_Targeting))]
[RequireComponent(typeof(Weapon_Charge))]
public class Weapon_Damage : MonoBehaviour
{
    private Weapon_Core weapon;
    private Weapon_Targeting targeting;
    private Weapon_Charge charge;

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();
        targeting = GetComponent<Weapon_Targeting>();
        charge = GetComponent<Weapon_Charge>();
    }

    public float CalculateDamage(RaycastHit hit)
    {
        HitZone zone = targeting.GetHitZone(hit);

        float damage = charge.CurrentDamage;

        switch (zone)
        {
            case HitZone.Head:
                damage *= weapon.Data.headMultiplier;
                break;

            case HitZone.Limb:
                damage *= weapon.Data.limbMultiplier;
                break;

            case HitZone.Body:
                damage *= weapon.Data.bodyMultiplier;
                break;
        }

        return damage;
    }
}