using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CollectibleScript")]
public class Collectible : ScriptableObject
{
    [Header("General")]
    public string collectibleID;

    [Header("Events")]
    public GameEvent onCollectiblePickup;

    public void PickupEvent()
    {
        // Add UniqueEvent
    }

    public void OnPickup(Component sender, object data)
    {   
        onCollectiblePickup.Raise(collectibleID);
        PickupEvent();
    }
}
