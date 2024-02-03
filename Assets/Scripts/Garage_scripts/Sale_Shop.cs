using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.Drawing;
using System.Diagnostics;



public class Sale_Shop : MonoBehaviour
{
    
    public Image locked;
    public Button shop;
    public TextMeshProUGUI text;
    public int point;
    public string name;

    public Button button;
    public GameObject Back_locked;

    public int neoShop;
    public Main_Shop1 main_shop;


    void Start()
    {
       
        text = gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        locked = gameObject.transform.GetChild(2).GetChild(1).GetComponent<Image>();
        shop = gameObject.transform.GetChild(2).GetChild(0).GetComponent<Button>();
        button = gameObject.GetComponent<Button>();
        text.text = neoShop.ToString();
        main_shop = gameObject.GetComponentInParent<Main_Shop1>();
        shop.onClick.AddListener(Shop);
        Back_locked = gameObject.transform.GetChild(2).gameObject;

        button.interactable = false;
        text.text = neoShop.ToString();
    }
    public void Check()
    {
        for (int i = 0; i < point; i++)
        {
            neoShop += 10;
        }
        if(name == "pricel")
        {
            if (PlayerPrefs.HasKey("Pricel" + point))
            {
                neoShop = PlayerPrefs.GetInt("Pricel" + point);
            }
        }
        if (name == "glushak")
        {
            if (PlayerPrefs.HasKey("Glushak" + point))
            {
                neoShop = PlayerPrefs.GetInt("Glushak" + point);
            }
        }
        if (name == "horn")
        {
            if (PlayerPrefs.HasKey("Horn" + point))
            {
                neoShop = PlayerPrefs.GetInt("Horn" + point);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shop()
    {
        if (main_shop.neo >= neoShop)
        {           
            locked.gameObject.SetActive(false);
            shop.gameObject.SetActive(false);
            button.interactable = true;
            Destroy(Back_locked);
            main_shop.neo -= neoShop;
            neoShop = 0;
            if (name == "pricel")
            {
                PlayerPrefs.SetInt("Pricel" + point, neoShop);
            }
            if (name == "glushak")
            {
                PlayerPrefs.SetInt("Glushak" + point, neoShop);
            }
            if (name == "horn")
            {
                PlayerPrefs.SetInt("Horn" + point, neoShop);
            }
        }

    }
}
