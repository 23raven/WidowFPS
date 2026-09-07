using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
public class Weapon_Charge : MonoBehaviour
{
    private Weapon_Core weapon;

    public float ChargePercent { get; private set; }

    public float CurrentDamage =>
        Mathf.Lerp(
            weapon.Data.minDamage,
            weapon.Data.maxDamage,
            ChargePercent
        );

    private bool canCharge = true;

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();
    }

    private void Update()
    {
        if (!weapon.AimAction.IsPressed())
        {
            ChargePercent = 0f;
            canCharge = true;
            return;
        }

        if (!canCharge)
            return;

        ChargePercent += Time.deltaTime / weapon.Data.chargeTime;
        ChargePercent = Mathf.Clamp01(ChargePercent);
    }

    public void ResetCharge()
    {
        ChargePercent = 0f;
        canCharge = false;
    }
}