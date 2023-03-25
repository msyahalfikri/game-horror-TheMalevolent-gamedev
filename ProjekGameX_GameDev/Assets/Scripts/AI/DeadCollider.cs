using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadCollider : MonoBehaviour
{
    public PlayerDead playerDie;

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        playerDie.PlayerDie();
    }
}
