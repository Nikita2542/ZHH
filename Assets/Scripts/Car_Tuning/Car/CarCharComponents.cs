using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarCharComponents : MonoBehaviour
{
    [System.Serializable]
    public enum Component
    {
        [Tooltip("Скорость")]
        Скорость,
        [Tooltip("Управляемость")]
        Управляемость,
        [Tooltip("Проходимость")]
        Проходимость,
        [Tooltip("Генератор стабильности")]
        Генератор_стабильности,
        [Tooltip("Сушняк")]
        Сушняк
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

    public CarCharacteristic characteristic;

    public void Start()
    {
        characteristic.charComp = this;
        int ComID;
        for (int i = 0; i < itemStruct.Length; i++)
        {
            ComID = (int)itemStruct[i].component;
            characteristic.ComponentTransmits(ComID, itemStruct[i].value, itemStruct[i].plusMinus);
        }
    }
    private void Update()
    {
        
    }
}
