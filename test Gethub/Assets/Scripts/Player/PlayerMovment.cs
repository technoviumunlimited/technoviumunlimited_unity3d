using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Movment Speed")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;

    public float jumpCooldown;

    public float airMultiplier;

    bool readyToJump;

    [Header("Keybinds Jump")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;

    public LayerMask whatIsGround;

    public bool grounded;

    public Transform orientation;

    float horizontalInput;

    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        MyInput();
        SpeedControle();
        grounded =
            Physics
                .Raycast(transform.position,
                Vector3.down,
                playerHeight * 0.5f + 0.2f,
                whatIsGround);

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            Jump();
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void PlayerMovement()
    {
        moveDirection =
            orientation.forward * verticalInput +
            orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);

        if (grounded)
        {
            rb
                .AddForce(moveDirection.normalized * moveSpeed * 10,
                ForceMode.Force);
        }
        else if (!grounded)
        {
            rb
                .AddForce(moveDirection.normalized *
                moveSpeed *
                10 *
                airMultiplier,
                ForceMode.Force);
        }
    }

    void SpeedControle()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.y);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity =
                new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
