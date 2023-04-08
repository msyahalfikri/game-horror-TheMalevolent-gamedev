using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    [Header("General")]
    public GameObject JumpscareSet;
    public AudioSource source;
    public AudioClip jumpscareSound;
    public AudioClip horrorStinger3;
    public PauseMenu pauseMenu;
    public PlayerCam playerLook;
    public GameObject aiGhost;
    public GameObject CanvasUI;
    public Flashlight flashlightController;


    [HideInInspector] public bool playerIsDead = false;

    [Header("Events")]
    public GameEvent onGameOver;

    public void PlayerDie(Component sender, object data)
    {
        source.PlayOneShot(jumpscareSound);
        JumpscareSet.SetActive(true);
        playerIsDead = true;
        playerLook.enabled = false;
        aiGhost.SetActive(false);
        CanvasUI.SetActive(false);
        flashlightController.flashlightIsOn = false;

        StartCoroutine(ShowGameOverScreen());
    }

    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(2f);
        source.PlayOneShot(horrorStinger3);
        if (playerIsDead)
        {
            pauseMenu.isPaused = true;
            onGameOver.Raise();
        }

    }
}
