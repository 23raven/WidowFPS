using UnityEngine;

[RequireComponent(typeof(Weapon_Core))]
public class Weapon_Recoil : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerCamera playerCamera;

    private Weapon_Core weapon;

    private void Awake()
    {
        weapon = GetComponent<Weapon_Core>();
    }

    public void ApplyRecoil(bool isScoped)
    {
        float recoil = isScoped
            ? weapon.Data.scopedRecoil
            : weapon.Data.hipRecoil;

        playerCamera.AddRecoil(recoil);
    }
}