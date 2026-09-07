using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
public class Weapon_Aim : MonoBehaviour
{
    private Weapon_Core weapon;
    private Camera playerCamera;

    private float defaultFOV;

    private bool isAiming;
    private bool aimLocked;

    public bool IsAiming => isAiming;

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();

        playerCamera = weapon.PlayerCamera;
        defaultFOV = playerCamera.fieldOfView;
    }

    private void Update()
    {
        if (!weapon.AimAction.IsPressed())
        {
            isAiming = false;
            aimLocked = false;
        }
        else if (!aimLocked)
        {
            isAiming = true;
        }

        UpdateFOV();
    }

    private void UpdateFOV()
    {
        float targetFOV = isAiming
            ? weapon.Data.aimFOV
            : defaultFOV;

        playerCamera.fieldOfView = Mathf.Lerp(
            playerCamera.fieldOfView,
            targetFOV,
            weapon.Data.aimTransitionSpeed * Time.deltaTime
        );
    }

    public void Deactivate()
    {
        isAiming = false;
        aimLocked = true;
    }
}