using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusikIQ : MonoBehaviour
{
    public int IQ;
    public string name;
   
    public Transform pos;
    public PlusikEvent plusikEvent;
    
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Challenge);
        pos = gameObject.transform;
        if(name == "Pricel")
        {
            Challenge();

        }
    }
    public void Challenge()
    {             
        plusikEvent.WhoIS(IQ, name, pos);
    }
}
