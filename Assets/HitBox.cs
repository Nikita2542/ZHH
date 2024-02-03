using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public PlayerHealth health;
    public void Damage(WeaponRaycastBlue weapon)
    {
        health.TakeDamage(weapon.damage);
    }
}
