using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Smena : MonoBehaviour
{
    [Header("UI")]
    public GameObject weaponUI;
    public GameObject carUI;
    [Header("OBJ")]    
    public GameObject weaponObj;
    public GameObject carObj;
    [Space(10)]
    public Button carBtn;
    public Button weaponBtn;
    public Button backToSmena;
    
    public GameObject smena;
    
    public GameObject up;
    public GameObject down;

    public Animator car_animator;
    public Animator weapon_animator;
   
    public void Start()
    {
        smena.gameObject.SetActive(true);

        carBtn.onClick.AddListener(Car);
        weaponBtn.onClick.AddListener(Weapon);
        backToSmena.onClick.AddListener(BackToSmena);

        backToSmena.gameObject.SetActive(false);

        weaponUI.gameObject.SetActive(false);
        carUI.gameObject.SetActive(false);

        carObj.gameObject.SetActive(false);
        weaponObj.gameObject.SetActive(false);
    }

   

    public void Weapon_Enter()
    {
       
        weapon_animator.SetBool("weapon", true);
        weapon_animator.SetBool("weapon_off", false);
        
        car_animator.SetBool("car", false);
        car_animator.SetBool("car_off", true);

    }
   

    public void Weapon_Exit()
    {
        weapon_animator.SetBool("weapon", false);
        weapon_animator.SetBool("weapon_off", true);
    }


    public void Car_Enter()
    {

        /// car.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        /// weapon.transform.parent = up.transform;
        /// car.transform.parent = down.transform;

        /// weapon.transform.localScale = new Vector3(1.02f, 1.02f, 1.02f);
        car_animator.SetBool("car", true );
        car_animator.SetBool("car_off", false);

    }
    public void Car_Exit()
    {
        car_animator.SetBool("car", false);
        car_animator.SetBool("car_off", true);
        
        weapon_animator.SetBool("weapon", false);
        weapon_animator.SetBool("weapon_off", true);
    }

    
    public void Weapon()
    {
        smena.gameObject.SetActive(false);
        backToSmena.gameObject.SetActive(true);

        weaponUI.gameObject.SetActive(true);
        carUI.gameObject.SetActive(false);

        carObj.gameObject.SetActive(false);
        weaponObj.gameObject.SetActive(true);
    }
    public void Car()
    {
        smena.gameObject.SetActive(false);
        backToSmena.gameObject.SetActive(true);

        weaponUI.gameObject.SetActive(false);
        carUI.gameObject.SetActive(true);

        carObj.gameObject.SetActive(true);
        weaponObj.gameObject.SetActive(false);
    }
    public void BackToSmena()
    {
        smena.gameObject.SetActive(true);
        backToSmena.gameObject.SetActive(false);

        weaponUI.gameObject.SetActive(false);
        carUI.gameObject.SetActive(false);

        carObj.gameObject.SetActive(false);
        weaponObj.gameObject.SetActive(false);
    }

}