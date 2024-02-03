using UnityEngine;


public class AiChasePlayerStateBlue : AIStateBlue
{
    
    float timer = 0f;
    public AiStateIdBlue GetId()
    {
        return AiStateIdBlue.ChasePlayer;
    }

    public void Enter(AIAgentBlue agent)
    {
        
    }

    public void Update(AIAgentBlue agent)
    {
        agent.stateMachine.ChangeState(AiStateIdBlue.AttackPlayer);
        if (!agent.navMesh.enabled)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (!agent.navMesh.hasPath)
        {
            agent.navMesh.destination = agent.playerTransform.position;
            ///agent.patrulling.patrulZone.position = agent.playerTransform.position;
        }
        if (timer < 0f)
        {
            
            float sqDistance = (agent.playerTransform.position - agent.navMesh.destination).sqrMagnitude;
            if (sqDistance > agent.config.maxDistance * agent.config.maxDistance)
            {
                agent.navMesh.destination = agent.playerTransform.position;
                ///agent.patrulling.patrulZone.position = agent.playerTransform.position;
            }
            timer = agent.config.maxTime;
        }
    }

    public void Exit(AIAgentBlue agent)
    {
        
    }


}
