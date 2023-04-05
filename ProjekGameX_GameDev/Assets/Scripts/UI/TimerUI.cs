using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public void DisplayText(Component sender, object data)
    {
        float timeToDisplay = (float)data;
        if (timeToDisplay > 0)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format(" {0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timeText.text = "Times Up!";
        }
    }
}
