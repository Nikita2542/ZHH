using UnityEngine;
using TMPro;

public class WeaponReload : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    RaycastWeapon weapon;

    public float durectionReload;
    bool isReload;
    float timeReload;

    void Start()
    {
        weapon = GetComponent<RaycastWeapon>();
    }
    

    void Update()
    {
        
     
        if (weapon)
        {
            
            Reload();
        }
       
    }
   
    private void Reload()
    {   
        displayText.text = weapon.ammoCount.ToString();
        if (Input.GetKeyUp(KeyCode.R) || weapon.ammoCount <= 0)
        {
            isReload = true;
        }
        if (isReload)
        {
            if (timeReload > 0)
            {               
                timeReload -= Time.deltaTime;
            }
            if (timeReload <= 0)
            {
                weapon.ammoCount = weapon.clipSize;
                isReload = false;
            }
        }
        else
        {
            timeReload = durectionReload;            
        }
        




    }
   
}
