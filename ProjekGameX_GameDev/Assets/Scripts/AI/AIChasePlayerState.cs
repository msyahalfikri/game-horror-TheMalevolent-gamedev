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
        agent.sfxSound.PlayOneShot(agent.horrorStinger);
        agent.ghostVoice.clip = agent.Angry;
        agent.BGMSource.clip = agent.chaseBGM;
        agent.AiIK.SetTargetTransform(agent.playerTransform);
        chaseTimer = 0;
        agent.navMeshAgent.speed = agent.config.runSpeed;
        agent.ghostVoice.Play();
        agent.BGMSource.Play();
        agent.deadCollider.SetActive(true);
    }
    public void Update(AIAgent agent)
    {

        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        chaseTimer += Time.deltaTime;
        if ((chaseTimer >= agent.config.ChaseTime)) //(&& playerDirection.magnitude > agent.config.maxSightDistance)
        {
            agent.randomSpawn.RandomSpawnNearPlayer();
            agent.navMeshAgent.isStopped = true;
            agent.stateMachine.ChangeState(AiStateID.Idle);
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
        Debug.Log(chaseTimer);
    }
    public void Exit(AIAgent agent)
    {
        agent.AiIK.SetTargetTransform(null);
        agent.ghostVoice.clip = agent.humming;
        agent.BGMSource.clip = agent.horrorAmbiance;
        agent.ghostVoice.Play();
        agent.BGMSource.Play();
        agent.deadCollider.SetActive(false);
    }
}
