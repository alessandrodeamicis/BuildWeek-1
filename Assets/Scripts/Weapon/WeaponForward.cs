using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponForward : BaseWeapon
{
    public Vector2 shootDirection = Vector2.right;
    public float projectileSpeed;
    protected override void Fire()
    {
        
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);


        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            bulletComponent.dir = shootDirection;

            bulletComponent.Speed = projectileSpeed;
        }
    }
}