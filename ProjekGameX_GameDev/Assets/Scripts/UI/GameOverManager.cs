using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("General")]
    public GameObject gameOverCanvas;
    public GameObject aiGhost;
    public GameObject CanvasUI;
    public PlayerCam playerLook;
    public PauseMenu pauseMenu;


    [Header("Events")]
    public GameEvent onShowGameOver;

    public void ShowCanvas(Component sender, object data)
    {
        aiGhost.SetActive(false);
        CanvasUI.SetActive(false);
        playerLook.enabled = false;
        pauseMenu.isPaused = true;
        gameOverCanvas.SetActive(true);
        onShowGameOver.Raise();
    }
}
