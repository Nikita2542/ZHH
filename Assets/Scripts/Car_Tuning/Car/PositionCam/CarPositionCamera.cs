using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarPositionCamera : MonoBehaviour
{
    Camera cam;

    public Transform parentComponentPos;
    public Transform parentMainPos;

    [HideInInspector] public Transform mainPos;
    [HideInInspector] public Transform mainLook;

    [HideInInspector] public Transform parentPos;
    [HideInInspector] public Transform parentLook;

    [HideInInspector] public Transform[] pointPos;
    [HideInInspector] public Transform[] pointLook;

    [Space(10)]

    [Range(0, 60)]
    public float FOV;

    [HideInInspector] public int intPos;
    [HideInInspector] public int intLook;

    public float speedMove;

    [HideInInspector] public bool boolActive;
    [HideInInspector] public bool boolActiveMain;

    CameraFOV[] camFOV;

    void Start()
    {
        cam = Camera.main;

        parentPos = parentComponentPos.GetChild(0);
        parentLook = parentComponentPos.GetChild(1);

        mainPos = parentMainPos.GetChild(0);
        mainLook = parentMainPos.GetChild(1);

        pointPos = new Transform[parentPos.childCount];
        pointLook = new Transform[parentLook.childCount];

        camFOV = new CameraFOV[pointPos.Length];

        for (int i = 0; i < parentPos.childCount; i++)
        {
            pointPos[i] = parentPos.GetChild(i);
            pointLook[i] = parentLook.GetChild(i);

            camFOV[i] = pointPos[i].GetComponent<CameraFOV>();
        }

        boolActiveMain = true;
        boolActive = false;
    }

    void Update()
    {
        if (boolActive)
        {
            if (pointPos.Length >= intPos)
            {
                cam.transform.position = Vector3.Lerp(cam.transform.position, pointPos[intPos].transform.position, Time.deltaTime * speedMove);
                cam.transform.LookAt(pointLook[intLook].transform);
                cam.fieldOfView = camFOV[intPos].FOV;
            }  
        }
        if (boolActiveMain)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, mainPos.position, Time.deltaTime * speedMove);
            cam.transform.LookAt(mainLook);
            cam.fieldOfView = FOV;
        }
    }
}
