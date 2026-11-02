using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
[RequireComponent(typeof(CharacterController))]
public sealed class ZsAnimal : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField, Min(0f)] private float moveSpeed = 4f;
    [SerializeField, Min(0f)] private float turnSpeed = 720f;
    [SerializeField] private float gravity = -20f;

    [Header("Camera")]
    [SerializeField] private Camera playerCamera;
    [SerializeField, Min(0.1f)] private float cameraDistance = 4f;
    [SerializeField] private float cameraHeight = 1.6f;
    [SerializeField] private float lookHeight = 1.4f;
    [SerializeField, Min(0f)] private float lookSensitivity = 0.1f;
    [SerializeField] private float minPitch = -35f;
    [SerializeField] private float maxPitch = 70f;
    [SerializeField, Min(0f)] private float cameraSmoothTime = 0.05f;

    private CharacterController characterController;
    private float verticalSpeed;
    private float yaw;
    private float pitch;
    private Vector3 cameraVelocity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        if (playerCamera == null)
        {
            Debug.LogError("ZsAnimal needs a Camera reference or an active camera tagged MainCamera.", this);
            enabled = false;
            return;
        }

        yaw = transform.eulerAngles.y;
        pitch = Mathf.Clamp(NormalizeAngle(playerCamera.transform.eulerAngles.x), minPitch, maxPitch);
        LockCursor();
    }

    private void Update()
    {
        HandleCursor();
        ReadLookInput();
        Move();
    }

    private void LateUpdate()
    {
        if (playerCamera == null)
            return;

        Quaternion orbitRotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 focusPoint = transform.position + Vector3.up * lookHeight;
        Vector3 cameraPosition = focusPoint + Vector3.up * (cameraHeight - lookHeight)
                                 + orbitRotation * Vector3.back * cameraDistance;

        if (cameraSmoothTime <= 0f)
        {
            playerCamera.transform.position = cameraPosition;
        }
        else
        {
            playerCamera.transform.position = Vector3.SmoothDamp(
                playerCamera.transform.position,
                cameraPosition,
                ref cameraVelocity,
                cameraSmoothTime);
        }

        playerCamera.transform.rotation = Quaternion.LookRotation(focusPoint - playerCamera.transform.position);
    }

    private void Move()
    {
        Vector2 input = ReadMoveInput();
        input = Vector2.ClampMagnitude(input, 1f);

        Vector3 forward = Quaternion.Euler(0f, yaw, 0f) * Vector3.forward;
        Vector3 right = Quaternion.Euler(0f, yaw, 0f) * Vector3.right;
        Vector3 moveDirection = forward * input.y + right * input.x;

        if (moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime);
        }

        if (characterController.isGrounded && verticalSpeed < 0f)
            verticalSpeed = -2f;

        verticalSpeed += gravity * Time.deltaTime;
        Vector3 velocity = moveDirection.normalized * (input.magnitude * moveSpeed);
        velocity.y = verticalSpeed;
        characterController.Move(velocity * Time.deltaTime);
    }

    private Vector2 ReadMoveInput()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) input.y += 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) input.y -= 1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) input.x += 1f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) input.x -= 1f;
        }

        if (Gamepad.current != null)
            input += Gamepad.current.leftStick.ReadValue();

        return Vector2.ClampMagnitude(input, 1f);
    }

    private void ReadLookInput()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
            return;

        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            yaw += mouseDelta.x * lookSensitivity;
            pitch -= mouseDelta.y * lookSensitivity;
        }

        if (Gamepad.current != null)
        {
            Vector2 stick = Gamepad.current.rightStick.ReadValue();
            yaw += stick.x * lookSensitivity * 100f * Time.deltaTime;
            pitch -= stick.y * lookSensitivity * 100f * Time.deltaTime;
        }

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    }

    private void HandleCursor()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Cursor.lockState != CursorLockMode.Locked
                 && Mouse.current != null
                 && Mouse.current.leftButton.wasPressedThisFrame)
        {
            LockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private static float NormalizeAngle(float angle)
    {
        return angle > 180f ? angle - 360f : angle;
    }
}
