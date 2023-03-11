using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AIAgentConfig : ScriptableObject
{
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    public float maxSightDistance = 5.0f;
    public float maxChaseTime = 10.0f;
    public float range;
    public float walkSpeed = 3f;
    public float runSpeed = 8.5f;

    public float maxWaitTime = 3.0f;
}
