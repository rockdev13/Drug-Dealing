using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static event Action<Vector2> OnMoveEvent;
    public static event Action<bool> OnSprintEvent;
    public static event Action<bool> OnCrouchEvent;
    public static event Action OnJumpEvent;
    public static event Action<bool> OnInteractEvent;

    private PlayerInput _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerInput();
    }

    private void OnEnable()
    {
        _inputActions.Enable();

        _inputActions.Player.Move.performed += OnMove;
        _inputActions.Player.Move.canceled += OnMove;

        _inputActions.Player.Sprint.performed += OnSprint;
        _inputActions.Player.Sprint.canceled += OnSprint;

        _inputActions.Player.Crouch.performed += OnCrouch;
        _inputActions.Player.Crouch.canceled += OnCrouch;

        _inputActions.Player.Jump.performed += OnJump;

        _inputActions.Player.Interact.performed += OnInteract;
        _inputActions.Player.Interact.canceled += OnInteract;
    }

    private void OnDisable()
    {
        _inputActions.Disable();

        _inputActions.Player.Move.performed -= OnMove;
        _inputActions.Player.Move.canceled -= OnMove;

        _inputActions.Player.Sprint.performed -= OnSprint;
        _inputActions.Player.Sprint.canceled -= OnSprint;

        _inputActions.Player.Crouch.performed -= OnCrouch;
        _inputActions.Player.Crouch.canceled -= OnCrouch;

        _inputActions.Player.Jump.performed -= OnJump;

        _inputActions.Player.Interact.performed -= OnInteract;
        _inputActions.Player.Interact.canceled -= OnInteract;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        OnSprintEvent?.Invoke(context.performed);
    }

    private void OnCrouch(InputAction.CallbackContext context)
    {
        OnCrouchEvent?.Invoke(context.performed);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        OnJumpEvent?.Invoke();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        OnInteractEvent?.Invoke(context.performed);
    }
}
