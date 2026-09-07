using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
public class Weapon_Targeting : MonoBehaviour
{
    private Weapon_Core weapon;

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();
    }

    public HitZone GetHitZone(RaycastHit hit)
    {
        HitZoneComponent hitZone = hit.collider.GetComponent<HitZoneComponent>();

        if (hitZone != null)
        {
            return hitZone.Zone;
        }

        return HitZone.Body;
    }
}