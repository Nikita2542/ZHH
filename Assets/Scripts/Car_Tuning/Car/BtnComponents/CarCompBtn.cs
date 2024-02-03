using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;
using System;


public class CarCompBtn : MonoBehaviour
{
    Camera mainCamera;

    [HideInInspector] public int ID;
    
    TextMeshProUGUI titleTextOrig;

    [HideInInspector] public Button[] compBtn;

    [HideInInspector] public Image[] cyrcleImage;
    [HideInInspector] public Image[] cyrcleImageActive;
    [HideInInspector] public Image[] ikonImage;
    [HideInInspector] public Image[] ikonImageActive;

    [HideInInspector] public CompOne[] compOne_Script;
    [HideInInspector] public CompOne[] compOneActive_Script;

    [Serializable]
    public class Parts
    {
        public string name;
        public Sprite ikon;//Сделать Массив
        
        public GameObject[] modelPref;


        [HideInInspector] public GameObject[] spawnObjBtn_Orig;
        [HideInInspector] public Button btn;
    }
    [Header("Настройка запчастей")]
    public Parts[] parts;
    public GameObject[] btnActivePref;
    [Header("Префабы")]
    public GameObject titleTextPref;
    public GameObject spawnObjBtn_Pref;

    [Header("Кнопка назад")]
    public Button backToSmena;

    [HideInInspector] public GameObject[] modelOrig;
    [HideInInspector] public GameObject Main_btn;

    
    

    [HideInInspector] public Transform[] parent;
    [HideInInspector] public Transform partsCar;
    [HideInInspector] public Transform arrow;
    
    

    [HideInInspector] public CarCharacteristic characteristic;
    [HideInInspector] public CarPositionCamera carPos;

    [HideInInspector] public int switcher;

    
    [HideInInspector]public GameObject[] origBtnActive;
    [HideInInspector] public Transform buttonActive;
    [HideInInspector] public Transform buttonComp;
    [HideInInspector] public Transform buttonParts;
    [HideInInspector] public Transform carZonaRot;

    

    [HideInInspector] public Button back;
    [HideInInspector] public bool boolComp;
    [HideInInspector] public bool boolActive;

    [HideInInspector] public CompID[] compID;
    int idComp;
    [HideInInspector] public int idActive;
    [HideInInspector] public bool boolImage;
    public CarSwitch carSwitch_Script;
    void Start()
    {
        StartGo();
    }

