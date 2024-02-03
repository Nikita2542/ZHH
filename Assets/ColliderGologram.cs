using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ColliderGologram : MonoBehaviour
{

    [Header("��˨��")]
    public Transform parentColliderWheel;
    [Header("������ ��������")]
    public GameObject[] childColliderWheel;
    [Header("������ ���������")]
    public GameObject[] childWheels;
    [Header("������������")]
    public GameObject[] prefabWheelHologram;

    [Header("����")]
    public Transform parentColliderRam;    
    [Header("���� ��������")]
    public GameObject childColliderRam;
    [Header("���� ���������")]
    public GameObject childRam;
    [Header("����������")]
    public GameObject[] prefabRamHologram;
    void Start()
    {
        parentColliderWheel = transform.GetChild(0);
        parentColliderRam = transform.GetChild(1);

        childColliderWheel = new GameObject[parentColliderWheel.childCount];
        childWheels = new GameObject[parentColliderWheel.childCount];

        for (int i = 0; i < parentColliderWheel.childCount; i++)
        {
            childColliderWheel[i] = parentColliderWheel.GetChild(i).gameObject;
            childWheels[i] = childColliderWheel[i].transform.GetChild(0).gameObject;

            childWheels[i].SetActive(false);
            childColliderWheel[i].SetActive(false);
        }

        childColliderRam = parentColliderRam.GetChild(0).gameObject;
        childRam = childColliderRam.transform.GetChild(0).gameObject;

        childRam.SetActive(false);
        childColliderRam.SetActive(false);

    }

    public void SpawnHologramModel(int ID)
    {
        for (int i = 0; i < parentColliderWheel.childCount; i++)
        {
            if (childWheels[i])
            {
                Destroy(childWheels[i]);
            }
            childWheels[i] = Instantiate(prefabWheelHologram[ID], childColliderWheel[i].transform);
        }
    }
    public void SpawnHologramRam(int ID)
    {
        if (childRam)
        {
            Destroy(childRam);
        }
        childRam = Instantiate(prefabRamHologram[ID], childColliderRam.transform);
    }
}
