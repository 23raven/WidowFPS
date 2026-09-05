using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "WidowFPS/Movement Data")]
public class MovementData : ScriptableObject
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jump")]
    public float jumpForce = 5f;

    [Header("Gravity")]
    public float gravity = -20f;
    public float groundedForce = -2f;
}