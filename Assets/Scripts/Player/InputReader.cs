using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    private bool _isJump;

    public event Action<float> Moving;

    public float Direction {  get; private set; }

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();

        _inputActions.Enable();
        _inputActions.Player.Jump.performed += JumpPerformed;
    }

    private void Update()
    {
        Vector2 move = _inputActions.Player.Move.ReadValue<Vector2>();
        Direction = move.x;

        Moving?.Invoke(Direction);
    }    

    private void OnDisable()
    {
        _inputActions.Player.Jump.performed -= JumpPerformed;
        _inputActions.Disable();
    }

    public bool GetIsJump()
    {
        bool result = _isJump;
        _isJump = false;

        return result;
    }

    private void JumpPerformed(InputAction.CallbackContext context)
    {
        _isJump = true;
    }    
}