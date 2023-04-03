using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MainMenu : MonoBehaviour
{
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
}
