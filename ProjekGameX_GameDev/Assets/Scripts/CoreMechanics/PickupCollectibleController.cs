using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollectibleController : MonoBehaviour
{
    [Header("General")]
    [Min(.1f)]
    public float pickupSpeed = 20f;
    public float camHeightOffset = -1f;

    private GameObject pickupItem = null;
    private Vector3 targetPosition;
    private bool pickupActive = false;

    [Header("Events")]
    public GameEvent onPickupDone;

    // Update is called once per frame
    void Update()
    {
        if (pickupActive)
        {
            Vector3 directionToMove = targetPosition - pickupItem.transform.position;

            directionToMove = directionToMove.normalized * Time.deltaTime * pickupSpeed;

            float maxDistance = Vector3.Distance(pickupItem.transform.position, targetPosition);
            if (pickupItem.transform.position != targetPosition) {
                pickupItem.transform.position = pickupItem.transform.position + Vector3.ClampMagnitude(
                    directionToMove, maxDistance
                );
            }
            else
            {
                onPickupDone.Raise(pickupItem);
                Destroy(pickupItem); // DEVVV
                pickupActive = false;
            }   
        }
    }

    public void onPickupStart(Component sender, object data)
    {
        if (!pickupActive)
        {
            RaycastHit hit = (RaycastHit) data;
            pickupItem = hit.transform.gameObject;
            pickupItem.GetComponent<MeshCollider>().enabled = false;
            targetPosition = Camera.main.transform.position + Vector3.up * camHeightOffset;
            pickupActive = true;
        }
    }
}
