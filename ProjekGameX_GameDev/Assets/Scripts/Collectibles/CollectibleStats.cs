using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStats : MonoBehaviour
{
    [Header("General")]
    public List<GameObject> collectibleExist;
    public int collectedCollectible = 0;
    private bool isEndlessMode = false;

    [Header("Events")]
    public GameEvent onCollectibleBatchExhausted;
    public GameEvent onCollectibleStatsUpdated;

    public void OnCollectibleSpawn(Component sender, object data)
    {
        GameObject collectible = (GameObject) data;
        collectibleExist.Add(collectible);
    }

    public void OnEndlessStart(Component sender, object data)
    {
        isEndlessMode = true;
    }

    public void OnStoryStart(Component sender, object data)
    {
        isEndlessMode = false;
    }

    public void OnCollectiblePickup(Component sender, object data)
    {
        GameObject collectible = (GameObject) data;
        collectibleExist.Remove(collectible);
        collectedCollectible++;
        onCollectibleStatsUpdated.Raise(collectedCollectible);
        if (collectibleExist.Count == 0)
        {
            if (isEndlessMode)
            {
                onCollectibleBatchExhausted.Raise();
            }
            else 
            {
                Debug.Log("Complete");
            }
        }
    }

    public void OnShowGameOver(Component sender, object data)
    {
        onCollectibleStatsUpdated.Raise(collectedCollectible);
    }
}
