using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolState : AIState
{
    public Transform centrePoint;
    GameObject playerGameobject;
    public AiStateID GetID()
    {
        return AiStateID.Patrol;
    }
    public void Enter(AIAgent agent)
    {
        centrePoint = GameObject.FindGameObjectWithTag("Point").transform;
        agent.navMeshAgent.speed = agent.config.walkSpeed;
        playerGameobject = null;

    }
    public void Update(AIAgent agent)
    {
        if (agent.navMeshAgent.remainingDistance <= agent.navMeshAgent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, agent.config.range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.navMeshAgent.SetDestination(point);
            }
        }
        if (!playerGameobject)
        {
            playerGameobject = FindPlayer(agent);
        }

    }
    public void Exit(AIAgent agent)
    {

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    GameObject FindPlayer(AIAgent agent)
    {
        if (agent.sensor.objects.Count > 0)
        {
            if (agent.sensor.IsInSight(agent.playerTransform.gameObject))
            {
                agent.stateMachine.ChangeState(AiStateID.ChasePlayer);
            }
        }
        return null;
    }
}
