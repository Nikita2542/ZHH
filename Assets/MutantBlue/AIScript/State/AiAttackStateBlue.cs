using UnityEngine;


public class AiAttackStateBlue : AIStateBlue
{
    public AiStateIdBlue GetId()
    {
        return AiStateIdBlue.AttackPlayer;
    }
    public void Enter(AIAgentBlue agent)
    {
        agent.activateWeaponBlue.fireActiv = true;
        agent.navMesh.stoppingDistance = agent.config.maxDistancePlayer;
    }
    public void Update(AIAgentBlue agent)
    {
        if (agent.patrulling._isAttack)
        {
            Vector3 maxDistance = agent.transform.position - agent.playerTransform.position;
            if (agent.config.maxDistancePlayer < maxDistance.magnitude)
            {
                agent.mutant.WeaponAim(false, 1);
                agent.mutant.WeaponWalk(true);
                agent.stateMachine.ChangeState(AiStateIdBlue.AttackWalk);
            }
            else
            {
                agent.mutant.WeaponWalk(false);
                agent.mutant.WeaponAim(true, 1);
            }
        }
        else
        {
            agent.activateWeaponBlue.fireActiv = false;
        }
        
        
    }
    public void Exit(AIAgentBlue agent)
    {
        
    }

   

   
}
