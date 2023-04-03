using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadCollider : MonoBehaviour
{
    [Header("Events")]
    public GameEvent onPlayerDeath;
    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        onPlayerDeath.Raise();
    }
}
