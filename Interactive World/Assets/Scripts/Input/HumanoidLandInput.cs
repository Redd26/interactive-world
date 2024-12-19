using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanoidLandInput : MonoBehaviour
{
    public Vector2 MoveInput {get; private set;} = Vector2.zero;
    public bool moveIsPressed;
    
    public Vector2 LookInput {get; private set;} = Vector2.zero;
    
    InputActions _input;

    private void OnEnable()
    {
        _input = new InputActions();
        _input.HumanoidLand.Enable();

        _input.HumanoidLand.Move.performed += SetMove; // Triggered always the gamepad or keyboard move actions values are above the thresold
        _input.HumanoidLand.Move.canceled += SetMove; // Triggered always the gamepad or keyboard move actions values are below the thresold
        
        _input.HumanoidLand.Look.performed += SetLook;
        _input.HumanoidLand.Look.canceled += SetLook;
    }

    private void OnDisable()
    {
        _input.HumanoidLand.Move.performed -= SetMove;
        _input.HumanoidLand.Move.canceled -= SetMove;
        
        _input.HumanoidLand.Look.performed -= SetLook;
        _input.HumanoidLand.Look.canceled -= SetLook;
        
        _input.HumanoidLand.Disable();
    }
    
    private void SetMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
        moveIsPressed = true;
    }
    
    private void SetLook(InputAction.CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>(); 
        moveIsPressed = false;
    }
}
