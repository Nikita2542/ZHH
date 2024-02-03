using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AiStateIdBlue
{
    ChasePlayer,
    Death,
    Idle, 
    AttackPlayer,
    AttackWalk
}
public interface AIStateBlue
{
    AiStateIdBlue GetId();
    void Enter(AIAgentBlue agent);
    void Update(AIAgentBlue agent);
    void Exit(AIAgentBlue agent);

}
