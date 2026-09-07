using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
[RequireComponent(typeof(Weapon_Charge))]
public class Weapon_Shoot : MonoBehaviour
{
    private Weapon_Core weapon;
    private Weapon_Charge charge;

    private float nextFireTime;

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();
        charge = GetComponent<Weapon_Charge>();
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
            float damage = charge.CurrentDamage;

            Debug.Log(
                $"Hit: {hit.collider.name} | " +
                $"Charge: {charge.ChargePercent:P0} | " +
                $"Damage: {damage:F1}"
            );
        }

        // После выстрела заряд сбрасывается.
        charge.ResetCharge();
    }
}