using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;
    float timetoLoad = 30;
    float currentTime;
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadIntro()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void LoadStoryMode()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void LoadEndlessMode()
    {
        StartCoroutine(LoadLevel(3));
    }
}
