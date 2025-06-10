using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotatingDirection : BaseWeapon
{
    private int currentIndex = 0;
    private float[] angles = { 0f, 90f, 180f, 270f }; // Destra, Su, Sinistra, Giù

    protected override void Fire()
    {
        Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, angles[currentIndex]));
        currentIndex = (currentIndex + 1) % angles.Length;
    }
}
