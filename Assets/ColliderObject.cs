using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObject : MonoBehaviour
{
    [Header("��������")]
    public string Name;
    [Header("������� ID")]
    public int MainID;
    [Header("�������� �������")]
    public Transform[] colliderObj;
    //[Header("���������� �������")]
    //public GameObject[] hologramObj;
    [Header("������� �������")]
    public GameObject[] prefabObj;
    void Start()
    {
        colliderObj = new Transform[transform.childCount];
        //hologramObj = new GameObject[transform.childCount];
        for(int i =  0; i < transform.childCount; i++)
        {
            colliderObj[i] = transform.GetChild(i);
            //hologramObj[i] = colliderObj[i].GetChild(0).gameObject;
            colliderObj[i].gameObject.SetActive(false);
            //hologramObj[i].SetActive(false);
        }
    }

    public void SpawnHologramObj(int ID)
    {
        for(int i = 0;i < transform.childCount; i++)
        {
            /*if (hologramObj[i])
            {
                Destroy(hologramObj[i]);
            }
            hologramObj[i] = Instantiate(prefabObj[ID], colliderObj[i]);*/
        }    
    }
}
