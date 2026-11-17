using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -20f;

    [Header("Camera Settings")]
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float lookSensitivity = 2f;
    [SerializeField] private float minCameraAngle = -30f;
    [SerializeField] private float maxCameraAngle = 60f;

    private CharacterController controller;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private float verticalVelocity;
    private float cameraPitch;

    private bool isSprinting;
    private bool jumpRequested;
    private bool editorKeyboardWasMoving;
    

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ReadEditorInput();

        HandleLook();
        HandleMovement();
        HandleJumpAndGravity();
    }

    private void ReadEditorInput()
    {
#if UNITY_EDITOR
    Vector2 keyboardMove = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical")
    );

    if (keyboardMove.sqrMagnitude > 0.01f)
    {
        moveInput = keyboardMove;
        editorKeyboardWasMoving = true;
    }
    else if (editorKeyboardWasMoving)
    {
        moveInput = Vector2.zero;
        editorKeyboardWasMoving = false;
    }

    if (Input.GetKeyDown(KeyCode.LeftShift))
        isSprinting = true;

    if (Input.GetKeyUp(KeyCode.LeftShift))
        isSprinting = false;

    if (Input.GetKeyDown(KeyCode.Space))
        jumpRequested = true;

    if (Input.GetMouseButton(1))
    {
        lookInput = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")
        );
    }
#endif
}
    

    private void HandleMovement()
    {
        Vector3 moveDirection =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        Vector3 movement = moveDirection * currentSpeed;

        movement.y = verticalVelocity;

        controller.Move(movement * Time.deltaTime);
    }

    private void HandleLook()
    {
        float mouseX = lookInput.x * lookSensitivity;
        float mouseY = lookInput.y * lookSensitivity;

        transform.Rotate(0f, mouseX, 0f);

        cameraPitch -= mouseY;

        cameraPitch = Mathf.Clamp(
            cameraPitch,
            minCameraAngle,
            maxCameraAngle
        );

        cameraPivot.localRotation =
            Quaternion.Euler(cameraPitch, 0f, 0f);

        lookInput = Vector2.zero;
    }

    private void HandleJumpAndGravity()
    {
        if (controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        if (jumpRequested && controller.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(
                jumpHeight * -2f * gravity
            );
        }

        jumpRequested = false;

        verticalVelocity += gravity * Time.deltaTime;
    }

    // Mobile input methods

    public void SetMoveInput(Vector2 input)
    {
        moveInput = Vector2.ClampMagnitude(input, 1f);
    }

    public void SetLookInput(Vector2 input)
    {
        lookInput = input;
    }

    public void SetSprint(bool sprinting)
    {
        isSprinting = sprinting;
    }

    public void Jump()
    {
        jumpRequested = true;
    }
}
