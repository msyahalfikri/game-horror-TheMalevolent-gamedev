using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleRaycast : MonoBehaviour
{
    [Header("General")]
    public LayerMask collectibleLayerMask;
    public Transform playerCamTransform;
    [Min(.1f)]
    public float hitRange = 5f;

    [Header("Event")]
    public GameEvent onCollectibleDetected;
    public GameEvent onCollectibleNotFound;

    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Physics.BoxCast(
            playerCamTransform.position,
            playerCamTransform.localScale,
            playerCamTransform.forward,
            out hit,
            playerCamTransform.rotation,
            hitRange,
            collectibleLayerMask
            ))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            onCollectibleDetected.Raise(hit);
        }
        else
        {
            onCollectibleNotFound.Raise();
        }
    }
}
