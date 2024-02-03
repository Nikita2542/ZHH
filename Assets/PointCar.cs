using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCar : MonoBehaviour
{
    public ManagerCamera managerCam;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            managerCam.pointCarBool = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            managerCam.pointCarBool = false;
        }
    }
}
