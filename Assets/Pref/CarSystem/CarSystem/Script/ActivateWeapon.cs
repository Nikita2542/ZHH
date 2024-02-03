using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeapon : MonoBehaviour
{
    public enum WeaponSlot
    {
        Primary = 0,
        Secondary = 1
    }

    [Header("Weapon Activate")]
    [Tooltip("Назначь кнопку для уберания оружия")]
    public KeyCode keyCode;
    [Tooltip("Назначь ножки оружия")]
    public GameObject holder;
    [Tooltip("Назначь обьект - под камерой")]
    public Transform crossHairTarget;
    public Transform aimLookAt;
    [Tooltip("Назначь папку в которой будет храниться оружие")]
    public Transform[] weaponSlots;

    [Tooltip("Задай уровень прицела")]
    [HideInInspector] public int ID_Pricel;

    [Tooltip("Задай уровень магазина")]
    [HideInInspector] public int ID_Magazin;

    [Tooltip("Задай уровень дула")]
    [HideInInspector] public int ID_Dulo;


    RaycastWeapon[] equipped_weapons = new RaycastWeapon[2];
    public int activeWeaponIndex;
    bool isHolstered = false;
    [HideInInspector] public WeaponItem weaponItem;
    [HideInInspector] public CharacterAiming characterAiming;
    public Animator rigController;
    public GameObject enemyHitUIPrefab;
    public GameObject enemyHitUI;
    public Transform canvas;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("CanvasPlayer").transform;
        RaycastWeapon existingWeapon = GetComponentInChildren<RaycastWeapon>();
        rigController = GetComponent<Animator>();

        if (existingWeapon)
        {
            Equip(existingWeapon);
        }
    }

    public RaycastWeapon GetWeapon(int index)
    {
        if (index < 0 || index >= equipped_weapons.Length)
        {
            return null;
        }
        return equipped_weapons[index];
    }

    void Update()
    {
        var weapon = GetWeapon(activeWeaponIndex);
        if (weapon && !isHolstered)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.StartFiring();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                weapon.StopFiring();
            }
            if (weapon.isFiring)
            {
                weapon.UpdateFiring(Time.deltaTime);
            }
            weapon.UpdateBullet(Time.deltaTime);

        }
        else
        {
            holder.SetActive(false);
        }
        if (Input.GetKeyDown(keyCode))
        {
            ToggleActiveWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveWeapon(WeaponSlot.Primary);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveWeapon(WeaponSlot.Secondary);
        }
    }

    public void Equip(RaycastWeapon newWeapon)
    {
        int weaponSlotIndex = (int)newWeapon.weaponSlot;
        var weapon = GetWeapon(weaponSlotIndex);
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newWeapon;
        weapon.raycastDestination = crossHairTarget;
        weapon.recoil.characterAiming = characterAiming;
        weapon.recoil.rigController = rigController;
        weapon.activateWeapon = this;
        weaponItem = weapon.weaponItem;
        weaponItem.weapon = weapon;




        ID_Pricel = weaponItem.pricelID;
        ID_Magazin = weaponItem.magazinID;
        ID_Dulo = weaponItem.duloID;

        weaponItem.SpawnPricel(ID_Pricel);
        weaponItem.SpawnMagazin(ID_Magazin);
        weaponItem.SpawnDulo(ID_Dulo);

        holder.SetActive(true);

        weapon.transform.SetParent(weaponSlots[weaponSlotIndex], false);

        equipped_weapons[weaponSlotIndex] = weapon;
        SetActiveWeapon(newWeapon.weaponSlot);

    }

    void ToggleActiveWeapon()
    {
        bool isHolstered = rigController.GetBool("holster_weapon");
        if (isHolstered)
        {
            StartCoroutine(ActiveWeapon(activeWeaponIndex));
        }
        else
        {
            StartCoroutine(HolsterWeapon(activeWeaponIndex));
        }
    }

    void SetActiveWeapon(WeaponSlot weaponSlot)
    {
        int holsterIndex = activeWeaponIndex;
        int activateIndex = (int)weaponSlot;

        if (holsterIndex == activateIndex)
        {
            holsterIndex = -1;
        }
        StartCoroutine(SwitchWeapon(holsterIndex, activateIndex));
    }
    IEnumerator SwitchWeapon(int holsterIndex, int activateIndex)
    {
        yield return StartCoroutine(HolsterWeapon(holsterIndex));
        yield return StartCoroutine(ActiveWeapon(activateIndex));
        activeWeaponIndex = activateIndex;
    }
    IEnumerator HolsterWeapon(int index)
    {
        isHolstered = true;
        var weapon = GetWeapon(index);
        if (weapon)
        {
            rigController.SetBool("holster_weapon", true);
            do
            {
                yield return new WaitForEndOfFrame();
            } while (rigController.GetCurrentAnimatorStateInfo(2).normalizedTime < 1.0f);
        }
    }
    IEnumerator ActiveWeapon(int index)
    {
        var weapon = GetWeapon(index);
        if (weapon)
        {
            rigController.SetBool("holster_weapon", false);
            rigController.Play("equip_" + weapon.weaponName);
            do
            {
                yield return new WaitForEndOfFrame();
            } while (rigController.GetCurrentAnimatorStateInfo(2).normalizedTime < 1.0f);
            weapon.isFiring = false;
            holder.SetActive(true);
            isHolstered = false;
        }
    }
}
