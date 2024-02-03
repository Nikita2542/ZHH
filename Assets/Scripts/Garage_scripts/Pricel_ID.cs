using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pricel_ID : MonoBehaviour
{
    public int ID;
    public string Name;
    public Spawn_components components;
    private void Update()
    {
        components.CloseData(ID, Name);
    }
}
