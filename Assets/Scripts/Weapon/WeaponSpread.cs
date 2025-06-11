using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpread : BaseWeapon
{

    public float spreadAngle = 30f;

    protected override void Fire()
    {
        FireBullet(0f);
        FireBullet(+spreadAngle);
        FireBullet(-spreadAngle);
    }

    void FireBullet(float angleOffset)
    {
        bool facingRight = transform.localScale.x > 0;
        float baseAngle = facingRight ? 0f : 180f;
        float totalAngle = baseAngle + angleOffset;

        Quaternion rot = Quaternion.Euler(0f, 0f, totalAngle);
        Bullet bullet = Instantiate(projectilePrefab, firePoint.position, rot).GetComponent<Bullet>();
        bullet.dir = rot * new Vector2(firePoint.position.x, firePoint.position.y);
    }

}