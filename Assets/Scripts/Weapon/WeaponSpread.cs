using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpread : BaseWeapon
{
    public float spreadAngle = 30f;

    protected override void Fire()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, firePoint.eulerAngles.z + spreadAngle));
        Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, firePoint.eulerAngles.z - spreadAngle));
    }
}