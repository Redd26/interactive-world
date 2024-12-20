using System;
using UnityEngine;

public class HumanoidLandController : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] private HumanoidLandInput input;

    private Vector3 _playerMoveInput;
    
    [Header("Movement")]
    [SerializeField] private float movementMultiplier = 30f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _playerMoveInput = GetMoveInput();
        PlayerMove();
        
        _rigidbody.AddRelativeForce(_playerMoveInput, ForceMode.Force);
    }

    private Vector3 GetMoveInput()
    {
        return new Vector3(x: input.MoveInput.x, y: 0f, z: input.MoveInput.y);   
    }

    private void PlayerMove()
    {
        _playerMoveInput = new Vector3(_playerMoveInput.x * movementMultiplier * _rigidbody.mass,
                                        _playerMoveInput.y,
                                        _playerMoveInput.z * movementMultiplier * _rigidbody.mass);
    }
}
