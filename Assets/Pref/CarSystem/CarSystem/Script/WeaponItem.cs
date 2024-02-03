using UnityEngine;


public class WeaponItem : MonoBehaviour
{
    public int pricelID;
    public int magazinID;
    public int duloID;

    [Header("Original")]
    [Space(5)]
    [Tooltip("������� �������� � ����� �������")]
    public GameObject pricel;
    [Tooltip("������� �������� � ����� ��������")]
    public GameObject magazin;
    [Tooltip("������� �������� � ����� ��������")]
    public GameObject dulo;
    
    [Header("Parent")]
    [Space(5)]
    [Tooltip("������� ����� � ������� ��������� ������")]
    public Transform pricelParent;
    [Tooltip("������� ����� � ������� ��������� �������")]
    public Transform magazinParent;
    [Tooltip("������� ����� � ������� ��������� ����")]
    public Transform duloParent;

    [Header("Prefabs")]
    [Space(5)]
    [Tooltip("������� ������ �������")]
    public GameObject[] prefabPricel;
    [Space(10)]
    [Tooltip("������� ������ ��������")]
    public GameObject[] prefabMagazin;
    [Space(10)]
    [Tooltip("������� ������ ����")]
    public GameObject[] prefabDulo;
    [Space(5)]

    [HideInInspector] public RaycastWeapon weapon;

    Magazin magazinScript;
    WeaponReload reload;

    public void SpawnPricel(int id)
    {
        PickUp_pricel(prefabPricel[id], "pricel");
    }

    public void SpawnMagazin(int id)
    {
        PickUp_magazin(prefabMagazin[id], "magazin");
    }
    public void SpawnDulo(int id)
    {
        PickUp_dulo(prefabDulo[id], "dulo");
    }

    public void PickUp_pricel(GameObject Item, string ItemName)
    {
        if (pricel)
        {
            Destroy(pricel);    
        }  

        if (ItemName == "pricel")
        {
            pricel = Instantiate(Item, pricelParent);
        }
    }

    public void PickUp_magazin(GameObject Item, string ItemName)
    {
        if (magazin)
        {
            Destroy(magazin);
        }

        if (ItemName == "magazin")
        {
            magazin = Instantiate(Item, magazinParent);

            magazinScript = magazin.GetComponent<Magazin>();
            reload = GetComponent<WeaponReload>();

            weapon.clipSize = magazinScript.clipSize;
            reload.durectionReload = magazinScript.durectionReload;
        }   
    }
    public void PickUp_dulo(GameObject Item, string ItemName)
    {
        if (dulo)
        {
            Destroy(dulo);
        }

        if (ItemName == "dulo")
        {
            dulo = Instantiate(Item, duloParent);
        }
    }
}
