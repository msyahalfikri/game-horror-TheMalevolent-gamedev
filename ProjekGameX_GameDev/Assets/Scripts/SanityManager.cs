using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityManager : MonoBehaviour
{
    public float maxSanity = 1000f;
    public float sanityDecay = 20f;
    public float sanityIncrease = 80f;
    public float currentSanity = 1000f;
    public Slider sanityBar; // Development Only

    // Start is called before the first frame update
    void Start()
    {
        currentSanity = maxSanity;
        sanityBar.maxValue = maxSanity;
    }

    // Update is called once per frame
    void Update()
    {   
        if (LightDetectionController.Light > 10) {
            increaseSanity();
        } else
        {
            decreaseSanity();
        }
        sanityBar.value = currentSanity;
    }

    public void increaseSanityBy(int value)
    {
        currentSanity += value;
        if (currentSanity > maxSanity)
        {
            currentSanity = maxSanity;
        }
    }

    private void increaseSanity()
    {
        currentSanity += sanityIncrease * Time.deltaTime;
        if (currentSanity > maxSanity)
        {
            currentSanity = maxSanity;
        }
    }

    private void decreaseSanity()
    {
        currentSanity -= sanityDecay * Time.deltaTime;
        if (currentSanity < 0)
        {
            currentSanity = 0;
        }
    }
}
