using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Main_Shop1 : MonoBehaviour
{
    public Button[] btn_p;
    public Button[] btn_glush;
    public Button[] btn_horn;

    public GameObject[] components;
    
    
    public Sale_Shop sale;


    public int neo;

    public GameObject prefab;
    public GameObject listPricel;
    public GameObject listGlush;
    public GameObject listHorn;


    public void Start()
    {
      

        for (int i = 1; i < btn_p.Length; i++)
        {
          
            btn_p[i].gameObject.AddComponent<Sale_Shop>();
            btn_p[i].gameObject.GetComponent<Sale_Shop>().name = "pricel";
            btn_p[i].gameObject.GetComponent<Sale_Shop>().point = i;
            btn_p[i].gameObject.GetComponent<Btn_ID>().mainShop = this;



            btn_p[i].GetComponent<Sale_Shop>().Check();

            if (btn_p[i].GetComponent<Sale_Shop>().neoShop > 0)
            {
                listPricel = Instantiate(prefab, btn_p[i].transform.position, Quaternion.identity);
                listPricel.transform.parent = btn_p[i].transform;
            }
            

        }
        for (int i = 1; i < btn_glush.Length; i++)
        {
            btn_glush[i].gameObject.AddComponent<Sale_Shop>();
            btn_glush[i].gameObject.GetComponent<Sale_Shop>().name = "glushak";
            btn_glush[i].gameObject.GetComponent<Sale_Shop>().point = i;
           
            btn_glush[i].GetComponent<Sale_Shop>().Check();
            if (btn_glush[i].GetComponent<Sale_Shop>().neoShop > 0)
            {
                listGlush = Instantiate(prefab, btn_glush[i].transform.position, Quaternion.identity);
                listGlush.transform.parent = btn_glush[i].transform;
            }
                

            
        }
        for (int i = 1; i < btn_horn.Length; i++)
        {

            btn_horn[i].gameObject.AddComponent<Sale_Shop>();
            btn_horn[i].gameObject.GetComponent<Sale_Shop>().name = "horn";
            btn_horn[i].gameObject.GetComponent<Sale_Shop>().point = i;

            btn_horn[i].GetComponent<Sale_Shop>().Check();
            if (btn_horn[i].GetComponent<Sale_Shop>().neoShop > 0)
            {
                listHorn = Instantiate(prefab, btn_horn[i].transform.position, Quaternion.identity);
                listHorn.transform.parent = btn_horn[i].transform;
            }



            }
        for (int i = 0; i < components.Length; i++)
        {
            components[i].SetActive(false);
        }
    }

    public void SpawnClose(int ID, string name)
    {
        if (name == "Pricel")
        {
            
            
            btn_p[ID].GetComponent<Btn_ID>().activeClose = true;
        }
    }
    public void CloseGG(int ID, string name)
    {
        if (name == "Pricel")
        {

            for (int i = 0; i < btn_p.Length; i++)
            {
                btn_p[ID].GetComponent<Btn_ID>().activeClose = false;
            }
           
        }
    }
}
 