using UnityEngine;

[RequireComponent(typeof(Movement_Core))]
[RequireComponent(typeof(CharacterController))]
public class Movement_Crouch : MonoBehaviour
{
    private Movement_Core movement;
    private CharacterController controller;

    private float standHeight;
    private Vector3 standCenter;
    public bool IsCrouching => controller.height < standHeight;
    public float CameraOffset => movement.Data.crouchCameraOffset;
    private void Awake()
    {
        movement = GetComponent<Movement_Core>();
        controller = GetComponent<CharacterController>();

        standHeight = controller.height;
        standCenter = controller.center;
    }

    private void Update()
    {
        if (movement.CrouchAction.IsPressed())
        {
            Crouch();
        }
        else
        {
            TryStand();
        }
    }

    private void Crouch()
    {
        float crouchHeight = movement.Data.crouchHeight;

        if (controller.height == crouchHeight)
            return;

        float heightDifference = standHeight - crouchHeight;

        controller.height = crouchHeight;
        controller.center = standCenter + Vector3.down * (heightDifference * 0.5f);
    }

    private void TryStand()
    {
        if (controller.height == standHeight)
            return;

        if (!CanStand())
            return;

        controller.height = standHeight;
        controller.center = standCenter;
    }

    private bool CanStand()
    {
        float radius = controller.radius;

        Vector3 bottom = transform.position
                         + standCenter
                         + Vector3.up * (-standHeight * 0.5f + radius);

        Vector3 top = transform.position
                      + standCenter
                      + Vector3.up * (standHeight * 0.5f - radius);

        return !Physics.CheckCapsule(
            bottom,
            top,
            radius,
            movement.Data.crouchCollisionMask,
            QueryTriggerInteraction.Ignore
        );
    }
}