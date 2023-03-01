using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSway : MonoBehaviour
{
    [SerializeField] PlayerCam playerLook;
    public float swayAmount;
    public float swaySmoothing;
    public float swayResetSmoothing;
    public float swayClampX;
    public float swayClampY;
    Vector3 newFlashlightRotation;
    Vector3 newFlashlightRotationVelocity;

    Vector3 TargetFlashlightRotation;
    Vector3 TargetFlashlightRotationVelocity;

    private void Start()
    {
        newFlashlightRotation = transform.localRotation.eulerAngles;
    }

    private void Update()
    {
        // TargetFlashlightRotation.y += swayAmount * playerLook.xMouse * Time.deltaTime;
        // TargetFlashlightRotation.x += swayAmount * playerLook.yMouse * Time.deltaTime;
        // TargetFlashlightRotation = Vector3.SmoothDamp(TargetFlashlightRotation, Vector3.zero, ref TargetFlashlightRotationVelocity, swayResetSmoothing);
        // newFlashlightRotation = Vector3.SmoothDamp(newFlashlightRotation, TargetFlashlightRotation, ref newFlashlightRotationVelocity, swaySmoothing);
        // transform.localRotation = Quaternion.Euler(newFlashlightRotation);

        newFlashlightRotation.y += swayAmount * playerLook.xMouse * Time.deltaTime;
        newFlashlightRotation.x += swayAmount * playerLook.yMouse * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(newFlashlightRotation);
    }

}
