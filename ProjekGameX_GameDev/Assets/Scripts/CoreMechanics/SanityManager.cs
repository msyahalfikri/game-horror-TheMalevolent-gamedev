using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityManager : MonoBehaviour
{
    [Header("General")]
    public float currentSanity;
    public float maxSanity = 1000f;
    public float insanityThreshold = 500f;
    public float sanityDecay = 40f;
    public float sanityIncrease = 100f;

    [Header("Events")]
    public GameEvent onSanityAwake;
    public GameEvent onSanityUpdated;
    public GameEvent onPlayerInsane;
    public GameEvent onPlayerDeath;

    private bool lookingAtLight = false;
    private bool isSanityRunning;

    // Start is called before the first frame update
    void Start()
    {
        currentSanity = maxSanity;
        onSanityAwake.Raise(maxSanity);
        isSanityRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSanityRunning)
        {
            if (!lookingAtLight)
            {
                currentSanity -= Time.deltaTime * sanityDecay;
                if (currentSanity < 0)
                {
                    currentSanity = 0;
                    isSanityRunning = false;
                    onPlayerDeath.Raise();
                }
            } 
            else
            {
                currentSanity += Time.deltaTime * sanityIncrease;
                if (currentSanity > maxSanity) currentSanity = maxSanity;
            }

            if (currentSanity < insanityThreshold)
            {
                onPlayerInsane.Raise(calcInsanityPercent());
            }
            onSanityUpdated.Raise(currentSanity);
        }
    }

    private float calcInsanityPercent()
    {
        return currentSanity / insanityThreshold;
    }

    public void onLightIntensityChanged(Component sender, object data)
    {
        lookingAtLight = (bool) data;
    }
}
