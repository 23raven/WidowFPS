using UnityEngine;

public class Movement_Jump : MonoBehaviour
{
    private Movement_Core movement;

    private float verticalVelocity;

    private void Awake()
    {
        movement = GetComponent<Movement_Core>();
    }

    private void Update()
    {
        ApplyGravity();
        Jump();
    }

    private void ApplyGravity()
    {
        if (movement.Controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = movement.Data.groundedForce;
        }

        verticalVelocity += movement.Data.gravity * Time.deltaTime;

        movement.Controller.Move(
            Vector3.up * verticalVelocity * Time.deltaTime
        );
    }

    private void Jump()
    {
        if (movement.Controller.isGrounded &&
            movement.JumpAction.WasPressedThisFrame())
        {
            verticalVelocity = movement.Data.jumpForce;
        }
    }
}