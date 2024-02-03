using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponCharacteristic : MonoBehaviour
{
    public Slider[] sliderComponents;
    [System.Serializable]
    public struct SliderPL
    {
        public GameObject[] sliderPlus;
        public GameObject[] sliderMinus;
    }
    [SerializeField]
    [HideInInspector]
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

    [HideInInspector] public Default_Setting defSetting;
    public CharComponent charComp;
    public UpgrateGun upGun;


    [System.Serializable]
    public struct ComponentObj
    {
        public GameObject pricel;
        public GameObject dulo;
        public GameObject magazine;
    }
    public ComponentObj componentObj;
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
            sliderPL.sliderPlus[i].gameObject.SetActive(false);

            sliderPL.sliderMinus[i] = Instantiate(prefPL.prefMinus, parentPL.parentMinus[i]);
            sliderPL.sliderMinus[i].gameObject.SetActive(false);
        }
    }
    public void ComponentTransmits(int comID, int value, bool pl)
    {
        Slider sliderPlus;
        Slider sliderMinus;
        int valueDef;
        if (componentObj.pricel)
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

        if (componentObj.dulo)
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

        if (componentObj.magazine)
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

    }
   
}
