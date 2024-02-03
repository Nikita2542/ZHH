using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickUp : MonoBehaviour
{
    public KeyCode KeyCode;
    public RaycastWeapon weaponPrimary;
    public RaycastWeapon weaponSecondary;
    public ActivateWeapon activeWeapon;
    public bool active;

    public void Start()
    {
        PickUpWeapon();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode))
        {
            active = !active;
            if(active)
            {
                PickUpWeapon();
            }
            else
            {
                PickUpWeaponSecondary();
            }
        }
    }
    public void PickUpWeapon()
    {
        RaycastWeapon newWeapon = Instantiate(weaponPrimary);
        activeWeapon.Equip(newWeapon);
    }
    public void PickUpWeaponSecondary()
    {
        RaycastWeapon newWeapon = Instantiate(weaponSecondary);
        activeWeapon.Equip(newWeapon);
    }

}
