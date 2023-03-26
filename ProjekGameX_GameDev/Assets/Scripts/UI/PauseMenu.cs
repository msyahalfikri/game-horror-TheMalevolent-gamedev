using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector]public bool isPaused = false;
    [SerializeField] private GameObject pauseCanvas;

   public void SetActiveHud(bool state)
    {
        pauseCanvas.SetActive(state);
    }
    public void SetActivePause()
    {  
        isPaused = !isPaused;
        pauseCanvas.SetActive(isPaused);
        Cursor.visible = isPaused;
        AudioListener.pause = isPaused;

        if (isPaused){
            Time.timeScale =  0;
            Cursor.lockState = CursorLockMode.None;
        }else{
            Time.timeScale =  1;
            Cursor.lockState = CursorLockMode.Locked;
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
}