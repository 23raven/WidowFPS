using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_Core : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private WeaponData weaponData;

    [Header("Input")]
    [SerializeField] private InputActionReference fireAction;

    [Header("References")]
    [SerializeField] private Camera playerCamera;

    public WeaponData Data => weaponData;
    public InputAction FireAction => fireAction.action;
    public Camera PlayerCamera => playerCamera;

    private void OnEnable()
    {
        fireAction.action.Enable();
    }

    private void OnDisable()
    {
        fireAction.action.Disable();
    }
}