using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeaponBlue : MonoBehaviour
{
    public GameObject weaponSborca;
    public Transform weaponSlot;
    [HideInInspector] public WeaponRaycastBlue weapon;
    WeaponIkBlue weaponIk;
    [HideInInspector] public bool fireActiv;
    [Header("Скорострельность")]
    public float timeFire;
    [HideInInspector]
    public float time;

    public bool reload;
    float reloading;
    public bool isStopFire;
    private void Start()
    {
        weaponIk = GetComponent<WeaponIkBlue>();
        weapon = Instantiate(weaponSborca.GetComponent<WeaponRaycastBlue>(), weaponSlot);
        weapon.raycastDestination = weaponIk.targetTransform;
        weaponIk.aimTransform = weapon.transform.GetChild(0);
        isStopFire = false;
    }

    private void Update()
    {
        if(isStopFire == false)
        {
            if (weapon.bulletCount <= 0)
            {
                reload = true;

            }
            if (reload == false)
            {
                reloading = weapon.reloading;
                if (fireActiv == true)
                {
                    if (time > 0)
                    {
                        time -= Time.deltaTime;
                    }
                    if (time <= 0)
                    {
                        weapon.StartFiring();
                        time = timeFire;
                    }
                }
                if (weapon.isFiring)
                {
                    weapon.UpdateFiring(Time.deltaTime);
                }
                weapon.UpdateBullets(Time.deltaTime);
                if (fireActiv == false)
                {
                    weapon.StopFiring();
                }
            }
            else
            {
                reloading -= Time.deltaTime;
                if (reloading <= 0)
                {
                    weapon.bulletCount = weapon.maxBulletCount;
                    reload = false;
                }
            }
        }
        
        
        
    }

}
