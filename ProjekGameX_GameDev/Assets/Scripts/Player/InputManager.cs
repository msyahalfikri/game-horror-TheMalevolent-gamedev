using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] PlayerMovement movement;
    [SerializeField] Flashlight flashlighController;
    [SerializeField] PickupCollectibleController pickupController;
    [SerializeField] PlayerCam mouseLook;
    [SerializeField] PauseMenu pauseMenu;
    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;
    PlayerControls.InteractionActions interactions;
    PlayerControls.UIActions UIActions;
    Vector2 horizontalInput;
    Vector2 mouseInput;

    [Header("Events")]
    public GameEvent onTryPickupCollectible;
    public GameEvent onToggleJournal;
    public GameEvent onJournalNext;
    public GameEvent onJournalPrev;

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        interactions = controls.Interaction;
        UIActions = controls.UI;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();


        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        groundMovement.Run.performed += _ => movement.OnRunPressed(true);
        groundMovement.Run.canceled += _ => movement.OnRunPressed(false);
        groundMovement.Crouch.performed += _ => movement.OnCrouchPressed();

        interactions.ControlFlashlight.performed += _ => flashlighController.SetFlashlightState();
        interactions.PickupCollectibles.performed += _ => onTryPickupCollectible.Raise();

        UIActions.Pause.performed += _ => pauseMenu.SetActivePause();
        UIActions.JournalNext.performed += _ => onJournalNext.Raise();
        UIActions.JournalPrev.performed += _ => onJournalPrev.Raise();
    }
    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);

        if (pauseMenu.isPaused)
        {
            interactions.ControlFlashlight.Disable();
        }
        else
        {
            interactions.ControlFlashlight.Enable();
        }

        if (pauseMenu.journalPaused)
        {
            UIActions.Pause.Disable();
        } else
        {
            UIActions.Pause.Enable();
        }

        if (pauseMenu.menuPaused)
        {
            UIActions.ToggleJournal.Disable();
        } else 
        {
            UIActions.ToggleJournal.Enable();
            UIActions.ToggleJournal.performed += _ => {
                onToggleJournal.Raise(!pauseMenu.journalPaused);
            };
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDestroy()
    {
        controls.Disable();
    }
}
