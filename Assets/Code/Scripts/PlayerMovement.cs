using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputControls input = null;
    public Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;
    
    [SerializeField]
    private float moveSpeed = 2.0f;


    private void Awake()
    {
        input = new InputControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += input_received;
        input.Player.Movement.canceled += input_cancel;
    }

    private void OnDisable()
    {
        input.Player.Movement.performed -= input_received;
        input.Player.Movement.canceled -= input_cancel;
        input.Disable();
    }
    private void input_cancel(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    private void input_received(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }
}
