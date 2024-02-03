using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawn : MonoBehaviour
{
    [Header("Код")]
    public int id;
    [Header("Название")]
    public string Name;
    [Header("Главная папка")]
    public Transform[] parentObj;
    [Header("Префаб")]
    public GameObject[] prefabObj;
    [Header("Модель")]
    public GameObject[] modelObj;
    [Header("Скрипт")]
    public Outline[] outline;


    [Header("Если есть")]
    public GameObject[] wheelCoolider;
    public wheelRotNormal[] wheelNormal;
    public bool wheel;
    private void Start()
    {
        for (int i = 0; i < parentObj.Length; i++)
        {
            outline[i].enabled = false;
        }
    }
    public void SpawnObj(int ID)
    {
        id = ID;
        for (int i = 0; i < parentObj.Length; i++)
        {
            if (modelObj[i])
            {
                Destroy(modelObj[i]);
            }
            
            modelObj[i] = Instantiate(prefabObj[ID], parentObj[i].transform);
            outline[i] = modelObj[i].GetComponentInChildren<Outline>();
            
            outline[i].enabled = false;


            if (Name == "Wheel")
            {
                
                wheelCoolider[i].GetComponent<WheelCollider>().radius = modelObj[i].GetComponent<WheelRadius>().radius;
                wheelCoolider[i].GetComponent<WheelCollider>().suspensionDistance = modelObj[i].GetComponent<WheelRadius>().suspensionDistance;
            }
        }
    }
    public void OutlineSpawn(bool spawn)
    {
        for (int i = 0; i < parentObj.Length; i++)
        {
            outline[i].enabled = spawn;
        }
    }
    public void StartSpawn()
    {
        for (int i = 0; i < parentObj.Length; i++)
        {
            //modelObj[i] = transform.GetChild(i).GetComponentInChildren<Anchor>().gameObject;
            if (Name == "Wheel")
            {
                Transform parentCollider = GameObject.FindGameObjectWithTag("WheelColliders").transform;
                wheelCoolider[i] = parentCollider.GetChild(i).gameObject;
            }
           
        }
        
    }

}
