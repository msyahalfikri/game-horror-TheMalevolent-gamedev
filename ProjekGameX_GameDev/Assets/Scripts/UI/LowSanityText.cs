using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LowSanityText : MonoBehaviour
{
    public GameObject lowSanityText;
    private bool sanityLowOnce;
    private bool onFirstLow;
    private bool haveFadeOut;
    private bool havefadeIn;

    void Start()
    {
        onFirstLow = false;
        sanityLowOnce = false;
        lowSanityText.SetActive(false);
    }

    public void ShowText(Component sender, object data)
    {
        onFirstLow = true;
        lowSanityText.SetActive(true);
    }

    public void HideText(Component sender, object lightIntensityHigh)
    {
        if ((bool) lightIntensityHigh && onFirstLow) SanityLowOnce();
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    private void SanityLowOnce()
    {
        if (sanityLowOnce == false)
        {
            StartCoroutine(FadeTextToZeroAlpha(1.5f, lowSanityText.GetComponent<TextMeshProUGUI>()));
            sanityLowOnce = true;
        }
    }
}
