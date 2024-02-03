using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachineBlue
{
    public AIStateBlue[] states;
    public AIAgentBlue agent;
    public AiStateIdBlue currentState;

    public AIStateMachineBlue(AIAgentBlue agent)
    {
        this.agent = agent;
        int numStates = System.Enum.GetNames(typeof(AiStateIdBlue)).Length;
        states = new AIStateBlue[numStates];
    }

    public void RegisterState(AIStateBlue state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }

    public AIStateBlue GetState(AiStateIdBlue stateId)
    {
        int index = (int)stateId;
        return states[index];
    }

    public void Update()
    {
        GetState(currentState)?.Update(agent);
    }

    public void ChangeState(AiStateIdBlue newState)
    {
        GetState(currentState)?.Exit(agent);
        currentState = newState;
        GetState(currentState)?.Enter(agent);
    }
}
