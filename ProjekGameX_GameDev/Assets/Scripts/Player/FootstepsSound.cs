using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] footstepsSounds;

    void StepSounds()
    {
        int random = Random.Range(0, 5);
        source.clip = footstepsSounds[random];
        // source.pitch = Random.Range(0.8f, 1f);
        source.Play();
    }

}
