using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector] public bool isPaused = false;
    [SerializeField] private GameObject pauseCanvas;
    public IntroUI introUI;
    public PlayerDead playerDead;

    public LevelLoaderScript levelLoader;

    public void SetActiveHud(bool state)
    {
        pauseCanvas.SetActive(state);
    }
    public void SetActivePause()
    {
        if (!introUI.introPanelIsActive && !playerDead.playerIsDead)
        {
            isPaused = !isPaused;
            pauseCanvas.SetActive(isPaused);
        }
    }
    public void PauseGame()
    {

        if (isPaused)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            // AudioListener.pause = false;
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DOTween.Clear(true);
    }
    public void BacktoMainMenu()
    {
        SetActivePause();
        levelLoader.LoadMainMenu();

    }
    private void Update()
    {
        PauseGame();
    }
}