    private void Update()
    {
        
    }
    public void StartGo()
    {
        mainCamera = Camera.main;

        carPos = GetComponent<CarPositionCamera>();

        partsCar = GameObject.FindGameObjectWithTag("PartsCar").transform;
        arrow = GameObject.FindGameObjectWithTag("Arrow").transform;
        characteristic = GameObject.FindGameObjectWithTag("CarCharacteristics").GetComponent<CarCharacteristic>();
        buttonParts = GameObject.FindGameObjectWithTag("ButtonParts").transform;
        buttonActive = GameObject.FindGameObjectWithTag("ButtonActive").transform;
        buttonComp = GameObject.FindGameObjectWithTag("ButtonComponents").transform;
        carZonaRot = GameObject.FindGameObjectWithTag("CarZonaRot").transform;
        back = GameObject.FindGameObjectWithTag("BtnBack").GetComponent<Button>();

        #region new []
        modelOrig = new GameObject[buttonParts.childCount];

        parent = new Transform[buttonParts.childCount];

        compBtn = new Button[buttonParts.childCount];
        
        cyrcleImage = new Image[buttonParts.childCount];
        cyrcleImageActive = new Image[btnActivePref.Length];
        ikonImage = new Image[buttonParts.childCount];
        ikonImageActive = new Image[btnActivePref.Length];

        compOne_Script = new CompOne[buttonParts.childCount];
        compOneActive_Script = new CompOne[btnActivePref.Length];

        origBtnActive = new GameObject[btnActivePref.Length];
        
        for(int i = 0; btnActivePref.Length > i; i++)
        {
            for (int j = 0; j < parts[i].modelPref.Length; j++)
            {
                parts[i].spawnObjBtn_Orig = new GameObject[parts[j].modelPref.Length];
                compID = new CompID[parts[j].modelPref.Length];
            }
        }
        
        

        #endregion

        Main_btn = arrow.GetChild(0).gameObject;
       
        back.onClick.AddListener(Back);

        Main_btn.SetActive(true);

        back.gameObject.SetActive(false);
        backToSmena.gameObject.SetActive(true);
        boolComp = true;
        boolActive = false;
        for (int i = 0; i < buttonParts.childCount; i++)
        {
            parts[i].btn = buttonParts.GetChild(i).GetComponent<Button>();
            parts[i].btn.onClick.AddListener(ButtonTouch);
            parent[i] = partsCar.GetChild(i);

            compBtn[i] = buttonParts.GetChild(i).GetComponent<Button>();

            cyrcleImage[i] = compBtn[i].transform.GetChild(0).GetComponent<Image>();
            ikonImage[i] = compBtn[i].transform.GetChild(1).GetComponent<Image>();

            compOne_Script[i] = compBtn[i].AddComponent<CompOne>();
            compOne_Script[i].ID = i;
            compOne_Script[i].carBtn = this;
            compOne_Script[i].StartGo();
  
            EventTrigger trigger = compBtn[i].GetComponent<EventTrigger>();

            EventTrigger.Entry entryEnter = new EventTrigger.Entry();
            entryEnter.eventID = EventTriggerType.PointerEnter;
            entryEnter.callback.AddListener((data) => { EnterMouse((PointerEventData)data); });
            trigger.triggers.Add(entryEnter);

            EventTrigger.Entry entryExit = new EventTrigger.Entry();
            entryExit.eventID = EventTriggerType.PointerExit;
            entryExit.callback.AddListener((data) => { ExitMouse((PointerEventData)data); });
            trigger.triggers.Add(entryExit);

            cyrcleImage[i].enabled = false;
            ikonImage[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Белый цвет
        }
        boolImage = true;
    }

    public void ButtonTouch()
    {
        carPos.intPos = ID;
        carPos.intLook = ID;//передает зачение для позиций

        carPos.boolActiveMain = false;
        carPos.boolActive = true;

        if (modelOrig[ID])
        {
            Destroy(modelOrig[ID]);
        }
        buttonParts.gameObject.SetActive(false);

        boolComp = false;
        boolActive = true;
        for (int i = 0; i < btnActivePref.Length; i++)
        {
            origBtnActive[i] = Instantiate(btnActivePref[i], buttonActive);
            origBtnActive[i].GetComponent<Button>().onClick.AddListener(ButtonActive);
            cyrcleImageActive[i] = origBtnActive[i].transform.GetChild(0).GetComponent<Image>();
            ikonImageActive[i] = origBtnActive[i].transform.GetChild(1).GetComponent<Image>();

            compOneActive_Script[i] = origBtnActive[i].AddComponent<CompOne>();
            compOneActive_Script[i].ID = i;
            compOneActive_Script[i].carBtn = this;
            compOneActive_Script[i].StartGo();


            EventTrigger trigger = origBtnActive[i].GetComponent<EventTrigger>();

            EventTrigger.Entry entryEnter = new EventTrigger.Entry();
            entryEnter.eventID = EventTriggerType.PointerEnter;
            entryEnter.callback.AddListener((data) => { EnterMouseActive((PointerEventData)data); });
            trigger.triggers.Add(entryEnter);

            EventTrigger.Entry entryExit = new EventTrigger.Entry();
            entryExit.eventID = EventTriggerType.PointerExit;
            entryExit.callback.AddListener((data) => { ExitMouseActive((PointerEventData)data); });
            trigger.triggers.Add(entryExit);

            cyrcleImageActive[i].enabled = false;
            ikonImageActive[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Белый цвет
        }
        

        /*carZonaRot.GetComponent<CarRotation>().Car_Rot.transform.localRotation = carZonaRot.GetComponent<CarRotation>().rotationOriginal;
        carZonaRot.GetComponent<CarRotation>().enabled = false;*/

        Main_btn.SetActive(false);
        
        back.gameObject.SetActive(true);
        backToSmena.gameObject.SetActive(false);
        for (int i = 0; i < parts[idActive].modelPref.Length; i++)
        {
            if (parts[idActive].spawnObjBtn_Orig[i])
            {
                Destroy(parts[idActive].spawnObjBtn_Orig[i]);
            }

        }
        for (int i = 0; i < parts[ID].modelPref.Length; i++)
        {
            if (parts[ID].spawnObjBtn_Orig[i])
            {
                Destroy(parts[ID].spawnObjBtn_Orig[i]);
            }

        }

        for (int i = 0; i < parts[ID].modelPref.Length; i++)
        {
            parts[ID].spawnObjBtn_Orig[i] = Instantiate(spawnObjBtn_Pref, buttonComp);

            compID[i] = parts[ID].spawnObjBtn_Orig[i].AddComponent<CompID>();
            compID[i].ID = i;
            compID[i].carComp = this;

            Button btn = parts[ID].spawnObjBtn_Orig[i].GetComponent<Button>();
            btn.onClick.AddListener(CompSelect);

            TextMeshProUGUI text = parts[ID].spawnObjBtn_Orig[i].transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            int iPl = i + 1;
            text.text = parts[ID].name + " " + iPl + "lv";

            Image image = parts[ID].spawnObjBtn_Orig[i].transform.GetChild(2).GetComponent<Image>();
            image.sprite = parts[ID].ikon;

        }


        /*for (int i = 0; i < parts[ID].prefabs.Length; i++)
        {
            parts[ID].origComp[i] = Instantiate(prefComp, buttonComp);

            compID[i] = parts[ID].origComp[i].AddComponent<CompID>();
            compID[i].ID = i;
            compID[i].carComp = this;

            Button btn = parts[ID].origComp[i].GetComponent<Button>();
            btn.onClick.AddListener(CompSelect);

            TextMeshProUGUI text = parts[ID].origComp[i].transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            int iPl = i + 1;
            text.text = parts[ID].name + " " + iPl + "lv";

            Image image = parts[ID].origComp[i].transform.GetChild(2).GetComponent<Image>();
            image.sprite = parts[ID].ikon;

        }*/
    }
    public void ButtonActive()
    {
        for (int i = 0; i < btnActivePref.Length; i++)
        {
            cyrcleImageActive[i].enabled = false;
            cyrcleImageActive[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Черный цвет
            ikonImageActive[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Черный цвет
        }

        if (ID <= btnActivePref.Length)
        {
            cyrcleImageActive[ID].enabled = true;
            cyrcleImageActive[ID].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Черный цвет
            ikonImageActive[ID].color = new Color(0.2f, 0.2f, 0.2f, 1f);//Белый цвет
            boolImage = false;
        }

        carPos.intPos = ID;
        carPos.intLook = ID;//передает зачение для позиций

        carPos.boolActiveMain = false;
        carPos.boolActive = true;


        for (int i = 0; i < parts[idActive].modelPref.Length; i++)
        {
            if (parts[idActive].spawnObjBtn_Orig[i])
            {
                Destroy(parts[idActive].spawnObjBtn_Orig[i]);
            }

        }
        for (int i = 0; i < parts[ID].modelPref.Length; i++)
        {
            if (parts[ID].spawnObjBtn_Orig[i])
            {
                Destroy(parts[ID].spawnObjBtn_Orig[i]);
            }

        }

        if (modelOrig[ID])
        {
            Destroy(modelOrig[ID]);
        }    

        for (int i = 0; i < parts[ID].modelPref.Length; i++)
        {
            parts[ID].spawnObjBtn_Orig[i] = Instantiate(spawnObjBtn_Pref, buttonComp);

            compID[i] = parts[ID].spawnObjBtn_Orig[i].AddComponent<CompID>();
            compID[i].ID = i;
            compID[i].carComp = this;

            Button btn = parts[ID].spawnObjBtn_Orig[i].GetComponent<Button>();
            btn.onClick.AddListener(CompSelect);

            TextMeshProUGUI text = parts[ID].spawnObjBtn_Orig[i].transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            int iPl = i + 1;
            text.text = parts[ID].name + " " + iPl + "lv";

            Image image = parts[ID].spawnObjBtn_Orig[i].transform.GetChild(2).GetComponent<Image>();
            image.sprite = parts[ID].ikon;

        }
        idActive = ID;

        
    }
    public void Comp(int id)
    {
        for (int i = 0; i < parts[ID].modelPref.Length; i++)
        {
            if (modelOrig[i])
            {
                Destroy(modelOrig[i].gameObject);
            }
        }
        modelOrig[id] = Instantiate(parts[ID].modelPref[id], parent[ID]);
        if(ID == 1)
        {
            carSwitch_Script.car_original.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            carSwitch_Script.car_original.transform.GetChild(0).gameObject.SetActive(true);
        }
        modelOrig[id].GetComponent<CarCharComponents>().characteristic = characteristic;
        idComp = id;
    }
    public void CompExit(int id)
    {
        for(int i = 0; i< parts[ID].modelPref.Length; i++)
        {
            if (modelOrig[id])
            {
                Destroy(modelOrig[id].gameObject);
            }
            if (parts[ID].spawnObjBtn_Orig[i].GetComponent<CompID>().active)
            {
                modelOrig[i] = Instantiate(parts[ID].modelPref[i], parent[ID]);
                modelOrig[i].GetComponent<CarCharComponents>().characteristic = characteristic;
            }
        }
        
               
    }
    public void CompSelect()
    {
        for(int i = 0; i < parts[ID].modelPref.Length; i++)
        {
            if (parts[ID].spawnObjBtn_Orig[i])
            {
                Image selectIm = parts[ID].spawnObjBtn_Orig[i].transform.GetChild(0).GetComponent<Image>();
                selectIm.color = new Color(0.0f, 0.0f, 0.0f, 1);
                parts[ID].spawnObjBtn_Orig[i].GetComponent<CompID>().active = false;
            }
            
        }
        Image select = parts[ID].spawnObjBtn_Orig[idComp].transform.GetChild(0).GetComponent<Image>();
        select.color = new Color(0.3f, 0.7f, 1, 1);
        parts[ID].spawnObjBtn_Orig[idComp].GetComponent<CompID>().active = true;
    }
    private void Back()
    {
        carPos.boolActiveMain = true;
        carPos.boolActive = false;
        if (modelOrig[ID])
        {
            Destroy(modelOrig[ID]);
        }
        buttonParts.gameObject.SetActive(true);

        for (int i = 0; i < btnActivePref.Length; i++)
        {
            Destroy(origBtnActive[i].gameObject);
        }
        for (int i = 0; i < parts[idActive].modelPref.Length; i++)
        {
            if (parts[idActive].spawnObjBtn_Orig[i])
            {
                Destroy(parts[idActive].spawnObjBtn_Orig[i]);
            }

        }

        carZonaRot.GetComponent<CarRotation>().enabled = true;

        Main_btn.SetActive(true);
        
        back.gameObject.SetActive(false);
        backToSmena.gameObject.SetActive(true);
    }
   
    public void EnterMouse(PointerEventData data)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            cyrcleImage[i].enabled = false;
            ikonImage[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Белый цвет
        }
        if (titleTextOrig)
        {
            Destroy(titleTextOrig.gameObject);
        }
        titleTextOrig = Instantiate(titleTextPref.GetComponent<TextMeshProUGUI>(), compBtn[ID].transform);
        titleTextOrig.text = compBtn[ID].gameObject.name;

        cyrcleImage[ID].enabled = true;
        ikonImage[ID].color = new Color(0.2f, 0.2f, 0.2f, 1f);//Черный цвет
    }
    public void ExitMouse(PointerEventData data)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            cyrcleImage[i].enabled = false;
            ikonImage[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Белый цвет
        }
        if (titleTextOrig)
        {
            Destroy(titleTextOrig.gameObject);
        }
        cyrcleImage[ID].enabled = false;
        ikonImage[ID].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Белый цвет
    }
    public void EnterMouseActive(PointerEventData data)
    {
        for (int i = 0; i < btnActivePref.Length; i++)
        {
            cyrcleImageActive[i].enabled = false;
            cyrcleImageActive[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Черный цвет
            ikonImageActive[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Белый цвет
        }
        if(ID <= btnActivePref.Length)
        {
            cyrcleImageActive[ID].enabled = true;
            cyrcleImageActive[ID].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Черный цвет
            ikonImageActive[ID].color = new Color(0.2f, 0.2f, 0.2f, 1f);//Черный цвет
        }
        
    }
    public void ExitMouseActive(PointerEventData data)
    {
        if (boolImage)
        {
            for (int i = 0; i < btnActivePref.Length; i++)
            {
                cyrcleImageActive[i].enabled = false;
                cyrcleImageActive[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Черный цвет
                ikonImageActive[i].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Белый цвет
            }

            if (ID <= btnActivePref.Length)
            {
                cyrcleImageActive[ID].enabled = false;
                cyrcleImageActive[ID].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Черный цвет
                ikonImageActive[ID].color = new Color(0.8f, 0.8f, 0.8f, 1f);//Белый цвет
            }
        }
        
        
        
    }
}
