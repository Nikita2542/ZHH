using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheelSpawn : MonoBehaviour
{
    public int ID;
    public Transform[] parentWheel;
    public GameObject[] prefabWheel;
    public GameObject[] modelWheel;
    public GameObject[] oldWheel;
 
    public GameObject[] wheelCoolider;
    

    private void Start()
    {    
        modelWheel = new GameObject[parentWheel.Length];
        oldWheel = new GameObject[parentWheel.Length];
        for (int i = 0; i < parentWheel.Length; i++)
        {
            oldWheel[i] = parentWheel[i].GetChild(0).gameObject;
        }
        
        StartSpawn();
    }
    public void SpawnWheel(int ID)
    {
        for (int i = 0; i < parentWheel.Length; i++)
        {
            if (modelWheel[i])
            {
                Destroy(modelWheel[i]);
            }
            if (oldWheel[i])
            {
                Destroy(oldWheel[i]);
            }
            modelWheel[i] = Instantiate(prefabWheel[ID], parentWheel[i]);
            wheelCoolider[i].GetComponent<WheelCollider>().radius = modelWheel[i].GetComponent<WheelRadius>().radius;
        }
    }
    public void StartSpawn()
    {
        for (int i = 0; i < parentWheel.Length; i++)
        {
            modelWheel[i] = transform.GetChild(i).GetComponentInChildren<WheelRadius>().gameObject;
        }
    }
  
}
