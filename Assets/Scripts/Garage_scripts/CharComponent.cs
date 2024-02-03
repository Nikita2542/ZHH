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
        [Tooltip("����")]
        ����,
        [Tooltip("��������")]
        ��������,
        [Tooltip("���������")]
        ���������,
        [Tooltip("�����������")]
        �����������,
        [Tooltip("������")]
        ������
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

    /*[Tooltip("����")]
    public int damage;
    [Range(0,1)]
    public int pmDamage;
    [Space(4)]
    [Tooltip("��������")]
    public int accuracy;
    [Range(0, 1)]
    public int pmAccuracy;
    [Space(4)]
    [Tooltip("���������")]
    public int range;
    [Range(0, 1)]
    public int pmRange;
    [Space(4)]
    [Tooltip("�����������")]
    public int mobility;
    [Range(0, 1)]
    public int pmMobility;
    [Space(4)]
    [Tooltip("������")]
    public int recoil;
    [Range(0, 1)]
    public int pmRecoil;*/

}
