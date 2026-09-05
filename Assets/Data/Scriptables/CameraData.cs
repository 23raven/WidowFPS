using UnityEngine;

[CreateAssetMenu(fileName = "CameraData", menuName = "WidowFPS/Camera Data")]
public class CameraData : ScriptableObject
{
    [Header("Look")]
    public float sensitivity = 0.1f;
    public float verticalLimit = 89f;

    [Header("Crouch")]
    public float crouchTransitionSpeed = 10f;
}