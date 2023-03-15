using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupCollectibleController : MonoBehaviour
{
    public LayerMask collectibleLayerMask;
    public Transform playerCamTransform;
    public GameObject pickUpUI;

    [Min(.1f)]
    public float pickupSpeed = 20f;

    [Min(1)]
    public float hitRange = 5f;

    public float camHeightOffset = -1f;
    private RaycastHit hit;
    private GameObject pickupItem;
    private Vector3 targetPosition;
    private bool pickupActive = false;

    // Start is called before the first frame update
    void Start()
    {
            pickUpUI.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Activate UI when Ray hit
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.GetComponent<Image>().enabled = false;
            pickUpUI.GetComponent<UIFollowWorld>().setLookAt(null);
        }
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
            pickUpUI.GetComponent<UIFollowWorld>().setLookAt(hit.transform);
            pickUpUI.GetComponent<Image>().enabled = true;
        }

        // Pickup function
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
                Destroy(pickupItem);
                pickupActive = false;
            }
            
        }
    }

    public void pickupCollectible() {
        if (pickUpUI.activeSelf)
        {
            pickupItem = hit.transform.gameObject;
            pickupItem.GetComponent<MeshCollider>().enabled = false;
            targetPosition = playerCamTransform.position + Vector3.up * camHeightOffset;
            pickupActive = true;
        }
    }
}
