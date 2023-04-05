using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public AudioClip turnOnSound;
    public AudioSource interactSoundSource;
    [HideInInspector] public bool flashlightIsOn = false;
    public TextMeshProUGUI useFlashlightText;
    private bool hasUsedOnce;

    private void Start()
    {
        flashlightIsOn = false;
        flashlight.SetActive(false);
        hasUsedOnce = false;
    }
    private void Update()
    {
        if (flashlightIsOn)
        {
            flashlight.SetActive(true);
        }
        else if (flashlightIsOn == false)
        {
            flashlight.SetActive(false);
        }
    }

    public void SetFlashlightState()
    {
        flashlightIsOn = !flashlightIsOn;
        interactSoundSource.PlayOneShot(turnOnSound);
        HasUsedFlashlightOnce();
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

    private void HasUsedFlashlightOnce()
    {
        if (hasUsedOnce == false)
        {
            StartCoroutine(FadeTextToZeroAlpha(1.5f, useFlashlightText));
            hasUsedOnce = true;
        }

    }
}
