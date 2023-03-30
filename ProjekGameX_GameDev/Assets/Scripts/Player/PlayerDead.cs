using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public Camera playerCam;
    public GameObject JumpscareSet;
    public GameObject aiGhost;
    public AudioSource source;
    public AudioClip jumpscareSound;
    public GameObject gameOverCanvas;
    public PauseMenu pauseMenu;
    [HideInInspector] public bool playerIsDead = false;
    public GameObject CanvasUI;
    // Start is called before the first frame update

    public void PlayerDie()
    {
        source.PlayOneShot(jumpscareSound);
        aiGhost.SetActive(false);
        JumpscareSet.SetActive(true);
        playerIsDead = true;
        CanvasUI.SetActive(false);
        StartCoroutine(ShowGameOverScreen());
    }

    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(2f);
        if (playerIsDead)
        {
            pauseMenu.isPaused=true;
            gameOverCanvas.SetActive(true);
            
            //munculkan Game Over Panel
            Debug.Log("you are dead!");
        }

    }
}
