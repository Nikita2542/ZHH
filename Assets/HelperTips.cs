using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperTips : MonoBehaviour
{
    public GameObject controlKeyboard;
    public GameObject weaponChange;

    public bool W;
    public bool A;
    public bool S;
    public bool D;
    public bool Q;
    void Start()
    {
        controlKeyboard = transform.GetChild(0).gameObject;
        controlKeyboard.SetActive(true);

        weaponChange = transform.GetChild(1).gameObject;
        weaponChange.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            W = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            A = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            S = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            D = true;
        }
        if (W & A & S & D)
        {
            controlKeyboard.SetActive(false);
            weaponChange.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Q = true;
            }
            if(Q == true)
            {
                weaponChange.SetActive(false);
            }
        }
    }
}

