using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUI : MonoBehaviour
{
    public GameObject introPanel;
    public PauseMenu pauseMenu;
    public InputManager inputManager;
    [HideInInspector] public bool introPanelIsActive;
    void Start()
    {
        pauseMenu.isPaused = true;
        introPanelIsActive = true;
    }

    public void IntroUIStartGame()
    {
        pauseMenu.isPaused = false;
        introPanel.SetActive(false);
        introPanelIsActive = false;
    }
}
