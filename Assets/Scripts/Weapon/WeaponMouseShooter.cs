using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMouseShooter : BaseWeapon
{
    protected override void Fire()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mouseWorld - firePoint.position).normalized;
        Instantiate(  projectilePrefab, firePoint.position, Quaternion.identity);

    }
}