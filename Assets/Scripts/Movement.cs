// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// modified version of the gamekit
/// handles player movement and movement input delay 
/// </summary>
public class Movement : MonoBehaviour
{

 
    
    [Header("Movement Values")]
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpSpeed = 5f;
    /// <summary>
    /// seconds player character waits before actually jumping 
    /// </summary>
    public float jumpDelay = 0;
    [SerializeField] public float moveAcceleration;


    [Header("Movement Clamping")] 
    public float moveMinSpeed;
    public float jumpMinSpeed;
    public float moveTopSpeed;
    public float jumpTopSpeed; 
    
    [Header("Misc")]
    [SerializeField] public bool isAutoRunning = false;
    [SerializeField] public bool isActiveBool = false;
    [SerializeField] Rigidbody2D myRigidBody;
    /// <summary>
    /// The length of the groundcheck raycast the extends down from the player position. 
    /// </summary>
    public float groundCheckLength;
    
    
    private Vector2 moveDirection;
    private SpriteRenderer mySpriteRenderer;
    public Animator animator;


    #region  Public Functions

    /// <summary>
    /// instantly sets the player's speed to the slowest value. 
    /// </summary>
    public void SlowToSlowestSpeed()
    {
        moveSpeed = moveMinSpeed; 
    }

    #endregion
    
    #region  Unity Callbacks
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ProcessInputs();
        HandleAcceleration();
        DetectJumpInput();
        
        //clamp move and jump speeds 
        moveSpeed = Mathf.Clamp(moveSpeed, moveMinSpeed, moveTopSpeed);
        jumpSpeed = Mathf.Clamp(jumpSpeed, jumpMinSpeed, jumpTopSpeed);
    }

    private void FixedUpdate()
    {
        playerMovement();
    }
    

    #endregion


    private void ProcessInputs()
    {
        if (!isActiveBool) { return; }

        float moveX = Input.GetAxisRaw("Horizontal");
        
        moveDirection = new Vector2(moveX, myRigidBody.velocity.y);
    }

    private void playerMovement()
    {
        if (!isActiveBool) { return; }

        if (isAutoRunning)
        {
            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        
        }
        else
        {
            myRigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, myRigidBody.velocity.y);
        }

    }

    /// <summary>
    /// adds moveAcceleration to moveSpeed every second until topSpeed is reached
    /// </summary>
    private void HandleAcceleration()
    {
        moveSpeed += moveAcceleration * Time.deltaTime; 
    //    moveSpeed = Mathf.Clamp(moveSpeed, moveMinSpeed, moveTopSpeed);
    }

    private void DetectJumpInput()
    {
        if (!isActiveBool) { return; }

        //draw raycast for debugging
        Debug.DrawRay(transform.position, Vector3.down * groundCheckLength);

        if (!isGrounded())
        {
            //print("Not grounded");
            if (GetComponent<Rigidbody2D>().velocity.y > 0.001)
            {
                animator.SetBool("Jumping", true);
                animator.SetBool("Landing", false);
            }
            else { 
                animator.SetBool("Jumping", false);
                animator.SetBool("Landing", true);
            }
            return;
        }

        if (isGrounded())
        {
            print("Grounded");
            animator.SetBool("Jumping", false);
            animator.SetBool("Landing", false);

        }

        if (Input.GetButtonDown("Jump"))
        {
            if(jumpDelay > 0)
                print("JUMP DETECTED. Jumping in " + jumpDelay + "...");
            Invoke(nameof(Jump), jumpDelay);

        }
    }

    /// <summary>
    /// makes the player jump if they're touching ground 
    /// </summary>
    private void Jump()
    {
        //check ground again in case there is a jump delay 
        if (!isGrounded())
        {
            return;
        }
        
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        myRigidBody.velocity += jumpVelocityToAdd;
        //print(myRigidBody.velocity);
    }

    bool isGrounded()
    {  
        return Physics2D.Raycast(transform.position, Vector3.down, groundCheckLength,
            LayerMask.GetMask("Foreground"));
    }

    
}
