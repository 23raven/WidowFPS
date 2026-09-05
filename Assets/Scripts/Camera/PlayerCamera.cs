using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference lookAction;

    [Header("Settings")]
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private float verticalLimit = 89f;

    private float verticalRotation;

    private void OnEnable()
    {
        lookAction.action.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        lookAction.action.Disable();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        Vector2 input = lookAction.action.ReadValue<Vector2>();

        transform.parent.Rotate(Vector3.up * input.x * sensitivity);

        verticalRotation -= input.y * sensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLimit, verticalLimit);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}