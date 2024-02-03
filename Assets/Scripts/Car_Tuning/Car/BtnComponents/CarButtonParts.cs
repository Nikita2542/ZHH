using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CarButtonParts : MonoBehaviour
{
    [HideInInspector] public Transform buttonParts;
    [Header("Префаб кнопок")]
    public GameObject[] btnPref;
    [Header("Кнопки")]
    [HideInInspector] public Button[] btnOrig;
    [Header("Префаб Текста")]
    public GameObject textPref;
    
    [Header("Скрипт")]
 
    [HideInInspector] public ButtonPart[] part;
    public CameraRedactor cameraRedactor;
    public ButtonComponents buttonComponents;
    void Start()
    {
        buttonParts = GameObject.FindGameObjectWithTag("ButtonParts").transform;
        buttonComponents = transform.GetComponent<ButtonComponents>();  
        btnOrig = new Button[btnPref.Length];
        part = new ButtonPart[btnOrig.Length];
        
        for (int i = 0; i < btnPref.Length; i++)
        {
            btnOrig[i] = Instantiate(btnPref[i].GetComponent<Button>(), buttonParts);

            part[i] = btnOrig[i].AddComponent<ButtonPart>();
            part[i].part_Script = this;
            part[i].Name = btnPref[i].name;
            part[i].ID = i;
            part[i].cyrcle = btnOrig[i].transform.GetChild(0).GetComponent<Image>();
            part[i].ikon = btnOrig[i].transform.GetChild(1).GetComponent<Image>();
            part[i].cameraRedactor = cameraRedactor;
            part[i].buttonComponents = buttonComponents;    
            btnOrig[i].onClick.AddListener(part[i].ClickBtn);
        }
    }
}
