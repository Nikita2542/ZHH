using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAdd : MonoBehaviour
{
    public GameObject[] wheelPrefab;
    GameObject wheelOrig;
    
    public void AddWheel(int ID)
    {
        if (wheelOrig) { Destroy(wheelOrig); }
       
        wheelOrig = Instantiate(wheelPrefab[ID], transform);
    }

}
