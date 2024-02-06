using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputControls input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;

    private void Awake()
    {
        input = new InputControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Movement_canceled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    private void Movement_performed(InputAction.CallbackContext value)
    {
        
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += Movement_performed;
        input.Player.Movement.canceled += Movement_canceled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= Movement_performed;
        input.Player.Movement.canceled -= Movement_canceled;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * 2.5f;
    }

}
