using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSideShooter : BaseWeapon
{
    protected override void Fire()
    {
        Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, 0));   
        Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, 180)); 
    }
}