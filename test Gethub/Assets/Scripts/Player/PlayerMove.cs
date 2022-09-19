using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player stings")]
    public float WalkSpeed = 4;
    public float SprintSpeed = 7;
    public float jumpForce = 6;
    public float jumpCooldown = 0.1f;
    public float airMultiplier = 0.1f;
    public float groundDrag = 5;
    public float airDrag = 0.5f; 
    

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode SprintKey = KeyCode.LeftShift;
    

    [Header("Other")]
    public LayerMask whatIsGround;
    public Transform orientation;
    

    //private 
    float Speed;
    float MovmendSpeed;
    float horizontalInput;
    float verticalInput;    
    Vector3 moveDirection;
    Rigidbody rb;
    Vector3 lastPosition;
    bool grounded;
    bool readyToJump = true;

    

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;     
    }

    void Update()
    {
        MyInput();
        SpeedCalculator();


        //Ground Check 
        grounded =      
            Physics
                .Raycast(transform.position,
                Vector3.down,
                1.2f,
                whatIsGround);


        // Aply Drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else if (!grounded)
        {
            rb.drag = airDrag;
        }
    }

    void FixedUpdate()
    {
        if (grounded)PlayerMovement();
    }

   private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(SprintKey))
        {
            MovmendSpeed = SprintSpeed;
        }
        else {MovmendSpeed = WalkSpeed;}


        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            Jump();
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void PlayerMovement()
    {
        moveDirection = orientation.forward *verticalInput  +horizontalInput  * orientation.right;
    
        if (grounded) 
        {
            rb
                .AddForce(moveDirection.normalized * MovmendSpeed * 10,
                ForceMode.Force);
        }
        else if (!grounded)
        {
            rb
                .AddForce(moveDirection.normalized *
                MovmendSpeed *
                10 *
                airMultiplier,
                ForceMode.Force);
        }
    }

    void SpeedCalculator() 
    {   
        
        Speed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform. position;
    }

    void Jump()
    {
        //rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
    


}
