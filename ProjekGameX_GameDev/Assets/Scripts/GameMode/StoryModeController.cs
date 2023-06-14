using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryModeController : MonoBehaviour
{
    [Header("Events")]
    public GameEvent onStoryModeStart;
    void Start()
    {
        onStoryModeStart.Raise();
    }
}
