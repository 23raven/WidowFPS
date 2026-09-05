using UnityEngine;

public class Movement_WASD : MonoBehaviour
{
    private Movement_Core movement;

    private void Awake()
    {
        movement = GetComponent<Movement_Core>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = movement.MoveAction.ReadValue<Vector2>();

        Vector3 moveDirection =
            transform.right * input.x +
            transform.forward * input.y;

        if (moveDirection.sqrMagnitude > 1f)
        {
            moveDirection.Normalize();
        }

        movement.Controller.Move(
            moveDirection * movement.Data.moveSpeed * Time.deltaTime
        );
    }
}