using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EscapeColliderController : MonoBehaviour
{
    [HideInInspector] public bool isColliding = false;
    public TextMeshProUGUI escapeText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = true;
        }
        escapeText.gameObject.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = false;
        }
        escapeText.gameObject.SetActive(false);

    }
}
