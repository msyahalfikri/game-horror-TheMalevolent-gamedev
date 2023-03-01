using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [HideInInspector] public StaminaController _staminaController;
    float speed = 11f;
    [SerializeField] float gravity = -30f;
    public float walkSpeed;
    public float runSpeed;

    public float crouchSpeed;
    public float crouchYScale;
    [HideInInspector] public float startYScale;

    [SerializeField] float jumpHeight = 3.5f;
    bool jump;
    bool isRunning;
    [SerializeField] bool isCrouched = false;
    Vector3 verticalVelocity = Vector3.zero;
    public bool isGrounded;
    Vector2 horizontalInput;
    [HideInInspector] public Vector3 horizontalVelocity;

    public movementState state;
    public enum movementState
    {
        walking,
        sprinting,
        crouching,
        air
    }
    private void Start()
    {
        _staminaController = GetComponent<StaminaController>();
        startYScale = transform.localScale.y;
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
        isRunning = state;
    }

    public void StateHandler()
    {

        if (isRunning && _staminaController.hasRegenerated && isCrouched == false && horizontalVelocity.magnitude >= walkSpeed)
        {
            state = movementState.sprinting;
            speed = runSpeed;
            if (_staminaController.playerStamina > 0)
            {
                _staminaController.isSprinting = true;
                _staminaController.Sprinting();
            }

        }
        else if (isGrounded && isCrouched == false)
        {
            state = movementState.walking;
            speed = walkSpeed;
            _staminaController.isSprinting = false;
        }
        else if (isGrounded && isCrouched == true)
        {
            state = movementState.crouching;
            speed = crouchSpeed;
        }
        else
        {
            state = movementState.air;
        }
    }

    public void OnCrouchPressed()
    {
        isCrouched = !isCrouched;
        if (isCrouched)
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }

    }

}
