using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement_Core : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private MovementData movementData;

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;

    public MovementData Data => movementData;
    public CharacterController Controller => characterController;

    public InputAction MoveAction => moveAction.action;
    public InputAction JumpAction => jumpAction.action;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }
}