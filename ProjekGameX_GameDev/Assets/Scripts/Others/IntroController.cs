using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public float introDuration = 15f;
    float num;
    public LevelLoaderScript levelLoader;
    void Update()
    {
        num += Time.deltaTime;

        if (num >= introDuration)
        {
            levelLoader.LoadStoryMode();
        }
        else
        {
            Debug.Log(num);
        }
    }
}
