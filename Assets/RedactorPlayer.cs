using Cinemachine;
using UnityEngine;

public class RedactorPlayer : MonoBehaviour
{
    [Header("ID Êîëåñà")]
    public int ID;
    public int MainID;

    [Header("ÊÀÌÅÐÀ")]
    public Camera cameraMain;
    public CinemachineVirtualCamera virtualCamera;

    [Header("Ïîëå çðåíèÿ")]
    public float normalFOV;
    public float editFov;
    public float speedFov;
    [Space(10)]
    public float valueObj;
    public float speedObj_0;
    public float speedObj_1;

    [Header("ÑÊÐÈÏÒ")]
    public SpawnGologram spawnHologram;
    public ColliderObject colliderObj;
    public MainColliderObject mainColliderObj;

    [Header("CAR")]
    public GameObject carPlayer;

    [Header("Ïðîâåðêà")]
    public bool activeRegactor;
    public bool invert;

    public bool activeGologram;
    public bool activeObject;

    public bool activeGetCar;

    public bool activeZoomCamera;
    private void Start()
    {
        cameraMain = Camera.main;
        virtualCamera.m_Lens.FieldOfView = normalFOV;
    }
    void Update()
    {
        Checking();
        SelectObject();
        CameraZoom();
    }
    private void RayHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraMain.transform.position, cameraMain.transform.forward, out hit))
        {
            /*if (hit.collider.gameObject.name == "Wheel") activeGologram = true;
            else activeGologram = false;*/

            if (hit.collider.gameObject.GetComponentInParent<ColliderObject>())
            {
                if (hit.collider.gameObject.name == hit.collider.gameObject.GetComponentInParent<ColliderObject>().Name)
                {
                    colliderObj = hit.collider.gameObject.GetComponentInParent<ColliderObject>();
                    MainID = hit.collider.gameObject.GetComponentInParent<ColliderObject>().MainID;
                    /*for (int j = 0; j < mainColliderObj.colliderObj.Length; j++)
                    {
                        for (int i = 0; i < mainColliderObj.colliderObj[j].colliderObj.Length; i++)
                        {
                            mainColliderObj.colliderObj[j].hologramObj[i].SetActive(false);//Hologram
                        }
                    }*/
                    activeGologram = true;
                }
            }
            else
            {
                activeGologram = false;
            }
            
            /*if (hit.collider.gameObject.name == "Ram")
            {
                colliderObj = hit.collider.gameObject.GetComponentInParent<ColliderObject>();
                MainID = hit.collider.gameObject.GetComponentInParent<ColliderObject>().MainID;

                activeGologram = true;
            }
            else activeGologram = false;*/


        }    
    }
    public void RayHitID()
    {
        mainColliderObj.objectSpawn[MainID].OutlineSpawn(activeGologram);
        /*for (int i = 0; i < mainColliderObj.colliderObj[MainID].colliderObj.Length; i++)
        {
            //mainColliderObj.objectSpawn[MainID].modelObj[i].SetActive(!activeGologram);//Model
            //mainColliderObj.colliderObj[MainID].hologramObj[i].SetActive(activeGologram);//Hologram
           
        }*/
    }
    public void StartColliderHologram()
    {
        transform.localPosition = new Vector3(3.53f, 0.0f, -0.39f);

        mainColliderObj = carPlayer.transform.GetComponentInChildren<MainColliderObject>();
        mainColliderObj.enabled = true;
        

        for (int j = 0; j < mainColliderObj.colliderObj.Length; j++)
        {
            for (int i = 0; i < mainColliderObj.colliderObj[j].colliderObj.Length; i++)
            {
                //wheelSpawn.modelWheel[i].SetActive(!activeGologram);//Model

                mainColliderObj.colliderObj[j].colliderObj[i].gameObject.SetActive(true);//Hologram
                mainColliderObj.objectSpawn[j].enabled = true;
                if (mainColliderObj.objectSpawn[j].wheel)
                {
                    mainColliderObj.objectSpawn[j].wheelNormal[i].normalize();
                }
                
            }
        }
    }
    private void RayHitCar()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraMain.transform.position, cameraMain.transform.forward, out hit))
        {     
            if (hit.collider.gameObject.name == "body") activeGetCar = true;
            else activeGetCar = false;
        }
    }
    private void Checking()
    { 
        activeRegactor = invert;

        if (activeRegactor)
        {
            if(activeObject == false)
            {
                
                RayHit();
                RayHitID();

            }
        }
        if(invert == false)
        {
            RayHitCar();
        }
        
    }
    private void SelectObject()
    {
        if (activeObject)
        {
            activeGologram = true;
            if (spawnHologram.hologramObj[MainID].hologramModel)
            {
                if (Input.GetMouseButton(1))
                {
                    if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
                    {
                        Vector3 transform = spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition;
                        transform.z = spawnHologram.hologramObj[MainID].valueNormal;
                        spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition = new Vector3(transform.x, transform.y, transform.z);
                    }
                    else
                    {
                        if (spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition.z <= 1.18f)
                        {
                            Vector3 transform = spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition;
                            transform.z += valueObj * Time.deltaTime * speedObj_0;
                            spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition = new Vector3(transform.x, transform.y, transform.z);
                        }
                    }
                    
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
                    {
                        Vector3 transform = spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition;
                        transform.z = spawnHologram.hologramObj[MainID].valueÑlose; 
                        spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition = new Vector3(transform.x, transform.y, transform.z);
                    }
                    else
                    {
                        if (spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition.z >= 0.45f)
                        {
                            Vector3 transform = spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition;
                            transform.z -= valueObj * Time.deltaTime * speedObj_1;
                            spawnHologram.hologramObj[MainID].hologramModel.transform.localPosition = new Vector3(transform.x, transform.y, transform.z);
                        }
                    }
                    
                }
            }
        }
    }
    private void CameraZoom()
    {
        if (invert)
        {
            if (Input.GetMouseButton(1))
            {
                activeZoomCamera = true;
                if (virtualCamera.m_Lens.FieldOfView >= editFov)
                {
                    virtualCamera.m_Lens.FieldOfView -= editFov * Time.deltaTime * speedFov;
                }

            }
            else
            {
                if (virtualCamera.m_Lens.FieldOfView <= normalFOV)
                {
                    virtualCamera.m_Lens.FieldOfView += editFov * Time.deltaTime * speedFov;
                }
                activeZoomCamera = false;
            }

        }
    }
}
