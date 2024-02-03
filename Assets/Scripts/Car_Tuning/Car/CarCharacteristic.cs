using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CarCharacteristic : MonoBehaviour
{
    public Slider[] sliderComponents;
    [System.Serializable]
    public struct SliderPL
    {
        public GameObject[] sliderPlus;
        public GameObject[] sliderMinus;
    }
    [SerializeField]

     public SliderPL sliderPL;
    [System.Serializable]
    public struct ParentPL
    {
        public Transform[] parentPlus;
        public Transform[] parentMinus;
    }
     public ParentPL parentPL;
    [System.Serializable]
    public struct PrefPL
    {
        public GameObject prefPlus;
        public GameObject prefMinus;
    }
    public PrefPL prefPL;

    [HideInInspector] public Default_Setting_Car defSetting;
    [HideInInspector] public CarCharComponents charComp;


    [System.Serializable]
    public struct ComponentObj
    {
        public GameObject motor;
        /*public GameObject wheels;
        public GameObject damper;*/
    }
    public ComponentObj componentObj;

    public void Start()
    {
        sliderComponents = new Slider[transform.GetChild(0).transform.childCount];

        sliderPL.sliderPlus = new GameObject[transform.GetChild(0).transform.childCount];
        sliderPL.sliderMinus = new GameObject[transform.GetChild(0).transform.childCount];

        parentPL.parentPlus = new Transform[transform.GetChild(0).transform.childCount];
        parentPL.parentMinus = new Transform[transform.GetChild(0).transform.childCount];

        for (int i = 0; i < sliderComponents.Length; i++)
        {
            sliderComponents[i] = transform.GetChild(0).transform.GetChild(i).transform.GetChild(2).GetComponent<Slider>();
            
            parentPL.parentPlus[i] = transform.GetChild(0).transform.GetChild(i).transform.GetChild(0).transform;
            parentPL.parentMinus[i] = transform.GetChild(0).transform.GetChild(i).transform.GetChild(1).transform;
        }
        UpgateWeapon();
    }
    


    public void UpgateWeapon()
    {
        for (int i = 0; i < sliderComponents.Length; i++)
        {
            if (sliderPL.sliderPlus[i])
            {
                Destroy(sliderPL.sliderPlus[i]);
            }
            if (sliderPL.sliderMinus[i])
            {
                Destroy(sliderPL.sliderMinus[i]);
            }
            sliderComponents[i].value = defSetting.value[i];

            sliderPL.sliderPlus[i] = Instantiate(prefPL.prefPlus, parentPL.parentPlus[i]);
            sliderPL.sliderMinus[i] = Instantiate(prefPL.prefMinus, parentPL.parentMinus[i]);

            sliderPL.sliderPlus[i].SetActive(false);
            sliderPL.sliderMinus[i].SetActive(false);
        }
    }
    public void ComponentTransmits(int comID, int value, bool pl)
    {
        Slider sliderPlus;
        Slider sliderMinus;
        int valueDef;
        
            for (int i = 0; i < sliderComponents.Length; i++)
            {
               

                sliderPlus = sliderPL.sliderPlus[i].GetComponent<Slider>();
                sliderMinus = sliderPL.sliderMinus[i].GetComponent<Slider>();
                valueDef = defSetting.value[i];

                if (comID == i)
                {
                    if (pl)
                    {
                        sliderPL.sliderPlus[i].gameObject.SetActive(true);
                        sliderPL.sliderMinus[i].gameObject.SetActive(false);
                        sliderPlus.value = valueDef + value;
                    }
                    else
                    {
                        sliderPL.sliderMinus[i].gameObject.SetActive(true);
                        sliderPL.sliderPlus[i].gameObject.SetActive(false);
                        sliderMinus.value = valueDef;
                        sliderComponents[i].value = valueDef - value;
                    }
                }
            }
        

        /*if (componentObj.wheels)
        {
            for (int i = 0; i < sliderComponents.Length; i++)
            {
                sliderPlus = sliderPL.sliderPlus[i].GetComponent<Slider>();
                sliderMinus = sliderPL.sliderMinus[i].GetComponent<Slider>();
                valueDef = defSetting.value[i];
                if (comID == i)
                {
                    if (pl)
                    {
                        sliderPL.sliderPlus[i].gameObject.SetActive(true);
                        sliderPL.sliderMinus[i].gameObject.SetActive(false);
                        sliderPlus.value = valueDef + value;
                    }
                    else
                    {
                        sliderPL.sliderMinus[i].gameObject.SetActive(true);
                        sliderPL.sliderPlus[i].gameObject.SetActive(false);
                        sliderMinus.value = valueDef;
                        sliderComponents[i].value = valueDef - value;
                    }
                }
            }
        }

        if (componentObj.damper)
        {
            for (int i = 0; i < sliderComponents.Length; i++)
            {
                sliderPlus = sliderPL.sliderPlus[i].GetComponent<Slider>();
                sliderMinus = sliderPL.sliderMinus[i].GetComponent<Slider>();
                valueDef = defSetting.value[i];
                if (comID == i)
                {
                    if (pl)
                    {
                        sliderPL.sliderPlus[i].gameObject.SetActive(true);
                        sliderPL.sliderMinus[i].gameObject.SetActive(false);
                        sliderPlus.value = valueDef + value;
                    }
                    else
                    {
                        sliderPL.sliderMinus[i].gameObject.SetActive(true);
                        sliderPL.sliderPlus[i].gameObject.SetActive(false);
                        sliderMinus.value = valueDef;
                        sliderComponents[i].value = valueDef - value;
                    }
                }
            }
        }*/

    }
}
