using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;

public abstract class Weapon
{


    [SerializeField]
    private string name;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRange;
    [SerializeField]private float nextTimeToFire;

    public string Name => name;
    public float FireRate => fireRate;
    public float FireRange => fireRange;
    public float NextTimeToFire => nextTimeToFire;
    
    public Weapon(string name, float fireRate, float fireRange, float nexTimeToFire)
    {
        this.name = name;
        this.fireRate = fireRate;
        this.fireRange = fireRange;
        this.nextTimeToFire = nexTimeToFire;
    }

    public abstract void Shoot();
}


