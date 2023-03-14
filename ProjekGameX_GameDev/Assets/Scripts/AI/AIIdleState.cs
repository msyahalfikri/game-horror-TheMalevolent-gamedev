using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    float waitTime;
    GameObject playerGameobject;
    public AiStateID GetID()
    {
        return AiStateID.Idle;
    }
    public void Enter(AIAgent agent)
    {
        waitTime = agent.config.maxWaitTime;
        playerGameobject = null;
    }
    public void Update(AIAgent agent)
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            agent.navMeshAgent.isStopped = false;
            agent.stateMachine.ChangeState(AiStateID.Patrol);
        }
        else if (!playerGameobject)
        {
            FindPlayer(agent);
        }
    }
    public void Exit(AIAgent agent)
    {

    }
    GameObject FindPlayer(AIAgent agent)
    {
        if (agent.sensor.objects.Count > 0)
        {
            if (agent.sensor.IsInSight(agent.playerTransform.gameObject))
            {
                agent.navMeshAgent.isStopped = false;
                agent.stateMachine.ChangeState(AiStateID.ChasePlayer);
            }
        }
        return null;
    }
}
