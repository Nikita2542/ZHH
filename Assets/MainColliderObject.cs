using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainColliderObject : MonoBehaviour
{
    public ColliderObject[] colliderObj;
    public ObjectsSpawn[] objectSpawn; 
    void Start()
    {
        colliderObj = new ColliderObject[transform.childCount]; 
        for(int i = 0; i < transform.childCount; i++)
        {
            colliderObj[i] = transform.GetChild(i).GetComponent<ColliderObject>(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
