using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossOutPricel : MonoBehaviour
{
    public Transform rayCast;
    Ray ray;
    RaycastHit hitInfo;


    void Update()
    {
        
        ray.origin = rayCast.transform.position;
        ray.direction = rayCast.transform.forward;
        if(Physics.Raycast(ray, out hitInfo))
        {
            transform.position = hitInfo.point;
        }
        
        
    }
}
