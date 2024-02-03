using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarSwitch : MonoBehaviour
{
    public GameObject[] cars;


    

    public Button left;
    public Button right;

    
    int spisok;
    [HideInInspector] public Transform Parent;
    [HideInInspector] public int switcher;
    [HideInInspector] public GameObject car_original;
    [HideInInspector] public CarCharacteristic characteristic;
    void Start()
    {
        Parent = transform;
        spisok = cars.Length;
        spisok -= 1;
        left.onClick.AddListener(Left);
        
        right.onClick.AddListener(Right);
        

        car_original = Instantiate(cars[0], Parent);
        characteristic = GameObject.FindGameObjectWithTag("CarCharacteristics").GetComponent<CarCharacteristic>();
        characteristic.defSetting = car_original.GetComponent<Default_Setting_Car>();
        characteristic.UpgateWeapon();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Left()
    {
        if(switcher > 0) 
        {
            switcher -= 1;


            if (car_original)
            {
                Destroy(car_original);
            }
            car_original = Instantiate(cars[switcher], Parent);
            characteristic.defSetting = car_original.GetComponent<Default_Setting_Car>();
            characteristic.UpgateWeapon();
        }
        
    }
    public void Right()
    {
        if (switcher < spisok)
        {
            switcher += 1;


            if (car_original)
            {
                Destroy(car_original);
            }
            car_original = Instantiate(cars[switcher], Parent);
            characteristic.defSetting = car_original.GetComponent<Default_Setting_Car>();
            characteristic.UpgateWeapon();
        }
       
            
    }
    
}
