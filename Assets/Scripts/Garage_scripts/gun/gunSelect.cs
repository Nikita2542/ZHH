using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class gunSelect : MonoBehaviour
{
    public int IQ;

    public Button btnGun;
    public Button btnUp;
   
    public UpgrateGun upGun;
    public bool activeGun;
    
    private void Start()
    {
      
        activeGun = false;
        upGun = GetComponentInParent<UpgrateGun>();
        btnGun = GetComponent<Button>();
        btnGun.onClick.AddListener(GunSelect);
        btnUp = transform.GetChild(1).GetComponent<Button>();
        btnUp.onClick.AddListener(UpSelect);
        
    }
   

    public void GunSelect()
    {
       upGun.GunSpawns(IQ); ///оружие появляется 
    }
    public void UpSelect()
    {
        activeGun = true;
        upGun.GunUpgrate(activeGun);
        upGun.GunSpawn(IQ);
    }
}
