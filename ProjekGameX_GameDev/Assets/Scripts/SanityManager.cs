using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SanityManager : MonoBehaviour
{
    public float maxSanity = 1000f;
    public float insanityThreshold = 400f;
    public float sanityDecay = 20f;
    public float sanityIncrease = 80f;
    public int lightHealSanity = 11;
    public float currentSanity = 1000f;
    public bool sanityBarActive = false;
    public Slider sanityBar; // Development Only
    public GameObject sanityBarContainer;
    public AudioSource heartbeatAudioSource;

    public PostProcessVolume postProcessVolume;
    private ColorGrading _colorGrading;
    private Vignette _vignette;
    private AutoExposure _autoExposure;

    // Start is called before the first frame update
    void Start()
    {
        currentSanity = maxSanity;
        sanityBarContainer.SetActive(sanityBarActive);
        if (sanityBarActive)
        {
            sanityBar.maxValue = maxSanity;
        }

        postProcessVolume.profile.TryGetSettings(out _colorGrading);
        postProcessVolume.profile.TryGetSettings(out _vignette);
        postProcessVolume.profile.TryGetSettings(out _autoExposure);
        defaultPostProcess();
    }

    // Update is called once per frame
    void Update()
    {
        if (LightDetectionController.Light > lightHealSanity)
        {
            increaseSanity();
        }
        else
        {
            decreaseSanity();
        }
        if (sanityBarActive)
        {
            sanityBar.value = currentSanity;
        }

        // Heartbeat Audio Control
        if (currentSanity <= insanityThreshold)
        {
            if (!heartbeatAudioSource.isPlaying)
            {
                heartbeatAudioSource.Play();
            }
            heartbeatAudioSource.volume = 0.1f + ((1 - (currentSanity / insanityThreshold)) * 0.9f);
            InvokeRepeating("shakeCamera", 0f, 1.8f);
            setPostProcessBySanity();
        }
        else if (heartbeatAudioSource.isPlaying)
        {
            CancelInvoke("shakeCamera");
            heartbeatAudioSource.Stop();
            defaultPostProcess();
        }
        Debug.Log(LightDetectionController.Light);
    }

    private void setPostProcessBySanity()
    {
        _colorGrading.saturation.value = (1 - (currentSanity / insanityThreshold)) * -100f;
        _autoExposure.keyValue.value = .3f + ((currentSanity / insanityThreshold) * .7f);
        _vignette.active = true;
        _vignette.intensity.value = (1 - (currentSanity / insanityThreshold)) * .55f;
        _vignette.smoothness.value = .2f + (1 - (currentSanity / insanityThreshold)) * 1f;
        _vignette.roundness.value = .1f + (1 - (currentSanity / insanityThreshold)) * .8f;
    }

    private void defaultPostProcess()
    {
        _colorGrading.saturation.value = 0;
        _autoExposure.keyValue.value = 1;
        _vignette.intensity.value = 0;
        _vignette.smoothness.value = 0;
        _vignette.roundness.value = 0;
        _vignette.active = false;
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

    private void shakeCamera()
    {
        // Add camera shake function here
    }
}
