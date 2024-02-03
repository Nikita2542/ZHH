using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Drawing;
using System.Net.Sockets;

public class Sale_Gun : MonoBehaviour
{
    public string name;

    public Container_Gun gun;
    public TextMeshProUGUI text;

    public int neoShop;

    public Button btn_sale;
    public Button btn_up;

    public void Start()
    {
        text = gameObject.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        btn_sale = gameObject.transform.GetChild(2).GetComponent <Button>();
        btn_up = gameObject.transform.GetChild (1).GetComponent<Button>();

        gun = gameObject.GetComponentInParent<Container_Gun>();
        
        btn_sale.gameObject.SetActive(true);
        btn_up.gameObject.SetActive(false);
        btn_up.enabled = false;
        btn_sale.onClick.AddListener(Shop);

        if (name == "Avtomat")
        {
            neoShop = 0;

        }
        if (name == "Pulemet")
        {
            neoShop = 50;

        }
        text.text = neoShop.ToString();


    }
    public void Update()
    {
        if (neoShop == 0)
        {
            btn_sale.gameObject.SetActive(false);
            btn_up.gameObject.SetActive(true);
            btn_up.enabled = true;
        }

    }
    public void Shop()
    {
        if (gun.neo >= neoShop)
        {
            
            
            gun.neo -= neoShop;
            neoShop = 0;
            btn_up .transform.position = btn_sale.transform.position;
        }

    }
}
