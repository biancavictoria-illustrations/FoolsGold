// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// modified version of the gamekit
/// handles player movement and input for movement
/// </summary>
public class Movement : MonoBehaviour
{

    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpSpeed = 5f;
    [SerializeField] public float moveAcceleration;
    [SerializeField] public float moveTopSpeed;
    
    /// <summary>
    /// assuming that minspeed is starting speed for now
    /// </summary>
    private float moveMinSpeed; 
    
    [SerializeField] public bool isAutoRunning = false;
    [SerializeField] public bool isActiveBool = false;
    [SerializeField] Rigidbody2D myRigidBody;

    private Vector2 moveDirection;
    private SpriteRenderer mySpriteRenderer;


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

        moveMinSpeed = moveSpeed; 
    }

    void Update()
    {
        ProcessInputs();
        HandleAcceleration();
        Jump();
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
        moveSpeed = Mathf.Clamp(moveSpeed, moveMinSpeed, moveTopSpeed);
    }

    private void Jump()
    {
        if (!isActiveBool) { return; }

        if (!myRigidBody.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    
}
