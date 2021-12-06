using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Objects/Weapon", order = 0)]
public class GunObj : ScriptableObject
{
    public float ammo;
    public GameObject projectile;
    public float timeBtwShots;
    public float thrust;
    public float amoutOfBullet;
    public float spread;
}
