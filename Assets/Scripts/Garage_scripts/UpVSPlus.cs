using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpVSPlus : MonoBehaviour
{ 
    public GameObject upgrade;
    public GameObject plus;


    public bool upgrateActive;
    public bool plusActive;
    private void Start()
    {
       upgrateActive = true;
    }

    public void Update()
    {
        if (upgrateActive)
        {
            upgrade.SetActive(true);
            plus.SetActive(false);
        }
        if (plusActive)
        {
            upgrade.SetActive(false);
            plus.SetActive(true);
        }
    }
 

    public void PlusActive(bool active)
    {
        plus.GetComponent<PlusikEvent>().upgrade = active;
    }
   
}
