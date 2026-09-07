using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
public class Weapon_Shoot : MonoBehaviour
{
    private Weapon_Core weapon;

    private float nextFireTime;

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();
    }

    private void Update()
    {
        if (!weapon.FireAction.IsPressed())
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
            Debug.Log($"Hit: {hit.collider.name}");
        }
    }
}