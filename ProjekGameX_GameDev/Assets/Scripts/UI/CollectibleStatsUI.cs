using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleStatsUI : MonoBehaviour
{
    public Text collectibleText;

    public void DisplayText(Component sender, object data)
    {
        int collectibleCollected = (int) data;
        collectibleText.text = string.Format("Collected Items: {0}", collectibleCollected);
    }
}
