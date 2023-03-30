using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUI : MonoBehaviour
{
    [Header("General")]
    public GameObject pickupUI;
    public Vector3 offset;

    [Header("Events")]
    public GameEvent onPickupCollectibleStart;

    private RaycastHit pickupItem;
    private Camera mainCam;
    private Transform lookAt = null;
    private Image pickupImage; 

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        pickupImage = pickupUI.GetComponent<Image>();
        pickupUI.GetComponent<Image>().enabled = false;
    }

    void Update()
    {
        if (lookAt != null)
        {   
            Vector3 pos = mainCam.WorldToScreenPoint(lookAt.position + offset);
            if (pickupUI.transform.position != pos)
            {
                pickupUI.transform.position = pos;
            }
        }
    }

    public void onCollectibleDetected(Component sender, object data)
    {
        if (!pickupImage.enabled)
        {
            pickupItem = (RaycastHit) data;
            Debug.Log(pickupItem.collider);
            pickupItem.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            lookAt = pickupItem.transform;
            pickupUI.transform.position = mainCam.WorldToScreenPoint(lookAt.position + offset);
            pickupImage.enabled = true;
        }
    }

    public void onCollectibleNotFound(Component sender, object data)
    {

        if (pickupImage.enabled) {
            pickupItem.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickupImage.enabled = false;
        }
    }

    public void onTryPickup(Component sender, object data)
    {
        if (pickupImage.enabled) onPickupCollectibleStart.Raise(pickupItem);
    }
}
