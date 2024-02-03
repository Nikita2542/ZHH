
using UnityEngine;
using UnityEngine.UI;

public class Spawn_components : MonoBehaviour
{
    [Header("Автомат")]
    public GameObject Gun_Avtomat;

    [Header("Прицел pref")]
    public GameObject[] prefab_pricel;
    public string namePricel;

    [Header("Глушак pref")]
    public GameObject[] prefab_glush;
    public string nameGlush;

    [Header("Магазин pref")]
    public GameObject[] prefab_magazin;
    public string nameMagazin;

    

    #region Obj 
    // - Прицел -
    [HideInInspector]public GameObject original_pricel;

    // - Магазин -
    [HideInInspector] public GameObject original_glush;

    // - Дуло -
    [HideInInspector] public GameObject original_magazin;

    #endregion
    
    public Main_Shop1 main_shop;
    [HideInInspector] public Btn_ID Btn_ID;
    public WeaponCharacteristic characteristic;
   
    public int pricelID;
    public string pricelName;

    public int duloID;
    public string duloName;

    public int magazinID;
    public string magazinName;

    public GameObject[] close;

    

    public void Start()
    {
       
        for (int i = 0; i < main_shop.btn_p.Length; i++)
        {
            Btn_ID = main_shop.btn_p[i].gameObject.AddComponent<Btn_ID>();
            main_shop.btn_p[i].GetComponent<Btn_ID>().name = namePricel;
            close[0].GetComponent<CloseItem>().name = namePricel;
            close[0].GetComponent<CloseItem>().spawn = this;
            Btn_ID.ID = i;
            
        }
        for (int i = 0; i < main_shop.btn_glush.Length; i++)
        {
            Btn_ID = main_shop.btn_glush[i].gameObject.AddComponent<Btn_ID>();
            main_shop.btn_glush[i].GetComponent<Btn_ID>().name = nameGlush;
            close[1].GetComponent<CloseItem>().name = nameGlush;
            close[1].GetComponent<CloseItem>().spawn = this;
            Btn_ID.ID = i;
            
        }
        for (int i = 0; i < main_shop.btn_horn.Length; i++)
        {
            Btn_ID = main_shop.btn_horn[i].gameObject.AddComponent<Btn_ID>();
            main_shop.btn_horn[i].GetComponent<Btn_ID>().name = nameMagazin;
            close[2].GetComponent<CloseItem>().name = nameMagazin;
            close[2].GetComponent<CloseItem>().spawn = this;
            Btn_ID.ID = i;

            
        }
        
    }
    public void Close(string name, bool close)
    {
        if (name == "Pricel")
        {
            if (close)
            {
                Destroy(original_pricel);
            }

        }
        if (name == "Dulo")
        {
            if (close)
            {
                Destroy(original_glush);
            }

        }
        if (name == "Magazin")
        {
            if (close)
            {
                Destroy(original_magazin);
            }

        }
    }
    public void CloseData(int ID, string name)
    {
        if (name == "Pricel")
        {
            main_shop.SpawnClose(ID, name);
        }
    }

    public void EventBtn_Pricel1(int index, string name)
    {
        if(name == "Pricel")
        {
           
            if (original_pricel)
            {
                Destroy(original_pricel);
            }

            original_pricel = Instantiate(prefab_pricel[index], Gun_Avtomat.transform);
            original_pricel.AddComponent<Pricel_ID>();
            original_pricel.GetComponent<Pricel_ID>().ID = index;
            original_pricel.GetComponent<Pricel_ID>().Name = name;
            original_pricel.GetComponent<Pricel_ID>().components = this;

            characteristic.charComp = original_pricel.GetComponent<CharComponent>();
            original_pricel.GetComponent<CharComponent>().characteristic = characteristic;
            characteristic.componentObj.pricel = original_pricel;


            PlayerPrefs.SetInt("ID", index);
            PlayerPrefs.SetString("NamePricel", name);

        }

        if (name == "Dulo")
        {
            if (original_glush)
            {
                Destroy(original_glush);
            }

            original_glush = Instantiate(prefab_glush[index], Gun_Avtomat.transform);

            original_glush.AddComponent<Dulol_ID>();
            original_glush.GetComponent<Dulol_ID>().ID = index;
            original_glush.GetComponent<Dulol_ID>().Name = name;

            characteristic.charComp = original_glush.GetComponent<CharComponent>();
            original_glush.GetComponent<CharComponent>().characteristic = characteristic;
            characteristic.componentObj.dulo = original_glush;

            PlayerPrefs.SetInt("ID_Dulo", index);
            PlayerPrefs.SetString("NameDulo", name);
        }
        if (name == "Magazin")
        {
            if (original_magazin)
            {
                Destroy(original_magazin);
            }

            original_magazin = Instantiate(prefab_magazin[index], Gun_Avtomat.transform);

            characteristic.charComp = original_magazin.GetComponent<CharComponent>();
            original_magazin.GetComponent<CharComponent>().characteristic = characteristic;
            characteristic.componentObj.magazine = original_magazin;

            original_magazin.AddComponent<Magazin_ID>();
            original_magazin.GetComponent<Magazin_ID>().ID = index;
            original_magazin.GetComponent<Magazin_ID>().Name = name;

            PlayerPrefs.SetInt("ID_Magazin", index);
            PlayerPrefs.SetString("NameMagazin", name);
        }

    }

}
