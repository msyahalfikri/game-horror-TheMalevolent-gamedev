using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public InputActionProperty thumbAnimation;
    public InputActionProperty pauseAction;
    [SerializeField] PauseMenu pauseMenu;
    private Flashlight flashlight;
    public Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        flashlight = GetComponentInParent<Flashlight>();
    }

    private void OnEnable()
    {
        thumbAnimation.action.performed += OnBButtonPressed;
        pauseAction.action.performed += OnYButtonPressed;
    }

    private void OnDisable()
    {
        thumbAnimation.action.performed -= OnBButtonPressed;
        pauseAction.action.performed += OnYButtonPressed;
    }


    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
       handAnimator.SetFloat("Grip", gripValue);
    }

    private void OnBButtonPressed(InputAction.CallbackContext context)
    {
        flashlight.SetFlashlightState(); // Call the flashlight function
    }

    private void OnYButtonPressed(InputAction.CallbackContext context)
    {
        pauseMenu.SetActivePause();
    }
}
