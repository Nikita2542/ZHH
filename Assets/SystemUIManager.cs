
using TMPro;
using UnityEngine;


public class SystemUIManager : MonoBehaviour
{
   
    [Header("UI")]
    public GameObject editMode;
    [Header("Вспомогательные кнопки")]
    public GameObject G;
    public GameObject Esc;
    public GameObject F;
    [Header("Вспомогательные кнопки мыши")]
    public GameObject leftMouse;
    [Header("Вспомогательный текст")]
    public TextMeshProUGUI textHelp;
    [Header("Вспомогательные кнопки Switch")]
    public GameObject keySwitch;
    [Header("Информация")]
    public GameObject textInfo;
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI descriptionText;
    [Header("СКРИПТ")]
    public RedactorPlayer script;

    [Header("Проверка")]
    public bool activeSelect;
    
    void Start()
    {
        editMode.SetActive(false);
        Esc.SetActive(false);
        textHelp.gameObject.SetActive(false);
        textInfo.SetActive(false);
        keySwitch.SetActive(false);
        F.SetActive(false);


    }

    void Update()
    {
        EditMode();
        SelectObj();
        //ForListCollider();
    }
    public void EditMode()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            ForListColliderTrue();
            script.invert = true;
           
            script.activeGetCar = false;
        }
        
        if (activeSelect == false)
        {
            editMode.SetActive(script.invert);
            if (script.invert)
            {
                if (script.activeGologram == false)
                {
                    if(script.activeZoomCamera == false)
                    {
                        if (Input.GetKeyDown(KeyCode.Tab))
                        {
                            ForListColliderFalse();


                            script.invert = false;

                        }
                    }                    
                }
                    
            }
        }
        if (script.activeGetCar)
        {
            F.SetActive(true);
        }
        else
        {
            F.SetActive(false);
        }
        
        if(script.activeObject == false)
        {
            leftMouse.SetActive(script.activeGologram);
        }
        G.SetActive(!script.invert);
        Esc.SetActive(script.invert);
    }
    public void SelectObj()
    {
        if (script.activeGologram)
        {   
            if (Input.GetMouseButtonDown(0))
            {
                script.ID = script.mainColliderObj.objectSpawn[script.MainID].id;
                textInfo.SetActive(true);
                keySwitch.SetActive(true);
                script.spawnHologram.SpawnHologram(script.ID, script.MainID);
                script.activeObject = true;
                ForList();
                ForListColliderFalse();
                
                activeSelect = true;
                leftMouse.SetActive(false);
                
            }
        }
        if (script.activeObject)
        { 
            if (script.spawnHologram.hologramObj[script.MainID].hologramModel)
            {
                if (Input.GetKeyUp(KeyCode.Tab))
                {
                    ForListColliderTrue();
                    Cursor.lockState = CursorLockMode.Locked;
                    script.activeObject = false;
                    if (script.spawnHologram.hologramObj[script.MainID].hologramModel) Destroy(script.spawnHologram.hologramObj[script.MainID].hologramModel);
                    textInfo.SetActive(false);
                    keySwitch.SetActive(false);
                    activeSelect = false;                    
                }
            }

            Swith(script.MainID);
        }
    }
    public void Swith(int MainID)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (script.ID < script.spawnHologram.hologramObj[MainID].hologramPrefab.Length - 1)
            {
                script.ID += 1;
                script.mainColliderObj.objectSpawn[script.MainID].SpawnObj(script.ID);
                //script.mainColliderObj.colliderObj[script.MainID].SpawnHologramObj(script.ID);
                script.spawnHologram.SpawnHologram(script.ID, script.MainID);
                headerText.text = script.spawnHologram.hologramObj[MainID].hologramModel.GetComponent<TextHologramWheel>().Name;
                descriptionText.text = script.spawnHologram.hologramObj[MainID].hologramModel.GetComponent<TextHologramWheel>().Description;
                

                ForList();
            }   
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
;
            if (script.ID > 0)
            {
                script.ID -= 1;
                script.mainColliderObj.colliderObj[script.MainID].SpawnHologramObj(script.ID);
                script.spawnHologram.SpawnHologram(script.ID, script.MainID);
                headerText.text = script.spawnHologram.hologramObj[MainID].hologramModel.GetComponent<TextHologramWheel>().Name;
                descriptionText.text = script.spawnHologram.hologramObj[MainID].hologramModel.GetComponent<TextHologramWheel>().Description;
                script.mainColliderObj.objectSpawn[script.MainID].SpawnObj(script.ID);

                ForList();
            }
        }
    }
    private void ForList()
    {
        script.mainColliderObj.objectSpawn[script.MainID].OutlineSpawn(!script.activeGologram);
        /*for (int i = 0; i < script.mainColliderObj.colliderObj[script.MainID].colliderObj.Length; i++)
        {
            script.mainColliderObj.objectSpawn[script.MainID].modelObj[i].SetActive(script.activeGologram);//Model

            script.mainColliderObj.colliderObj[script.MainID].hologramObj[i].SetActive(!script.activeGologram);//Hologram
        }*/
    }
    private void ForListColliderFalse()
    {
        for (int j = 0; j < script.mainColliderObj.colliderObj.Length; j++)
        {
            for (int i = 0; i < script.mainColliderObj.colliderObj[j].colliderObj.Length; i++)
            {
                script.mainColliderObj.colliderObj[j].colliderObj[i].gameObject.SetActive(false);//Collider
            }
        }
       
    }
    private void ForListColliderTrue()
    {
        for (int j = 0; j < script.mainColliderObj.colliderObj.Length; j++)
        {
            for (int i = 0; i < script.mainColliderObj.colliderObj[j].colliderObj.Length; i++)
            {
                script.mainColliderObj.colliderObj[j].colliderObj[i].gameObject.SetActive(true);//Collider
            }
        }
    }
}
