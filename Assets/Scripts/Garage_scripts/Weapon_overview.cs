using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Weapon_overview : MonoBehaviour
{
    public Button btn_preview;

    public void Start()
    {
        btn_preview = GetComponent<Button>();
        btn_preview.onClick.AddListener(Preview);
    }
    void Preview()
    {
        SceneManager.LoadScene(2);
    }
}
