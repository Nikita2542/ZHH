using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseItem : MonoBehaviour
{
    public Spawn_components spawn;

    public bool close = false;
    public string name;

    public void Start()
    {
        close = false;
        gameObject.GetComponent<Button>().onClick.AddListener(CloseBtn);
    }
    public void CloseBtn()
    {
        close = true;
        spawn.Close(name, close);
    }
}
