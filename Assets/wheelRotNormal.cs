using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotNormal : MonoBehaviour
{
    public float Yrot;
    public void normalize()
    {
        transform.localRotation = new Quaternion(0, Yrot, 0, 1);
    }
}
