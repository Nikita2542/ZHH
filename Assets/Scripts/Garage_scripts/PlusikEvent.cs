using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlusikEvent : MonoBehaviour
{
    public Camera Main_Camera;

    
    public Main_Shop1 main_Shop;
    public Button backToGuns;


    public TextMeshProUGUI textGun;

    public Transform select;
    
    public Button[] btnMain;
    
    public Transform[] Pos;
    public Transform[] Look;

    public string[] name;

    [HideInInspector] public int posInt;
    [HideInInspector] public int lookInt;

    UpVSPlus upVSPlus;
    public UpgrateGun upgrateGun;
    public GameObject pricel_ID;

    public bool upgrade;
    public Default_Setting gun;
   

    public void Start()
    {
        
        
        upVSPlus = GetComponentInParent<UpVSPlus>();
        backToGuns.onClick.AddListener(BackToGuns);
    }
    private void Update()
    {
        if (upgrade)
        {
            Main_Camera.transform.position = Vector3.Lerp(Main_Camera.transform.position, Pos[posInt].transform.position, Time.deltaTime * 2);
            Main_Camera.transform.LookAt(Look[lookInt].transform);
            upgrateGun.upgrade = false;
            Main_Camera.fieldOfView = 17f;
            
        }
       
    }
    public void WhoIS(int IQ, string name, Transform pos)
    {
        posInt = IQ;
        lookInt = IQ;
        textGun.text = name;
        select.position = pos.position;
        for (int i = 0; i < main_Shop.components.Length; i++)
        {
            main_Shop.components[i].SetActive(false);
        }
        
        main_Shop.components[IQ].SetActive(true);
    }
   
    public void EventPlus()
    {
        for(int i = 0; i < btnMain.Length; i++)
        {

            btnMain[i].gameObject.AddComponent<PlusikIQ>();
            btnMain[i].GetComponent<PlusikIQ>().plusikEvent = this;
            btnMain[i].GetComponent<PlusikIQ>().IQ = i;
            btnMain[i].GetComponent<PlusikIQ>().name = name[i];       
        }
    }

    void BackToGuns()
    {      
        upVSPlus.upgrateActive = true;
        upVSPlus.plusActive = false;
        upgrateGun.upgrade = true;
    }
}
