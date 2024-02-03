using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GunMainScripts : MonoBehaviour
{
    [Tooltip("Число, которое отвечает за то, что мы выбрали")]
    public int ID;
    public int Index_pricel;

    Vector3 start_position_zoni;
    public CameraFollow cameraFollow;
    public Item_Ikonki item_ikonki;
    public Transform pos_zona;
    
    public GameObject[] Guns;
    

    
    [HideInInspector] public int Clone_ID;
    //[HideInInspector] public Camera Main_Camera; 

    

    [Header("Главная позиция")]
    public GameObject Main_pos;
    public GameObject Main_look;
    
    [Header("Пули позиция")]
    public GameObject ammo_pos;
    public GameObject ammo_look;

    #region UI
    [Header("UI")]
    public GameObject plusik;
    public Button btn_Up;
    public GameObject Upgrade_gun;
    public GameObject back;

    
    public GameObject[] componentsUI;
    #endregion

   

    #region pos & look
    [Header("Апгрейд позиция")]
    [HideInInspector] public GameObject UP_pos;
    [HideInInspector] public GameObject UP_look;

    [Header("Прицел позиция")]
    [HideInInspector] public GameObject Pricel_pos;
    [HideInInspector] public GameObject Pricel_look;

    [Header("Глушак позиция")]
    [HideInInspector] public GameObject Glushak_pos;
    [HideInInspector] public GameObject Glushak_look;

    [Header("kickback_position")]
    [HideInInspector] public GameObject Kickback_pos;
    [HideInInspector] public GameObject Kickback_look;

    [Header("Магазин позиция")]
    [HideInInspector] public GameObject horn_pos;
    [HideInInspector] public GameObject horn_look;
    #endregion

    #region Bool
    [HideInInspector] public bool avtomat, pulemet, sniper;
    [HideInInspector] public bool Active_main;
    [HideInInspector] public bool Active_Up;
    [HideInInspector] public bool Active_pricel;
    [HideInInspector] public bool Active_glushak;
    [HideInInspector] public bool Active_kickback;
    [HideInInspector] public bool Active_horn;
    [HideInInspector] public bool Active_ammo;
    #endregion

    void Start()
    {
        start_position_zoni = cameraFollow.transform.position;

        if (PlayerPrefs.HasKey("ID"))
        {
            Clone_ID = PlayerPrefs.GetInt("ID");
        }

       // Main_Camera = Camera.main;
        
        #region pos & look
        
        
        Pricel_pos = transform.GetChild(1).GetChild(1).gameObject;
        Pricel_look = transform.GetChild(0).GetChild(1).gameObject;
        Glushak_pos = transform.GetChild(1).GetChild(2).gameObject;
        Glushak_look = transform.GetChild(0).GetChild(2).gameObject;
        Kickback_pos = transform.GetChild(1).GetChild(3).gameObject;
        Kickback_look = transform.GetChild(0).GetChild(3).gameObject;
        horn_pos = transform.GetChild(1).GetChild(4).gameObject;
        horn_look = transform.GetChild(0).GetChild(4).gameObject;
        #endregion

        #region Component UI
        componentsUI[0].gameObject.SetActive(false);
        componentsUI[1].gameObject.SetActive(false);
        componentsUI[2].gameObject.SetActive(false);
        componentsUI[3].gameObject.SetActive(false);
        componentsUI[4].gameObject.SetActive(false);
        #endregion

        #region true & false
        Active_main = true;
        Active_Up = false;
        Active_pricel = false;
        Active_glushak = false;
        Active_kickback = false;
        Active_horn = false;
        Active_ammo = false;

        avtomat = false;
        pulemet = false;
        sniper = false;
        //Main_Camera.enabled = true;
        btn_Up.enabled = false;
        cameraFollow.gameObject.SetActive(false);

        Upgrade_gun.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        plusik.gameObject.SetActive(false);
        #endregion 
    }

    void Update()
    {
        
        // Автомат
        if (avtomat == true)
        {
            Guns[0].gameObject.SetActive(true);

        }
        else
        {
            Guns[0].gameObject.SetActive(false);
        }

        // Пулемет
        if (pulemet == true)
        {
            Guns[1].gameObject.SetActive(true);
        }
        else
        {
            Guns[1].gameObject.SetActive(false);
        }

        // Снайпа
        if (sniper == true)
        {
            Guns[2].gameObject.SetActive(true);


        }
        else
        {
            Guns[2].gameObject.SetActive(false);
        }

        #region Active All
       /* if (Active_main == true)
        {
            Main_Camera.transform.position = Vector3.Lerp(Main_Camera.transform.position, Main_pos.transform.position, Time.deltaTime * 2);
            Main_Camera.transform.LookAt(Main_look.transform);

        }
 
        if (Active_pricel == true)
        {
            Main_Camera.transform.position = Vector3.Lerp(Main_Camera.transform.position, Pricel_pos.transform.position, Time.deltaTime * 2);
            Main_Camera.transform.LookAt(Pricel_look.transform);
        }
        if (Active_glushak == true)
        {
            Main_Camera.transform.position = Vector3.Lerp(Main_Camera.transform.position, Glushak_pos.transform.position, Time.deltaTime * 2);
            Main_Camera.transform.LookAt(Glushak_look.transform);
        }
        if (Active_kickback == true)
        {
            Main_Camera.transform.position = Vector3.Lerp(Main_Camera.transform.position, Kickback_pos.transform.position, Time.deltaTime * 2);
            Main_Camera.transform.LookAt(Kickback_look.transform);
        }
        if (Active_horn == true)
        {
            Main_Camera.transform.position = Vector3.Lerp(Main_Camera.transform.position, horn_pos.transform.position, Time.deltaTime * 2);
            Main_Camera.transform.LookAt(horn_look.transform);
        }
        if (Active_ammo == true)
        {
            Main_Camera.transform.position = Vector3.Lerp(Main_Camera.transform.position, ammo_pos.transform.position, Time.deltaTime * 2);
            Main_Camera.transform.LookAt(ammo_look.transform);
        }*/
        #endregion
    }

    public void ActivateAvtomat()
    {
        avtomat = true;

        pulemet = false; sniper = false;

        btn_Up.enabled = true;
        
    }
    public void ActivatePulemet()
    {
        pulemet = true;

        avtomat = false; sniper = false;


    }
    public void ActivateSniper()
    {
        sniper = true;

        avtomat = false; pulemet = false;

    }

    public void EventMain()
    {
        Active_main = true;
        Active_glushak = false;
        Active_pricel = false;
        
        Active_kickback = false;
        Active_horn = false;
        Active_ammo = false;

        back.gameObject.SetActive(false);
        plusik.gameObject.SetActive(false);
        Upgrade_gun.gameObject.SetActive(true);      
    }
    public void EventUP()
    {    
        
        Active_pricel = false;
        Active_glushak = false;
        Active_main = false;
        Active_kickback = false;
        Active_horn = false;
        Active_ammo = false;

        plusik.gameObject.SetActive(true);
        Upgrade_gun.gameObject.SetActive(false);
        back.gameObject.SetActive(true);

        cameraFollow.gameObject.SetActive(true);
        cameraFollow.GetComponent<RectTransform>().sizeDelta = new Vector2(1475, 255);
        cameraFollow.transform.position = start_position_zoni;
    }
    public void EventPricel()
    {    
        Active_pricel = true;
        Active_glushak = false;
        Active_main = false;
        
        Active_kickback = false;
        Active_horn = false;
        Active_ammo = false;

        plusik.gameObject.SetActive(false);
        componentsUI[0].gameObject.SetActive(true);

        cameraFollow.GetComponent<RectTransform>().sizeDelta = new Vector2(1825, 558);
        cameraFollow.transform.position = pos_zona.position;
    }
    public void EventGlushak()
    {
        Active_glushak = true;
        Active_pricel = false;
        Active_main = false;
        
        Active_kickback = false;
        Active_horn = false;
        Active_ammo = false;

        plusik.gameObject.SetActive(false);
        componentsUI[1].gameObject.SetActive(true);

    }
    public void EventKickback()
    {
        Active_kickback = true;
        Active_glushak = false;
        Active_pricel = false;
        Active_main = false;
       
        Active_horn = false;
        Active_ammo = false;

        plusik.gameObject.SetActive(false);
        componentsUI[2].gameObject.SetActive(true);
    }
    public void EventHorn()
    {
        Active_horn = true;
        Active_glushak = false;
        Active_pricel = false;
        Active_main = false;
        
        Active_kickback = false;
        Active_ammo = false;

        plusik.gameObject.SetActive(false);
        componentsUI[3].gameObject.SetActive(true);
    }
    public void EventAmmunition()
    {
        Active_ammo = true;
        Active_glushak = false;
        Active_pricel = false;
        Active_main = false;
       
        Active_kickback = false;
        Active_horn = false;

        plusik.gameObject.SetActive(false);
        componentsUI[4].gameObject.SetActive(true);
    }
    public void Back()
    {
        if (Active_Up == true)
        {
            EventMain();
            for (int i = 0; i < componentsUI.Length; i++)
            {
                componentsUI[i].gameObject.SetActive(false);
            }
        }
        if (Active_pricel == true)
        {
            EventUP();
            for (int i = 0; i < componentsUI.Length; i++)
            {
                componentsUI[i].gameObject.SetActive(false);
            }
            cameraFollow.GetComponent<RectTransform>().sizeDelta = new Vector2(1475, 255);
            cameraFollow.transform.position = start_position_zoni;
        }
        if (Active_glushak == true)
        {
            EventUP();
            for (int i = 0; i < componentsUI.Length; i++)
            {
                componentsUI[i].gameObject.SetActive(false);
            }
            cameraFollow.GetComponent<RectTransform>().sizeDelta = new Vector2(1475, 255);
            cameraFollow.transform.position = start_position_zoni;
        }
        if (Active_kickback == true)
        {
            EventUP();
            for (int i = 0; i < componentsUI.Length; i++)
            {
                componentsUI[i].gameObject.SetActive(false);
            }
            cameraFollow.GetComponent<RectTransform>().sizeDelta = new Vector2(1475, 255);
            cameraFollow.transform.position = start_position_zoni;
        }
        if (Active_horn == true)
        {
            EventUP();
            for(int i = 0; i < componentsUI.Length; i++)
            {
                componentsUI[i].gameObject.SetActive(false);
            }
            cameraFollow.GetComponent<RectTransform>().sizeDelta = new Vector2(1475, 255);
            cameraFollow.transform.position = start_position_zoni;
        }
        if (Active_ammo == true)
        {
            EventUP();
            for (int i = 0; i < componentsUI.Length; i++)
            {
                componentsUI[i].gameObject.SetActive(false);
            }
            cameraFollow.GetComponent<RectTransform>().sizeDelta = new Vector2(1475, 255);
            cameraFollow.transform.position = start_position_zoni;
        }

    }
    
}









