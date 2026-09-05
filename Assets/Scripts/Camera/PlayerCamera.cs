using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference lookAction;

    [Header("Settings")]
    [SerializeField] private CameraData cameraData;

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

        float mouseX = input.x * (cameraData.sensitivity / 50f);
        float mouseY = input.y * (cameraData.sensitivity / 50f);

        transform.parent.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(
            verticalRotation,
            -cameraData.verticalLimit,
            cameraData.verticalLimit
        );

        transform.localRotation = Quaternion.Euler(
            verticalRotation,
            0f,
            0f
        );
    }
}