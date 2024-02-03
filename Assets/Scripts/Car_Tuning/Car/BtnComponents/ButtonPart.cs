using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPart : MonoBehaviour
{
    public string Name;
    public int ID;
    [Header("Image")]
    [HideInInspector] public Image cyrcle;
    [HideInInspector] public Image ikon;
    [Header("Скрипты")]
    [HideInInspector] public CarButtonParts part_Script;
    [HideInInspector] public CameraRedactor cameraRedactor;
    [HideInInspector] public ButtonComponents buttonComponents;

    [Header("Bool")]
    public bool active;
    [Header("Текст")]
    [HideInInspector] public TextMeshProUGUI textOrig;
    
    void Start()
    {
        EventTrigger trigger = transform.GetComponent<EventTrigger>();

        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((data) => { TrigerEnter((PointerEventData)data); });
        trigger.triggers.Add(entryEnter);

        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((data) => { TrigerExit((PointerEventData)data); });
        trigger.triggers.Add(entryExit);
    }

    public void TrigerEnter(PointerEventData data)
    {
        if(active == false)
        {
            textOrig = Instantiate(part_Script.textPref.GetComponent<TextMeshProUGUI>(), transform);
            textOrig.text = Name;

            cyrcle.enabled = true;
            ikon.color = new Color(0.2f, 0.2f, 0.2f, 1.0f); // Black
        }   
    }
    public void TrigerExit(PointerEventData data)
    {
        if(active == false)
        {
            Destroy(textOrig.gameObject);

            cyrcle.enabled = false;
            ikon.color = new Color(0.8f, 0.8f, 0.8f, 1.0f); // White
        }   
    }
    public void ClickBtn()
    {
        cameraRedactor.CameraCar(ID + 1);
        buttonComponents.SpawnComponents(ID);
        for (int i = 0; i < part_Script.btnPref.Length; i++)
        {
            part_Script.part[i].active = false;
            if (part_Script.part[i].textOrig)
            {
                Destroy(part_Script.part[i].textOrig.gameObject);
            }
            part_Script.part[i].cyrcle.enabled = false;
            part_Script.part[i].ikon.color = new Color(0.8f, 0.8f, 0.8f, 1.0f); // White
        }
        textOrig = Instantiate(part_Script.textPref.GetComponent<TextMeshProUGUI>(), transform);
        textOrig.text = Name;

        cyrcle.enabled = true;
        ikon.color = new Color(0.2f, 0.2f, 0.2f, 1.0f); // Black

        active = true;
    }
}
