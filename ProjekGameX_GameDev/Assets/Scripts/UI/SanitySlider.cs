using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SanitySlider : MonoBehaviour
{
    public Slider sanitySlider;

    public void OnSanityStart(Component sender, object data)
    {
        sanitySlider.maxValue = (float) data;
    }
    
    public void UpdateSanitySlider(Component sender, object data)
    {
        sanitySlider.value = (float) data;
    }
}
