using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class CarPosCamera : MonoBehaviour
{
    Camera cam;
    [Serializable]
    public class Parts
    {
        public string name;
        [HideInInspector] public Button btn;
        public GameObject[] prefabs;
    }
    public Parts[] parts;


    public Transform carZonaRot;
    
    public Button back;
    public Button backToSmena;
    

    [HideInInspector] public GameObject[] original;
    [HideInInspector] public GameObject Main_btn;
    
    [HideInInspector] public GameObject Motor_btn;
    [HideInInspector] public Transform motor;
    [HideInInspector] public Transform mainCamPos;
    [HideInInspector] public Transform[] parent;
    [HideInInspector] public Transform partsCar;
    [HideInInspector] public Transform arrow;
    [HideInInspector] public Transform buttonParts;
    public Transform positionCamera;
    
   
    [HideInInspector] public CarCharacteristic characteristic;
    
    [HideInInspector] public int switcher;

    int spisok;
    void Start()
    {
        partsCar = GameObject.FindGameObjectWithTag("PartsCar").transform;
        arrow = GameObject.FindGameObjectWithTag("Arrow").transform;
        characteristic = GameObject.FindGameObjectWithTag("CarCharacteristics").GetComponent<CarCharacteristic>();

        buttonParts = transform;

        parts = new Parts[buttonParts.childCount];

        for (int i = 0; i < buttonParts.childCount; i++)
        {
            parts[i].btn = buttonParts.GetChild(0).GetComponent<Button>();
            parts[i].btn.onClick.AddListener(Btn_components);
            parent[i] = partsCar.GetChild(0);
        }
        
        Main_btn = arrow.GetChild(0).gameObject;
        Motor_btn = arrow.GetChild(1).gameObject;

        

        motor = positionCamera.GetChild(1);
        mainCamPos = positionCamera.GetChild(0);
        spisok = parts[0].prefabs.Length;
        spisok -= 1;
        
        cam = Camera.main;

        back.onClick.AddListener(Back);


        Main_btn.SetActive(true);
        Motor_btn.SetActive(false);
        
        back.gameObject.SetActive(false);
        backToSmena.gameObject.SetActive(true);
    }
    
    public void Btn_components()
    {
        if (original[0])
        {
            Destroy(original[0]);
        }
        carZonaRot.GetComponent<CarRotation>().Car_Rot.transform.localRotation = carZonaRot.GetComponent<CarRotation>().rotationOriginal;
        
        carZonaRot.GetComponent<CarRotation>().enabled = false;



        original[0] = Instantiate(parts[0].prefabs[switcher], parent[0]);
        original[0].GetComponent<CarCharComponents>().characteristic = characteristic;

        cam.transform.localPosition = motor.localPosition;
        cam.transform.localRotation = motor.localRotation;

        Main_btn.SetActive(false);
        Motor_btn.SetActive(true);
        back.gameObject.SetActive(true);
        backToSmena.gameObject.SetActive(false);

    }
    private void Back()
    {
        if (original[0])
        {
            Destroy(original[0]);
        }
        carZonaRot.GetComponent<CarRotation>().enabled = true;

        cam.transform.localPosition = mainCamPos.localPosition;
        cam.transform.localRotation = mainCamPos.localRotation;

        Main_btn.SetActive(true);
        Motor_btn.SetActive(false);
        back.gameObject.SetActive(false);
        backToSmena.gameObject.SetActive(true);
    }

}
