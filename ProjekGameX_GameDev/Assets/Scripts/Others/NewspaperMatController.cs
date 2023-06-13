using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperMatController : MonoBehaviour
{
    public bool isLose = true;
    public GameObject[] newspapers;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLose)
        {
            newspapers[0].SetActive(true);
            newspapers[1].SetActive(false);
        }
        else
        {
            newspapers[0].SetActive(false);
            newspapers[1].SetActive(true);
        }
    }
}
