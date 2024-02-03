using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speedRot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        float y = 0;
        y += 1 * Time.deltaTime * speedRot;
        transform.Rotate(0, y, 0);
    }
}
