using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewCollectibleUI : MonoBehaviour
{
    public TextMeshProUGUI alertText;
    public float alertDuration = 5f;
    private bool timerIsRunning = false;
    private float timeRemaining;


    // Start is called before the first frame update
    void Start()
    {
        alertText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                alertText.enabled = false;
            }
        }
    }

    public void DisplayAlert(Component sender, object data)
    {
        
        alertText.enabled = true;
        timerIsRunning = true;
        timeRemaining = alertDuration;
    }

}
