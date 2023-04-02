using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleStatsUI : MonoBehaviour
{
    public TextMeshProUGUI collectibleText;

    public void DisplayText(Component sender, object data)
    {
        int collectibleCollected = (int)data;
        collectibleText.text = string.Format("Items Collected: {0}", collectibleCollected);
    }
}
