using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PricelTarget : MonoBehaviour
{
    public Transform target;
    public Transform rayCast;
    public Transform targetHit;

    public RectTransform right;
    public RectTransform left;
    public RectTransform up;
    public RectTransform down;

   public Vector3 x;
   public Vector3 y;

    public bool interactable;

    Ray ray;
    RaycastHit hitInfo;


    // Update is called once per frame
    void LateUpdate()
    {
        
        ray.origin = rayCast.transform.position;
        ray.direction = rayCast.transform.forward;
        if (Physics.Raycast(ray, out hitInfo))
        {
            targetHit.position = hitInfo.point;
            transform.position = Camera.main.WorldToScreenPoint(targetHit.position);
        }
        else
        {
            transform.position = Camera.main.WorldToScreenPoint(target.position);
        }
    }
}
