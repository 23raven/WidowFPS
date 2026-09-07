using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
public class Weapon_Aim : MonoBehaviour
{
    private Weapon_Core weapon;
    private Camera playerCamera;

    private float defaultFOV;

    public bool IsAiming =>
        weapon.AimAction.IsPressed();

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();

        playerCamera = weapon.PlayerCamera;
        defaultFOV = playerCamera.fieldOfView;
    }

    private void Update()
    {
        UpdateFOV();
    }

    private void UpdateFOV()
    {
        float targetFOV = IsAiming
            ? weapon.Data.aimFOV
            : defaultFOV;

        playerCamera.fieldOfView = Mathf.Lerp(
            playerCamera.fieldOfView,
            targetFOV,
            weapon.Data.aimTransitionSpeed * Time.deltaTime
        );
    }
}