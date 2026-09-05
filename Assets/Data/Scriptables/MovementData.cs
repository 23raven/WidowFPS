using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "WidowFPS/Movement Data")]
public class MovementData : ScriptableObject
{
    [Header("Movement")]
    public float moveSpeed = 5f;
}