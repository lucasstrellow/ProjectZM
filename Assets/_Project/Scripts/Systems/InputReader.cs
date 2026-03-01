using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameInput;

public class InputReader : MonoBehaviour, IPlayerActions
{
    private GameInput _gameInput;

    public event Action OnAttackEvent;
    public event Action<float> OnMoveEvent;
    public event Action OnJumpEvent;
    public event Action<bool> OnCrouchEvent;
    public event Action OnInteractEvent;
    public event Action OnPauseEvent;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Player.SetCallbacks(this);
        }

        EnablePlayerInput();
    }

    private void OnDisable()
    {
        DisableAllInput();
    }
    public void EnablePlayerInput()
    {
        _gameInput.Player.Enable();
        _gameInput.UI.Disable();
    }

    public void EnableUIInput()
    {
        _gameInput.Player.Disable();
        _gameInput.UI.Enable();
    }

    public void DisableAllInput()
    {
        _gameInput.Player.Disable();
        _gameInput.UI.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnAttackEvent?.Invoke();
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnCrouchEvent?.Invoke(true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            OnCrouchEvent?.Invoke(false);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnInteractEvent?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnJumpEvent?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnPauseEvent?.Invoke();
        }
    }
}
