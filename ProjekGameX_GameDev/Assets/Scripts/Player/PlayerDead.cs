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
    public AudioClip horrorStinger3;
    public GameObject gameOverCanvas;
    public PauseMenu pauseMenu;
    [HideInInspector] public bool playerIsDead = false;
    public GameObject CanvasUI;
    public PlayerCam playerLook;
    // Start is called before the first frame update


    public void PlayerDie(Component sender, object data)
    {
        source.PlayOneShot(jumpscareSound);
        aiGhost.SetActive(false);
        JumpscareSet.SetActive(true);
        playerIsDead = true;
        CanvasUI.SetActive(false);
        StartCoroutine(ShowGameOverScreen());
        playerLook.enabled = false;
    }

    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(2f);
        source.PlayOneShot(horrorStinger3);
        if (playerIsDead)
        {
            pauseMenu.isPaused = true;
            gameOverCanvas.SetActive(true);
        }

    }
}
