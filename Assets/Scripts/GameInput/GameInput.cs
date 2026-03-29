using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private PlayerInputActions _playerInputActions;

    public event EventHandler OnStartedQ;
    public event EventHandler OnStartedW;

    private void Awake()
    {
        Instance = this;

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();

        _playerInputActions.Player.Q.started += PlayerInputActions_startedQ;
        _playerInputActions.Player.W.started += PlayerInputActions_startedW;
    }

    public Vector2 GetMovementVector()
    {
        
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }

    private void PlayerInputActions_startedQ(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnStartedQ?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerInputActions_startedW(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnStartedW?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Q.started -= PlayerInputActions_startedQ;
    }
}
