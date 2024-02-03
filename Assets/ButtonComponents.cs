using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonComponents : MonoBehaviour
{
    public GameObject compPrefab;
    public Transform buttonComponent;
    public GameObject CarPlayer;
    [Serializable]
    public class Component
    {
        public string name;
        public string[] Name;
        public Sprite[] icon;
    }
    public Component[] components;

    public GameObject[] compOriginal;
    public void SpawnComponents(int ID)
    {
        for(int i = 0; i < buttonComponent.childCount; i++)
        {
            if (compOriginal[i])
            {
                Destroy(compOriginal[i]);
            }
        }
        compOriginal = new GameObject[components[ID].icon.Length];

        for (int i = 0; i < components[ID].icon.Length; i++)
        {
            compOriginal[i] = Instantiate(compPrefab, buttonComponent);
            compOriginal[i].AddComponent<ButtonComp>();
            compOriginal[i].GetComponent<ButtonComp>().ID = i;
            compOriginal[i].GetComponent<ButtonComp>().carPlayer = CarPlayer;
            compOriginal[i].GetComponent<Button>().onClick.AddListener(compOriginal[i].GetComponent<ButtonComp>().SelectButton);
            compOriginal[i].transform.GetChild(2).GetComponent<Image>().sprite = components[ID].icon[i];
            compOriginal[i].transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = components[ID].Name[i];
        }
    }
    public void SpawnModel()
    {

    }
}
