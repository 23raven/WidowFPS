using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement_WASD : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Input")]
    [SerializeField] private InputActionReference movementAction;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        movementAction.action.Enable();
    }

    private void OnDisable()
    {
        movementAction.action.Disable();
    }

    private void Update()
    {
        Vector2 input = movementAction.action.ReadValue<Vector2>();

        Vector3 moveDirection =
            transform.right * input.x +
            transform.forward * input.y;

        characterController.Move(
            moveDirection * moveSpeed * Time.deltaTime
        );
    }
}