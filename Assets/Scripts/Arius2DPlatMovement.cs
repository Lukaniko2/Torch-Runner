using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arius2DPlatMovement : MonoBehaviour
{
    public float movementSpeed;//speed player moves at
    public float sprintSpeed; //how much faster player goes
    public float jumpForce = 10;//force player jumps at 
    public Transform groundcheck; //gets the ground checks positions
    public float checkRadius; //it creates(radius) a circle at the bottom of players foot
    public LayerMask whatIsGround; //ground layers
    public int extraJumpValue; //extra value
    public bool running; //see if player is running
    public AudioSource JumpAudio;


    private int extraJumps; //number of jumps player has left
    private float moveInputX; //gets raw axis x

    private Rigidbody2D rb;//rigid bod
    private Animator animator;
    private SpriteRenderer renderer2D;
    private bool isGrounded; //bool that is true when ground is touched
    public static bool isFlipped; //checks to see if the player is flipped so we know when to flip the particles


    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer2D = GetComponent<SpriteRenderer>();

        extraJumps = extraJumpValue;
    }

    // Update is called once per frame
    void Update()
    {
        moveInputX = Input.GetAxisRaw("Horizontal"); //Gets direction x

        ////animation state
        if (moveInputX != 0 && isGrounded) //right / left
        {
            if (moveInputX == -1) //if player going opposite direction, flip
            {
                renderer2D.flipX = moveInputX > 0;
                isFlipped = true;
            }
            else
            {
                isFlipped = false;
            }

            if(running) //if running, play this animState
            {
                animator.SetInteger("animState", 3);
            }
            else //if not running, play this animState
            {
                animator.SetInteger("animState", 1);
            }

            renderer2D.flipX = moveInputX < 0;
        }
        else if(isGrounded)
        {
            animator.SetInteger("animState", 0);
        }
        else if (!isGrounded)
        {
            animator.SetInteger("animState", 2);
        }

        Jump();
    }

    void Jump()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpValue;

        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
 
            extraJumps--;
            JumpAudio.Play();
            
        }
    }

  
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);
        rb.velocity = new Vector2(moveInputX * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        Sprint();
    }

    void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
            rb.velocity = new Vector2(moveInputX * sprintSpeed * Time.fixedDeltaTime, rb.velocity.y);

        }
        else
        {
            running = false;
        }
    }
}
