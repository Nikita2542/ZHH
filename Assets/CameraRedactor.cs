using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRedactor : MonoBehaviour
{
    public GameObject Car;
    [HideInInspector] public GameObject[] carCamera;
    void Start()
    {
        carCamera = new GameObject[Car.transform.childCount];
        for(int i = 0; i < Car.transform.childCount; i++)
        {
            carCamera[i] = Car.transform.GetChild(i).gameObject;
            carCamera[i].SetActive(false);
        }
    }

    public void CameraCar(int ID)
    {
        for (int i = 0; i < Car.transform.childCount; i++)
        {
            carCamera[i].SetActive(false);
            if (i == ID)
            {
                carCamera[ID].SetActive(true);
            }
        }
    }
    public void CameraCarFalse()
    {
        for (int i = 0; i < Car.transform.childCount; i++)
        {
            carCamera[i].SetActive(false);     
        }
    }

}
