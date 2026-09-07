using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
[RequireComponent(typeof(Weapon_Charge))]
public class Weapon_Shoot : MonoBehaviour
{
    private Weapon_Core weapon;
    private Weapon_Charge charge;
    private Weapon_Targeting targeting;
    private Weapon_Damage damage;
    private Weapon_Aim aim;

    private float nextFireTime;

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();
        charge = GetComponent<Weapon_Charge>();
        targeting = GetComponent<Weapon_Targeting>();
        damage = GetComponent<Weapon_Damage>();
        aim = GetComponent<Weapon_Aim>();
    }

    private void Update()
    {
        if (!weapon.FireAction.WasPressedThisFrame())
            return;

        Shoot();
    }

    private void Shoot()
    {
        if (Time.time < nextFireTime)
            return;

        nextFireTime = Time.time + 1f / weapon.Data.fireRate;

        Ray ray = weapon.PlayerCamera.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f)
        );

        if (Physics.Raycast(ray, out RaycastHit hit, weapon.Data.range))
        {
            float finalDamage = damage.CalculateDamage(hit);

            Debug.Log(
                $"Hit: {hit.collider.name} | " +
                $"Damage: {finalDamage:F1}"
            );
        }

        // После выстрела заряд сбрасывается.
        aim.Deactivate();
        charge.ResetCharge();
    }
}