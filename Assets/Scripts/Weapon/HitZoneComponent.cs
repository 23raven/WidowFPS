using UnityEngine;

public class HitZoneComponent : MonoBehaviour
{
    [SerializeField] private HitZone zone;

    public HitZone Zone => zone;
}