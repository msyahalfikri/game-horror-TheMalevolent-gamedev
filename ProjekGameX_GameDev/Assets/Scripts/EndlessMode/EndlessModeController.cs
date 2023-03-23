using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessModeController : MonoBehaviour
{
    [Header("Events")]
    public GameEvent onEndlessModeStart;
    void Start()
    {
        onEndlessModeStart.Raise();
    }
}
