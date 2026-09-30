using UnityEngine;

public class Weapon_Impact : MonoBehaviour
{
    [SerializeField] private GameObject impactPrefab;

    public void Spawn(Vector3 position, Vector3 normal)
    {
        Quaternion rotation = Quaternion.LookRotation(normal);

        Instantiate(
            impactPrefab,
            position + normal * 0.01f,
            rotation
        );
    }
}