using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChasePlayerState : AIState
{
    float timer = 1.0f;
    public float chaseTimer;
    public AiStateID GetID()
    {
        return AiStateID.ChasePlayer;
    }
    public void Enter(AIAgent agent)
    {
        agent.AiIK.SetTargetTransform(agent.playerTransform);
        chaseTimer = agent.config.maxChaseTime;
    }
    public void Update(AIAgent agent)
    {
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        chaseTimer -= Time.deltaTime;
        if (chaseTimer <= 0 && (playerDirection.magnitude > agent.config.maxSightDistance))
        {
            agent.stateMachine.ChangeState(AiStateID.Idle);
        }
        else if (chaseTimer <= 0 && (playerDirection.magnitude < agent.config.maxSightDistance))
        {
            chaseTimer = agent.config.maxChaseTime;
        }

        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            float sqrDistance = (agent.playerTransform.position - agent.navMeshAgent.destination).sqrMagnitude;
            if (sqrDistance > agent.config.maxDistance)
            {
                agent.navMeshAgent.destination = agent.playerTransform.position;
            }
            timer = agent.config.maxTime;
        }

        Debug.Log("player Magnitude: " + playerDirection.magnitude);
        Debug.Log("chase time: " + chaseTimer);
    }
    public void Exit(AIAgent agent)
    {
        agent.AiIK.SetTargetTransform(null);
    }
}
