using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleStateBlue : AIStateBlue
{
    public AiStateIdBlue GetId()
    {
        return AiStateIdBlue.Idle;
    }
    public void Enter(AIAgentBlue agent)
    {
        agent.patrulling.patrul = true;
        agent.patrulling._isPointWalk = true;
        agent.navMesh.stoppingDistance = 0;

    }
    public void Update(AIAgentBlue agent)
    {
        
        
        /*Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        if(playerDirection.magnitude > agent.config.maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = agent.transform.forward;

        playerDirection.Normalize();

        float dotProduct = Vector3.Dot(playerDirection, agentDirection);
        if(dotProduct > 0.0f)
        {
            agent.stateMachine.ChangeState(AiStateIdBlue.ChasePlayer);
        }*/
    }

    public void Exit(AIAgentBlue agent)
    {
        
    }

    

   

}
