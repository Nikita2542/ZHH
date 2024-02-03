using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawn : MonoBehaviour
{
    [Header("���")]
    public int id;
    [Header("��������")]
    public string Name;
    [Header("������� �����")]
    public Transform[] parentObj;
    [Header("������")]
    public GameObject[] prefabObj;
    [Header("������")]
    public GameObject[] modelObj;
    [Header("������")]
    public Outline[] outline;


    [Header("���� ����")]
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
