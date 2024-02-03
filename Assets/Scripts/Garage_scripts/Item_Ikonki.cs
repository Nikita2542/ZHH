using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Item_Ikonki : MonoBehaviour
{
    public Image pricel;

    public Sprite[] Ikon;

    public void Ikon_pricel(int index)
    {

        pricel.sprite = Ikon[index];
        Ikon[index].GetComponent<Image>().color = Color.black;
    }
}
