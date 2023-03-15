using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// modified from: https://www.youtube.com/watch?v=7XVSLpo97k0
public class UIFollowWorld : MonoBehaviour
{
    private Transform lookAt = null;
    public Vector3 offset;
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAt != null)
        {   
            Vector3 pos = mainCam.WorldToScreenPoint(lookAt.position + offset);
            if (transform.position != pos)
            {
                transform.position = pos;
            }
        }
    }

    public void setLookAt(Transform transform)
    {   
        lookAt = transform;
    }
}
