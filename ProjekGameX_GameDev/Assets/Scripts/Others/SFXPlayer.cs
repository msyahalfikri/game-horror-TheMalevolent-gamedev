using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioSource sfxSoundSource;
    public AudioClip horrorStinger1;

    public void PlayHorrorStinger1()
    {
        sfxSoundSource.PlayOneShot(horrorStinger1);
    }

}
