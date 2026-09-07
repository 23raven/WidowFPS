using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_Core : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private WeaponData weaponData;

    [Header("Input")]
    [SerializeField] private InputActionReference fireAction;
    [SerializeField] private InputActionReference aimAction;

    [Header("References")]
    [SerializeField] private Camera playerCamera;

   
    public WeaponData Data => weaponData;
    public InputAction FireAction => fireAction.action;
    public InputAction AimAction => aimAction.action;
    public Camera PlayerCamera => playerCamera;

    private void OnEnable()
    {
        fireAction.action.Enable();
        aimAction.action.Enable();
    }

    private void OnDisable()
    {
        fireAction.action.Disable();
        aimAction.action.Disable();
    }
}