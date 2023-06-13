using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DOTween.Clear(true);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public GameObject optionsPanel;

    public void OnPlayButtonClick()
    {
        // Show/hide the options panel
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }

    public void OnStoryModeButtonClick()
    {
        // Load StoryMode scene
        SceneManager.LoadScene("StoryMode");
    }

    public void OnEndlessModeButtonClick()
    {
        // Load EndlessMode scene
        SceneManager.LoadScene("EndlessMode");
    }

}
