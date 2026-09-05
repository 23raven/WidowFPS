using UnityEngine;

[RequireComponent(typeof(PlayerCamera))]
public class Camera_Crouch : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Movement_Crouch crouch;
    [SerializeField] private CameraData cameraData;

    private Vector3 standPosition;

    private void Awake()
    {
        standPosition = transform.localPosition;
    }

    private void Update()
    {
        float targetY = crouch.IsCrouching
            ? standPosition.y + crouch.CameraOffset
            : standPosition.y;

        Vector3 targetPosition = transform.localPosition;
        targetPosition.y = targetY;

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetPosition,
            cameraData.crouchTransitionSpeed * Time.deltaTime
        );
    }
}