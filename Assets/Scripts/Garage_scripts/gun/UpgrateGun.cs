using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgrateGun : MonoBehaviour
{
    public Transform gunParent;
    public Camera Main_Camera;
    
    public Transform main_pos;
    public Transform main_look;

    public GameObject[] gunsUI;
    public GameObject[] gunsObject;

    public GameObject gun;

    public gunSelect gunsSelect;
    public Spawn_components spawn;

    

    UpVSPlus upVSPlus;
    public bool upgrade;
    public PlusikEvent plusEvent;

    public WeaponCharacteristic characteristic;

    private void Start()
    {
        upVSPlus = GetComponentInParent<UpVSPlus>();
        for (int i = 0; i < gunsUI.Length; i++)
        {
            gunsUI[i].AddComponent<gunSelect>();
            gunsUI[i].GetComponent<gunSelect>().IQ = i;
        }
        upgrade = true;
    }
    private void Update()
    {
        if (upgrade)
        {
            Main_Camera.transform.position = Vector3.Lerp(Main_Camera.transform.position, main_pos.transform.position, Time.deltaTime * 2);
            Main_Camera.transform.LookAt(main_look.transform);
            Main_Camera.fieldOfView = 40f;
        }

    }
    public void GunSpawn(int IQ)
    {
        if (gun == true)
        {
           Destroy(gun.gameObject);
        }
        else
        {
            gun = Instantiate(gunsObject[IQ], gunParent);
        }
        gun = Instantiate(gunsObject[IQ], gunParent);
        
        characteristic.defSetting = gun.GetComponent<Default_Setting>();
        characteristic.UpgateWeapon();

        spawn.Gun_Avtomat = gun.transform.GetChild(1).gameObject;




        spawn.pricelID = PlayerPrefs.GetInt("ID");
        spawn.pricelName = PlayerPrefs.GetString("NamePricel");

        spawn.EventBtn_Pricel1(spawn.pricelID, spawn.pricelName);

        spawn.duloID = PlayerPrefs.GetInt("ID_Dulo");
        spawn.duloName = PlayerPrefs.GetString("NameDulo");

        spawn.EventBtn_Pricel1(spawn.duloID, spawn.duloName);

        spawn.magazinID = PlayerPrefs.GetInt("ID_Magazin");
        spawn.magazinName = PlayerPrefs.GetString("NameMagazin");

        spawn.EventBtn_Pricel1(spawn.magazinID, spawn.magazinName);
       
        plusEvent.gun = gun.GetComponent<Default_Setting>();
        plusEvent.EventPlus();
    }
    public void GunUpgrate(bool active)
    {
        upVSPlus.PlusActive(active);
        upVSPlus.plusActive = true;
        upVSPlus.upgrateActive = false;
    }

    public void GunSpawns(int IQ)
    {
        if (gun == true)
        {
            Destroy(gun.gameObject);
        }
        else
        {
            gun = Instantiate(gunsObject[IQ], gunParent);
        }
        gun = Instantiate(gunsObject[IQ], gunParent);

        characteristic.defSetting = gun.GetComponent<Default_Setting>();
        characteristic.UpgateWeapon();

        spawn.Gun_Avtomat = gun.transform.GetChild(1).gameObject;




        spawn.pricelID = PlayerPrefs.GetInt("ID");
        spawn.pricelName = PlayerPrefs.GetString("NamePricel");

        spawn.EventBtn_Pricel1(spawn.pricelID, spawn.pricelName);

        spawn.duloID = PlayerPrefs.GetInt("ID_Dulo");
        spawn.duloName = PlayerPrefs.GetString("NameDulo");

        spawn.EventBtn_Pricel1(spawn.duloID, spawn.duloName);

        spawn.magazinID = PlayerPrefs.GetInt("ID_Magazin");
        spawn.magazinName = PlayerPrefs.GetString("NameMagazin");

        spawn.EventBtn_Pricel1(spawn.magazinID, spawn.magazinName);

        plusEvent.gun = gun.GetComponent<Default_Setting>();
        

    }    
}
