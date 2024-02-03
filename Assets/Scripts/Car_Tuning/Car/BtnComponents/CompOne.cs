using UnityEngine;
using UnityEngine.EventSystems;


public class CompOne : MonoBehaviour
{
    public int ID;
    public CarCompBtn carBtn;

    public void StartGo()
    {
        if (carBtn.boolComp)
        {
            EventTrigger trigger = carBtn.compBtn[ID].GetComponent<EventTrigger>();

            EventTrigger.Entry entryEnter = new EventTrigger.Entry();
            entryEnter.eventID = EventTriggerType.PointerEnter;
            entryEnter.callback.AddListener((data) => { TrigerEnter((PointerEventData)data); });
            trigger.triggers.Add(entryEnter);
        }
        if (carBtn.boolActive)
        {
            EventTrigger trigger = carBtn.origBtnActive[ID].GetComponent<EventTrigger>();

            EventTrigger.Entry entryEnter = new EventTrigger.Entry();
            entryEnter.eventID = EventTriggerType.PointerEnter;
            entryEnter.callback.AddListener((data) => { TrigerEnter((PointerEventData)data); });
            trigger.triggers.Add(entryEnter);
        }

    }
    public void TrigerEnter(PointerEventData data)
    {
        carBtn.ID = ID;
    }
}
