using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleController : MonoBehaviour
{
    public GameObject dustParticleSphere;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dustParticleSphere.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dustParticleSphere.SetActive(false);
        }
    }
}
