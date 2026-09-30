using UnityEngine;

public class Weapon_Debug : MonoBehaviour
{
    [Header("Hit Effect")]
    [SerializeField] private float markerSize = 0.05f;
    [SerializeField] private float markerLifetime = 1f;

    public void CreateHitMarker(Vector3 position, Vector3 normal)
    {
        GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Quad);

        marker.transform.position = position + normal * 0.01f;
        marker.transform.rotation = Quaternion.LookRotation(normal);
        marker.transform.localScale = Vector3.one * markerSize;

        Destroy(marker.GetComponent<Collider>());

        Renderer renderer = marker.GetComponent<Renderer>();
        renderer.material.color = Color.magenta;

        Destroy(marker, markerLifetime);
    }
}