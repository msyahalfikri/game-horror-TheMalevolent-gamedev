using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public Camera playerCam;
    public GameObject JumpscareSet;
    public GameObject aiGhost;
    public AudioSource source;
    public AudioClip jumpscareSound;
    [HideInInspector] public bool playerIsDead = false;
    // Start is called before the first frame update
    public void PlayerDie()
    {
        source.PlayOneShot(jumpscareSound);
        aiGhost.SetActive(false);
        JumpscareSet.SetActive(true);
        playerIsDead = true;
        StartCoroutine(ShowGameOverScreen());
    }

    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(3f);
        if (playerIsDead)
        {
            //munculkan Game Over Panel
            Debug.Log("you are dead!");
        }

    }
}
