
using UnityEngine;

public class CrossHeirTarget : MonoBehaviour
{
    Camera mainCamera;
    Ray ray;
    RaycastHit hitInfo;

    
    void Start()
    {
        mainCamera = Camera.main;
    }

   
    void Update()
    {
        ray.origin = mainCamera.transform.position;
        ray.direction = mainCamera.transform.forward;
        Physics.Raycast(ray, out hitInfo);
        transform.position = hitInfo.point;
    }
}
