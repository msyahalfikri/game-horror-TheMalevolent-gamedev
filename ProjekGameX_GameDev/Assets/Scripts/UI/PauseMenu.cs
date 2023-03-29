using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector] public bool isPaused = false;
    [SerializeField] private GameObject pauseCanvas;
    public IntroUI introUI;

    public void SetActiveHud(bool state)
    {
        pauseCanvas.SetActive(state);
    }
    public void SetActivePause()
    {
        if (!introUI.introPanelIsActive)
        {
            isPaused = !isPaused;
            pauseCanvas.SetActive(isPaused);
            AudioListener.pause = isPaused;
        }
    }
    public void PauseGame()
    {

        if (isPaused)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SetActivePause();
    }
    public void BacktoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    private void Update()
    {
        PauseGame();
    }
}