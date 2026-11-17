using System.Collections;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string weaponName = "Rifle";
    public float damage = 25f;
    public float range = 100f;
    public float fireRate = 0.2f;
    public float reloadTime = 2f;

    public int magazineSize = 30;
    public int reserveAmmo = 90;

    [HideInInspector] public int currentAmmo;
}

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Slots")]
    [SerializeField] private WeaponData[] weapons = new WeaponData[2];

    [Header("References")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask hitLayers = ~0;

    private int currentWeaponIndex = 0;
    private float nextFireTime;
    private bool isReloading;

    private WeaponData CurrentWeapon
    {
        get { return weapons[currentWeaponIndex]; }
    }

    private void Awake()
    {
        foreach (WeaponData weapon in weapons)
        {
            if (weapon != null)
                weapon.currentAmmo = weapon.magazineSize;
        }
    }

    public void Fire()
    {
        if (isReloading || playerCamera == null)
            return;

        if (Time.time < nextFireTime)
            return;

        if (CurrentWeapon.currentAmmo <= 0)
        {
            Debug.Log("Magazine empty! Reload.");
            return;
        }

        nextFireTime = Time.time + CurrentWeapon.fireRate;
        CurrentWeapon.currentAmmo--;


        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit,
            CurrentWeapon.range, hitLayers,
            QueryTriggerInteraction.Ignore))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);

            EnemyHealth enemy =
                hit.collider.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(CurrentWeapon.damage);
            }
            else
            {
                Debug.LogWarning("Hit object has no EnemyHealth component!");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }

    }

    public void Reload()
    {
        if (isReloading)
            return;

        if (CurrentWeapon.currentAmmo >= CurrentWeapon.magazineSize)
            return;

        if (CurrentWeapon.reserveAmmo <= 0)
        {
            Debug.Log("No reserve ammunition!");
            return;
        }

        StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        isReloading = true;

        Debug.Log("Reloading " + CurrentWeapon.weaponName);

        yield return new WaitForSeconds(CurrentWeapon.reloadTime);

        int neededAmmo =
            CurrentWeapon.magazineSize - CurrentWeapon.currentAmmo;

        int ammoToLoad =
            Mathf.Min(neededAmmo, CurrentWeapon.reserveAmmo);

        CurrentWeapon.currentAmmo += ammoToLoad;
        CurrentWeapon.reserveAmmo -= ammoToLoad;

        isReloading = false;

        Debug.Log("Reload complete!");
    }

    public void SwitchWeapon()
    {
        if (weapons == null || weapons.Length < 2)
            return;

        StopAllCoroutines();
        isReloading = false;

        currentWeaponIndex =
            (currentWeaponIndex + 1) % weapons.Length;

        nextFireTime = 0f;

        Debug.Log("Equipped: " + CurrentWeapon.weaponName);
    }
}
