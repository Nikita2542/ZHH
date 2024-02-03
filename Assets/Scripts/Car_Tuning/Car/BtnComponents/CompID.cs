using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CompID : MonoBehaviour
{
    public int ID;
    public CarCompBtn carComp;
    public bool active;

    public void Start()
    {
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = transform.GetComponent<EventTrigger>();

        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((data) => { EnterMouse((PointerEventData)data); });
        trigger.triggers.Add(entryEnter);

        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((data) => { ExitMouse((PointerEventData)data); });
        trigger.triggers.Add(entryExit);

    }

    public void EnterMouse(PointerEventData data)
    {
        carComp.Comp(ID);
    }
    public void ExitMouse(PointerEventData data)
    {
        carComp.CompExit(ID);
    }
}
