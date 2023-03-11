using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public AIStateMachine stateMachine;
    public AiStateID initialState;
    public NavMeshAgent navMeshAgent;
    [HideInInspector] public AIAgentConfig config;
    public Transform playerTransform;
    [HideInInspector] public InverseKinematic AiIK;
    public RandomSpawn randomSpawn;
    public AISensor sensor;

    public AudioSource sfxSound;
    // Start is called before the first frame update
    void Start()
    {
        AiIK = GetComponent<InverseKinematic>();
        randomSpawn = GetComponent<RandomSpawn>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        sensor = GetComponent<AISensor>();
        playerTransform = GameObject.FindGameObjectWithTag("PlayerHead").transform;
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.RegisterState(new AIIdleState());
        stateMachine.RegisterState(new AIPatrolState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
