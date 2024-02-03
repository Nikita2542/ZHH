using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGologram : MonoBehaviour
{
    [Serializable]
    public class HologramObj
    {
        [Header("���������")]
        public float valueNormal;
        public float value�lose;
        [Header("������")]
        public GameObject[] hologramPrefab;
        [Header("������")]
        public GameObject hologramModel;
        [Header("������� �����")]
        public Transform hologramParent;

    }
    [Header("���������� �������")]
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
