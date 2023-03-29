using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] float sensX = 8f;
    [SerializeField] float sensY = 0.5f;
    [HideInInspector] public float xMouse, yMouse;
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0;

    private void Start()
    {

    }

    private void Update()
    {
        transform.Rotate(Vector3.up, xMouse * Time.deltaTime);
        xRotation -= yMouse * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }
    public void ReceiveInput(Vector2 mouseInput)
    {
        xMouse = mouseInput.x * sensX;
        yMouse = mouseInput.y * sensY;
    }
}

