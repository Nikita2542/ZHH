using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Container_Gun : MonoBehaviour
{
    public Button[] btn_gun;
    
    public GameObject prefab;
    public GameObject [] list;

    public int neo;
    public Button[] list_up;

    public Sale_Gun[] sale;

    public void Start()
    {

        for (int i = 0; i < btn_gun.Length; i++)
        {

            btn_gun[i] = gameObject.transform.GetChild(i).GetComponent<Button>();
            list[i] = Instantiate(prefab, btn_gun[i].transform.position, Quaternion.identity);
            list[i].transform.parent = btn_gun[i].transform;

            list_up[i] = btn_gun[i].transform.GetChild(1).GetComponent<Button>();


            list[i].transform.position = list_up[i].transform.position;
            sale[i] = btn_gun[i].gameObject.AddComponent<Sale_Gun>();
        }
        sale[0].name = "Avtomat";
        sale[1].name = "Pulemet";
    }
}
