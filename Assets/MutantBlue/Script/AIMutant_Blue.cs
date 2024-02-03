
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class AIMutant_Blue : MonoBehaviour
{
   
    [HideInInspector] public bool die;
    [HideInInspector] public float currentHealth;
    [Header("Максимальное здоровье")]
    public float maxHealth;
    [Header("Точность попадания")]
    public float inaccuracy;

    NavMeshAgent mutant;
    Animator anim;
    Rigidbody[] rigidBodies;
    AIAgentBlue agent;

    WeaponIkBlue weaponIk;
    [HideInInspector] public Transform currentRay;
    [HideInInspector] public Transform currentTarget;
 


    void Start()
    {
        weaponIk = GetComponent<WeaponIkBlue>();
        agent = GetComponent<AIAgentBlue>();
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidBody in rigidBodies)
        {
            Hitbox_mutantBlue hitBox= rigidBody.gameObject.AddComponent<Hitbox_mutantBlue>();
            hitBox.health = this;
        }
            currentHealth = maxHealth;


        mutant = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        DeactivateRagdoll();
    }

    void Update()
    {    
       if(die == false)
        { 
            anim.SetFloat("Speed", mutant.velocity.magnitude);
            
        }

        SetTarget(weaponIk.targetTransform);
        
    }
    public void ActiveWeapon()
    {
        weaponIk.SetAimTransform(currentRay);
        
        
    }
    public void SetTarget(Transform target)
    {
        target.localPosition = UnityEngine.Random.insideUnitSphere * inaccuracy;
        weaponIk.SetTargetTransform(target);
        currentTarget = target;
        /*if (time < 0)
        {
            time -= Time.deltaTime;
        }
        if (time > 0)
        {
            target.localPosition = new Vector3(0, 0, 0);
            time = timeReset;
        }*/
    }

    public void DeactivateRagdoll()
    {
        foreach ( var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = true;
        }
        anim.enabled = true;
    }
    public void ActivateRagdoll()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = false;
        }
        anim.enabled = false;
        mutant.enabled = false;
    }
    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        agent.weaponIk.weight = 0;
        agent.stateMachine.ChangeState(AiStateIdBlue.Death);

    }

    public void WeaponAim(bool Activate, float value)
    {
        agent.weaponIk.weight = value;
        agent.anim.SetBool("Aim", Activate);
    }
    public void WeaponWalk(bool Activate)
    {
        agent.anim.SetBool("AimWalk", Activate);
    }
}
