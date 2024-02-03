using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackWalkStateBlue : AIStateBlue
{
    float timer = 0f;
    float timeWalk = 0f;
    public AiStateIdBlue GetId()
    {
        return AiStateIdBlue.AttackWalk;
    }
    public void Enter(AIAgentBlue agent)
    {
        agent.activateWeaponBlue.fireActiv = true;
        agent.navMesh.stoppingDistance = agent.config.maxDistancePlayer;
    }
    public void Update(AIAgentBlue agent)
    {
        if (agent.jumpAwayBlue.isDodge == false) 
        {
            if (agent.patrulling._isAttack)
            {
                if (agent.playerTransform != null)
                {
                    Vector3 maxDistance = agent.transform.position - agent.playerTransform.position;
                    if (agent.config.maxDistancePlayer > maxDistance.magnitude)
                    {
                        agent.mutant.WeaponWalk(false);
                        agent.mutant.WeaponAim(true, 1);
                    }
                    else
                    {
                        agent.mutant.WeaponAim(false, 1);
                        agent.mutant.WeaponWalk(true);

                    }
                }


                if (!agent.navMesh.enabled)
                {
                    return;
                }
                //timer -= Time.deltaTime;
                timeWalk -= Time.deltaTime;
                
                if (timeWalk < 0)
                {
                    if (!agent.navMesh.hasPath)
                    {
                        float ranX = Random.Range(-agent.config.radiusWalkAttack, agent.config.radiusWalkAttack);
                        float ranZ = Random.Range(-agent.config.radiusWalkAttack, agent.config.radiusWalkAttack);

                        Vector3 _pointWalk = new Vector3(agent.transform.position.x + ranX, agent.transform.position.y, agent.transform.position.z + ranZ);

                        agent.navMesh.destination = _pointWalk;
                        timeWalk = agent.config.attackTimeWalk;
                        //agent.navMesh.destination = agent.playerTransform.position;
                        ///agent.patrulling.patrulZone.position = agent.playerTransform.position;
                    }
                }
                /*if (timer < 0f)
                {

                    float sqDistance = (agent.playerTransform.position - agent.navMesh.destination).sqrMagnitude;
                    if (sqDistance > agent.config.maxDistance * agent.config.maxDistance)
                    {
                        agent.navMesh.destination = agent.playerTransform.position;
                        ///agent.patrulling.patrulZone.position = agent.playerTransform.position;
                    }
                    timer = agent.config.maxTime;
                }*/
            }
            else
            {
                agent.activateWeaponBlue.fireActiv = false;
            }





        }
        
       
        
        
        
    }

    public void Exit(AIAgentBlue agent)
    {
        
    }

    

   
}
