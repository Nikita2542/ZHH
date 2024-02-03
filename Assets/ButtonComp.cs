using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonComp : MonoBehaviour
{
    public int ID;
    public GameObject carPlayer;

    public void SelectButton()
    {
        carPlayer.GetComponentInChildren<WheelSpawn>().SpawnWheel(ID);
    }
}
