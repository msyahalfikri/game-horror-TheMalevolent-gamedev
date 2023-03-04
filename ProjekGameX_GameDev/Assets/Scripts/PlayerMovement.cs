using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController controller;
    [HideInInspector] public StaminaController _staminaController;
    public Transform cameraHolder;
    public movementState state;

    [Header("Player Movement")]
    float speed = 11f;
    [SerializeField] float gravity = -30f;
    public float walkSpeed;
    public float runSpeed;
    public float crouchWalkSpeed;
    [SerializeField] float jumpHeight = 3.5f;
    bool jump;
    public bool runButtonPressed;
    Vector3 verticalVelocity = Vector3.zero;
    [HideInInspector] public bool isGrounded;
    Vector2 horizontalInput;
    [HideInInspector] public Vector3 horizontalVelocity;

    [Header("Crouch")]
    // public float crouchYScale;
    // [HideInInspector] public float startYScale;
    [SerializeField] bool isCrouched = false;
    public float cameraStandHeight;
    public float crouchCameraHeight;
    public float crouchColliderHeight;
    private float standColliderHeight;
    private float cameraHeight;
    private float cameraHeightVelocity;
    public float playerCrouchSmoothing;

    [Header("Animation")]
    public float flashlightAnimationSpeed;


    public enum movementState
    {
        walking,
        sprinting,
        crouchingIdle,
        crouchingWalking,
        StandingIdle,
        air
    }
    private void Start()
    {
        _staminaController = GetComponent<StaminaController>();
        cameraHeight = cameraHolder.localPosition.y;
        standColliderHeight = controller.height;
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
        StateHandler();
        CalculateCameraHeight();

    }
    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }
    public void OnJumpPressed()
    {
        jump = true;
    }

    public void OnRunPressed(bool state)
    {
        if (!isCrouched)
        {
            runButtonPressed = state;
        }
    }

    public void StateHandler()
    {
        bool isMoving;
        if (horizontalInput.Equals(Vector3.zero))
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (runButtonPressed && _staminaController.hasRegenerated && isCrouched == false && horizontalVelocity.magnitude >= walkSpeed && isMoving)
        {
            if (_staminaController.playerStamina > 0)
            {
                state = movementState.sprinting;
                speed = runSpeed;
                _staminaController.Sprinting();
            }
        }
        else if (isGrounded && isCrouched == false && isMoving)
        {
            state = movementState.walking;
            _staminaController.isSprinting = false;
            speed = walkSpeed;
            flashlightAnimationSpeed = CalculateAnimationSpeed(1f);
        }
        else if (isGrounded && isCrouched == true && isMoving)
        {
            state = movementState.crouchingWalking;
            _staminaController.isSprinting = false;
            speed = crouchWalkSpeed;
            flashlightAnimationSpeed = CalculateAnimationSpeed(0.5f);
        }
        else if (isGrounded && isCrouched == true && !isMoving)
        {
            state = movementState.crouchingIdle;
            _staminaController.isSprinting = false;
            flashlightAnimationSpeed = CalculateAnimationSpeed(1f);
        }
        else if (isGrounded && isCrouched == false && !isMoving)
        {
            state = movementState.StandingIdle;
            _staminaController.isSprinting = false;
            flashlightAnimationSpeed = CalculateAnimationSpeed(1f);
        }
        else
        {
            state = movementState.air;
            flashlightAnimationSpeed = CalculateAnimationSpeed(1f);
        }
        Debug.Log(_staminaController.isSprinting);
    }

    public float CalculateAnimationSpeed(float speed)
    {
        float animationSpeed;
        animationSpeed = speed;
        return animationSpeed;
    }

    public void OnCrouchPressed()
    {
        isCrouched = !isCrouched;
    }
    private void CalculateCameraHeight()
    {
        var stanceCameraHeight = cameraStandHeight;
        var stanceColliderHeight = standColliderHeight;

        if (isCrouched)
        {
            stanceCameraHeight = crouchCameraHeight;
            stanceColliderHeight = crouchColliderHeight;
        }

        cameraHeight = Mathf.SmoothDamp(cameraHolder.localPosition.y, stanceCameraHeight, ref cameraHeightVelocity, playerCrouchSmoothing);
        cameraHolder.localPosition = new Vector3(cameraHolder.localPosition.x, cameraHeight, cameraHolder.localPosition.z);

        controller.height = Mathf.SmoothDamp(controller.height, stanceColliderHeight, ref cameraHeightVelocity, playerCrouchSmoothing);

    }

}
