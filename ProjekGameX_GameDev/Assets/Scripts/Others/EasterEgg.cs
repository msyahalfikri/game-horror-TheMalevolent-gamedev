using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public GameObject jumpscareImage;
    public AudioSource jumpscareSound;
    public AudioClip freddySound;

    public bool isColliding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = true;
        }

        StartCoroutine(ShowJumpscare());
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = false;
        }
        StopJumpscare();
    }

    IEnumerator ShowJumpscare()
    {
        yield return new WaitForSeconds(6f);
        if (isColliding)
        {
            jumpscareImage.SetActive(true);
            jumpscareSound.PlayOneShot(freddySound);
        }
    }

    private void StopJumpscare()
    {
        jumpscareImage.SetActive(false);
        jumpscareSound.Stop();
    }
}
