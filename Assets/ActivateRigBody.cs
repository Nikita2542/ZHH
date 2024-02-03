using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRigBody : MonoBehaviour
{
    public AIAgentBlue agent;
    public float radiusKnocked;
    public bool isKnocked;
    void Start()
    {
        agent = GetComponent<AIAgentBlue>();
    }

    // Update is called once per frame
    void Update()
    {
        isKnocked = Physics.CheckSphere(transform.position, radiusKnocked, agent.jumpAwayBlue.playerMask);
        if (isKnocked)
        {
            agent.jumpAwayBlue.dodgeFalse = true;
            agent.weaponIk.isStopAim = true;
            agent.activateWeaponBlue.isStopFire = true;
            agent.mutant.ActivateRagdoll();
        
            agent.navMesh.speed = 0;
            
        }
    }
}
