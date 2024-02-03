using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardHelper : MonoBehaviour
{
    public GameObject keyboard;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        keyboard = transform.GetChild(0).gameObject;
        active = false;
        keyboard.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            active = !active;
            keyboard.SetActive(active);
        }
    }
}
