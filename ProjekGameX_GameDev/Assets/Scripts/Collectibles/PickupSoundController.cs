using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public void PlayAudio(Component sender, object data)
    {
        audioSource.Play();
    }
}
