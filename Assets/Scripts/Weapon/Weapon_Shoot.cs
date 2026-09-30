using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
[RequireComponent(typeof(Weapon_Charge))]
[RequireComponent(typeof(Weapon_Aim))]
[RequireComponent(typeof(Weapon_Damage))]
[RequireComponent(typeof(Weapon_Recoil))]
public class Weapon_Shoot : MonoBehaviour
{
    private Weapon_Core weapon;
    private Weapon_Charge charge;
    private Weapon_Aim aim;
    private Weapon_Damage damage;
    private Weapon_Debug debug;
    private Weapon_Impact impact;

    private float nextFireTime;
    private bool scopedShotLock;

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();
        charge = GetComponent<Weapon_Charge>();
        aim = GetComponent<Weapon_Aim>();
        damage = GetComponent<Weapon_Damage>();
        debug = GetComponent<Weapon_Debug>();
        impact = GetComponent<Weapon_Impact>();

    }

    private void Update()
    {
        if (!weapon.FireAction.IsPressed())
        {
            scopedShotLock = false;
        }

        if (aim.IsAiming)
        {
            ScopedFire();
        }
        else if (!scopedShotLock)
        {
            HipFire();
        }
    }

    private void HipFire()
    {
        if (!weapon.FireAction.IsPressed())
            return;

        if (Time.time < nextFireTime)
            return;

        Shoot(false);

        nextFireTime = Time.time + 1f / weapon.Data.fireRate;
    }

    private void ScopedFire()
    {
        if (scopedShotLock)
            return;

        if (!weapon.FireAction.WasPressedThisFrame())
            return;

        if (Time.time < nextFireTime)
            return;

        bool wasAiming = aim.IsAiming;

        Shoot(wasAiming);

        nextFireTime = Time.time + 1f / weapon.Data.fireRate;

        scopedShotLock = true;

        aim.Deactivate();
        charge.ResetCharge();
    }

    private void Shoot(bool isScoped)
    {
        Ray ray = weapon.PlayerCamera.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f)
        );

        if (Physics.Raycast(ray, out RaycastHit hit, weapon.Data.range))
        {
            float finalDamage = damage.CalculateDamage(hit, isScoped);

            Debug.Log(
                $"Hit: {hit.collider.name} | " +
                $"Damage: {finalDamage:F1}"
            );

            impact.Spawn(hit.point, hit.normal);
        }
    }
}