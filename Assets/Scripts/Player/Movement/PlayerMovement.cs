using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public //

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask Ground;
    public bool grounded;

    [Header("References")]
    public Transform orientation;


    // Private //

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public bool canMove = true;


    /////////////////////////////////////////////////////

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, Ground);// Ground Check

        PlayerInput();

        CapSpeed();

        GroundedDragCalc();

    }

    

    private void FixedUpdate()
    {
        if (canMove)
        {
            MovePlayer();
        }
    }

    ////////////////////////////////////////////////////

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Calculate Movement Direction
        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);

        // Add Force
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }

    private void GroundedDragCalc()
    {
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    private void CapSpeed()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
