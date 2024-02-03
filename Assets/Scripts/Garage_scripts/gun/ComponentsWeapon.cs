using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsWeapon : MonoBehaviour
{
    public GameObject Gun_Avtomat;
    public GameObject[] prefPricel;
    public GameObject[] prefDulo;
    public GameObject[] prefMagazine;

    GameObject original_pricel;
    GameObject original_glush;
    GameObject original_magazin;

    int pricelID;
    string pricelName;

    int duloID;
    string duloName;

    int magazinID;
    string magazinName;
    private void Start()
    {
        pricelID = PlayerPrefs.GetInt("ID");
        pricelName = PlayerPrefs.GetString("NamePricel");

        EventBtn_Pricel1(pricelID, pricelName);

        duloID = PlayerPrefs.GetInt("ID_Dulo");
        duloName = PlayerPrefs.GetString("NameDulo");

        EventBtn_Pricel1(duloID, duloName);

        magazinID = PlayerPrefs.GetInt("ID_Magazin");
        magazinName = PlayerPrefs.GetString("NameMagazin");

        EventBtn_Pricel1(magazinID, magazinName);
    }
    public void EventBtn_Pricel1(int index, string name)
    {
        if (name == "Pricel")
        {
            if (original_pricel)
            {
                Destroy(original_pricel);
            }

            original_pricel = Instantiate(prefPricel[index], Gun_Avtomat.transform);
        }

        if (name == "Dulo")
        {
            if (original_glush)
            {
                Destroy(original_glush);
            }

            original_glush = Instantiate(prefDulo[index], Gun_Avtomat.transform);
        }
        if (name == "Magazin")
        {
            if (original_magazin)
            {
                Destroy(original_magazin);
            }

            original_magazin = Instantiate(prefMagazine[index], Gun_Avtomat.transform);
        }

    }
}
