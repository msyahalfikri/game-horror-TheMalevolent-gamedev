using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class InsanityFxManager : MonoBehaviour
{
    public AudioSource heartbeatAudioSource;
    public PostProcessVolume postProcessVolume;

    public float insanityPercentTrigger = 0.01f;
    private ColorGrading _colorGrading;
    private Vignette _vignette;
    private AutoExposure _autoExposure;

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out _colorGrading);
        postProcessVolume.profile.TryGetSettings(out _vignette);
        postProcessVolume.profile.TryGetSettings(out _autoExposure);
        defaultPostProcess();
    }

    public void onInsanityUpdated(Component sender, object data)
    {
        float insanityPercent = (float) data;
        if (insanityPercent < insanityPercentTrigger || insanityPercent > 0.98f)
        {
            defaultPostProcess();
            if (heartbeatAudioSource.isPlaying) heartbeatAudioSource.Stop();
            StopCoroutine(shakeCamera());
        }
        else
        {
            setPostProcessByinsanityPercent(insanityPercent);
            if (!heartbeatAudioSource.isPlaying) heartbeatAudioSource.Play();
            heartbeatAudioSource.volume = 0.1f + ((1 - insanityPercent) * 0.9f);
            StartCoroutine(shakeCamera());
        }
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

    private void setPostProcessByinsanityPercent(float sanityPercent)
    {
        _colorGrading.saturation.value = (1 - sanityPercent) * -100f;
        _autoExposure.keyValue.value = .3f + (sanityPercent * .7f);
        _vignette.active = true;
        _vignette.intensity.value = (1 - sanityPercent) * .55f;
        _vignette.smoothness.value = .2f + (1 - sanityPercent) * 1f;
        _vignette.roundness.value = .1f + (1 - sanityPercent) * .8f;
    }

    IEnumerator shakeCamera()
    {
        CameraShaker.Invoke();
        yield return new WaitForSeconds(0.4f);
    }
}
