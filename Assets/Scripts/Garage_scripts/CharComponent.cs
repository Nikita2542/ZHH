using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using static CharComponent;

public class CharComponent : MonoBehaviour
{
    
    [System.Serializable]
    public enum Component
    {
        [Tooltip("Урон")]
        Урон,
        [Tooltip("Точность")]
        Точность,
        [Tooltip("Дальность")]
        Дальность,
        [Tooltip("Мобильность")]
        Мобильность,
        [Tooltip("Отдача")]
        Отдача
    }
    
    
   
    [System.Serializable]
    public struct ItemStruct
    {
        
        public Component component;
        [Space(7)]
        public int value;
        public bool plusMinus;



    }
    
    public ItemStruct[] itemStruct;

    public WeaponCharacteristic characteristic;

    public void Start()
    {
        /*int ComID;
        for (int i = 0; i < itemStruct.Length; i++)
        {
            ComID = (int)itemStruct[i].component;
            characteristic.ComponentTransmits(ComID, itemStruct[i].value, itemStruct[i].plusMinus);
        }   */ 
    }

    /*[Tooltip("Урон")]
    public int damage;
    [Range(0,1)]
    public int pmDamage;
    [Space(4)]
    [Tooltip("Точность")]
    public int accuracy;
    [Range(0, 1)]
    public int pmAccuracy;
    [Space(4)]
    [Tooltip("Дальность")]
    public int range;
    [Range(0, 1)]
    public int pmRange;
    [Space(4)]
    [Tooltip("Мобильность")]
    public int mobility;
    [Range(0, 1)]
    public int pmMobility;
    [Space(4)]
    [Tooltip("Отдача")]
    public int recoil;
    [Range(0, 1)]
    public int pmRecoil;*/

}
