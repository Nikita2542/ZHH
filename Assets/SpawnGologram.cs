using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGologram : MonoBehaviour
{
    [Serializable]
    public class HologramObj
    {
        [Header("Дальность")]
        public float valueNormal;
        public float valueСlose;
        [Header("Префаб")]
        public GameObject[] hologramPrefab;
        [Header("Модель")]
        public GameObject hologramModel;
        [Header("Главная папка")]
        public Transform hologramParent;

    }
    [Header("Голограмма обьекта")]
    public HologramObj[] hologramObj;

    public void SpawnHologram(int ID, int MainID)
    {
        if (hologramObj[MainID].hologramModel)
        {
            Destroy(hologramObj[MainID].hologramModel);
        }
        hologramObj[MainID].hologramModel = Instantiate(hologramObj[MainID].hologramPrefab[ID], hologramObj[MainID].hologramParent);
    }
}
