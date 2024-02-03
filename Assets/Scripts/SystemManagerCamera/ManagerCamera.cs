using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class ManagerCamera : MonoBehaviour
{

    public Transform pointCar;
    public GameObject player;
    public GameObject ColliderGologram;
    public GameObject PointCarCollider;

    [Header("Âðåìÿ çàåçäà â ãàðàæ")]
    public float timeDec;
    public float timePointDec;
    [Header("UI")]
    public GameObject CarUI;
    public GameObject canvasMain;
    public Button SaveCollectionButton;
    public GameObject backEdit;
    [Header("Ñêðèïòû")]
    public GarageOpenDoor openDoor;
    public CameraRedactor cameraRedactor;
    public ButtonComponents buttonComponents;
    public RedactorPlayer redactorPlayer;
  
    float time;
    public float timePoint;
    bool active;

    [HideInInspector] public GameObject prefabPlayer;
    [HideInInspector] public bool Invert;
    public bool edit;
    public bool pointCarBool;
    public bool pointCarTransform;
   
    [HideInInspector] public Camera cameraMain;
    [HideInInspector] public GameObject carPlayer;

    GameObject GunMain;
   
    public void Start()
    {
        cameraMain = Camera.main;
        carPlayer = GameObject.FindGameObjectWithTag("Player");
        CarUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        backEdit.SetActive(false);
    }
    void Update()
    {
        EnterGarage();
        RayHit();
        if (pointCarTransform)
        {
            PointCarUpdate();
        }
        

    }
    public void EnterGarage()
    {
        if (pointCarBool)
        {
            if (Invert == false) //ÇÀÅÇÄ Â ÃÀÐÀÆ
            {
                if (openDoor.openActive)
                {
                    time = timeDec;
                    active = true;
                }
                if (active)
                {
                    if (time > 0)
                    {
                        time -= Time.deltaTime;
                    }
                    if (time <= 0) //ÌÀØÈÍÀ ÑÒÀÍÎÂÈÒÜÑß ÍÀ ÌÅÑÒÎ
                    {
                        CarPoint();
                        
                    }
                }
            }
        }
        
        if (edit)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                openDoor.openActive = false;
                CarPoint();
            }
        }
        
    }
    public void CarPoint()
    {
        
        

        carPlayer.GetComponent<RCC_CarControllerV3>().canControl = false;
        carPlayer.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
        carPlayer.GetComponent<Rigidbody>().isKinematic = true;
        carPlayer.transform.SetParent(pointCar);
        carPlayer.transform.localPosition = new Vector3(0, 0, 0);
        carPlayer.transform.localRotation = new Quaternion(0, 0, 0, 1);
        redactorPlayer.carPlayer = carPlayer;

        ColliderGologram = carPlayer.transform.GetChild(0).gameObject;
        ColliderGologram.SetActive(true);
        
        player.SetActive(true);
        timePoint = timePointDec;
        pointCarTransform = true;
        
        active = false;
        canvasMain.gameObject.SetActive(false);

        redactorPlayer.StartColliderHologram();
        PointCarCollider.SetActive(false);
        
      
    }
    public void PointCarUpdate()
    {
        if(timePoint > 0)
        {
            timePoint -= Time.deltaTime; 
        }
        if(timePoint <= 0)
        {
            carPlayer.GetComponent<RCC_CarControllerV3>().enabled = false;
            
            
            carPlayer.GetComponent<Rigidbody>().isKinematic = false;
            pointCarTransform = false;
        }

        
    }

    public void RayHit()
    {
        RaycastHit hit;
        if(Physics.Raycast(cameraMain.transform.position, cameraMain.transform.forward, out hit))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                if (pointCarBool)
                {
                    if (redactorPlayer.activeGetCar)
                    {
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            CarPlay();
                        }
                    }
                }
                
                
            }
        }
    }

    void CarPlay()
    {
        backEdit.SetActive(true);
        Invert = true;
        active = false;
        edit = true;
        canvasMain.gameObject.SetActive(true);
        ColliderGologram = carPlayer.transform.GetChild(0).gameObject;
        ColliderGologram.SetActive(false);

        carPlayer.GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
        carPlayer.GetComponent<RCC_CarControllerV3>().enabled = true;
        carPlayer.GetComponent<RCC_CarControllerV3>().canControl = true;
        carPlayer.GetComponent<Speedometr>().enabled = true;

        GunMain = carPlayer.GetComponentInChildren<CharacterAiming>().gameObject;
        GunMain.GetComponent<Animator>().enabled = true;
        GunMain.GetComponent<RigBuilder>().enabled = true;
        GunMain.GetComponent<CharacterAiming>().enabled = true;
        GunMain.GetComponent<ActivateWeapon>().enabled = true;

        player.SetActive(false);
        PointCarCollider.SetActive(true);
        openDoor.openActive = true;
        
    }
}
