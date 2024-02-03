using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathStateBlue : AIStateBlue
{
    public AiStateIdBlue GetId()
    {
        return AiStateIdBlue.Death;
    }
    public void Enter(AIAgentBlue agent)
    {
        agent.patrulling.patrul = false;
        agent.mutant.ActivateRagdoll();
        agent.mutant.die = true;
        if (agent.weapon)
        {
            agent.weapon.transform.SetParent(null);
            agent.weapon.GetComponent<BoxCollider>().enabled = true;
            agent.weapon.AddComponent<Rigidbody>();
            agent.weapon = null;
            agent.patrulling._isAttack = false;
            agent.activateWeaponBlue.fireActiv = false;
        }
    }

    public void Update(AIAgentBlue agent)
    {
        
    }

    public void Exit(AIAgentBlue agent)
    {
        
    }

    

   
}
