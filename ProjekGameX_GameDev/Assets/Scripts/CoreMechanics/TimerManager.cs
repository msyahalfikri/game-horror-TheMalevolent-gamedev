using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimerManager : MonoBehaviour
{
    [Header("General")]
    public float timeRemaining = 180f;
    public bool timerIsRunning = false;

    [Header("Events")]
    public GameEvent onTimerStart;
    public GameEvent onTimerUpdated;
    public GameEvent onTimerEnd;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        onTimerStart.Raise(timeRemaining);
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                onTimerUpdated.Raise(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                onTimerEnd.Raise();
            }
        }
    }
}