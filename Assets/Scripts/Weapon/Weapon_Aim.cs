using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
public class Weapon_Aim : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerState playerState;

    private Weapon_Core weapon;
    private Camera playerCamera;

    private float defaultFOV;
    private bool aimLocked;

    public bool IsAiming => playerState.IsAiming;

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
            playerState.IsAiming = false;
            aimLocked = false;
        }
        else if (!aimLocked)
        {
            playerState.IsAiming = true;
        }

        UpdateFOV();
    }

    private void UpdateFOV()
    {
        float targetFOV = playerState.IsAiming
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
        playerState.IsAiming = false;
        aimLocked = true;
    }
}