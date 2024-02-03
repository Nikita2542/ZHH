using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox_mutantBlue : MonoBehaviour
{
    public AIMutant_Blue health;

    public void OnRaycastHit(RaycastWeapon weapon, Vector3 direction)
    {
        health.TakeDamage(weapon.damage, direction);
    }
}
