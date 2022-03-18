using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    float x;
    float y;
    float xRaw;
    float yRaw;
    [SerializeField] public bool isGrounded = true;
    [SerializeField] private AudioSource jumpSoundFx;
    [SerializeField] private Animator anim;
    private float dirX;
    private bool facingRight = true;
    private BoxCollider2D boxCollider2d;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    // Better Jumps
    public float fallMultiplier = 6f;
    public float lowJumpMultiplier = 4f;

    // Double Jump
    public float subJumpMultiplier = 0.8f;
    public int playerJumps = 2;
    public int tempPlayerJumps;

    // // Dashing
    // public float dashingVelocity = 14f;
    // public float dashingTime = 0.5f;
    // private Vector2 dashingDir;
    // private bool isDashing;
    // private bool canDash = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 8f;
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            anim.SetBool("isFalling", false);
        }
        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");

        //Check if moving to right
        if (xRaw > 0 && !facingRight)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        //Check if moving to left
        if (xRaw < 0 && facingRight)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }

        //Check if running
        dirX = xRaw * speed;

        if (Mathf.Abs(dirX) > 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump") && tempPlayerJumps > 0)
        {
            anim.SetBool("isJumping", true);
            jumpSoundFx.Play();
            Jump(Vector2.up);
        }

        //Better Jump Feel
        if (rb.velocity.y < 0) // Triggered right after reaching max height
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        else if (tempPlayerJumps == playerJumps && rb.velocity.y > 0 && !Input.GetButton("Jump")) // If going up, but jump is not pressed
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        // if (Input.GetKeyDown(KeyCode.B) && canDash) {
        //     isDashing = true;
        //     canDash = false;
        //     //  dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //      dashingDir = new Vector2(xRaw, yRaw);

        //     if (dashingDir == Vector2.zero) {
        //         dashingDir = new Vector2(transform.localScale.x , 0);
        //     }
        //     StartCoroutine(StopDashing());
        // }

        // if (isDashing) {

        //     rb.velocity = dashingDir.normalized * dashingVelocity;
        //     return;
        // }

        // if (isGrounded) {
        //     canDash = true;
        // }
    }

    private void FixedUpdate()
    {
        groundCheck();
        Vector2 dir = new Vector2(xRaw, yRaw);
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }
    // private IEnumerator StopDashing() {
    //     yield return new WaitForSeconds(dashingTime);
    //     isDashing = false;
    // }

    void groundCheck() {
        isGrounded = false; 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.2f, groundLayer);
        if (colliders.Length > 0) {
            isGrounded = true;
            tempPlayerJumps = playerJumps;
        }
    }

    IEnumerator myWaitCoroutine()
    {
        yield return new WaitForSeconds(0.05f);
        tempPlayerJumps--;
    }

    void Jump(Vector2 jumpDir)
    {
        StartCoroutine(myWaitCoroutine());

        // Set y velocity to 0 first
        rb.velocity = new Vector2(rb.velocity.x, 0);
        if (tempPlayerJumps == playerJumps)
        {
            rb.velocity += jumpDir * jumpForce;
        }
        else
        {
            rb.velocity += jumpDir * jumpForce * subJumpMultiplier;
        }
        
    }
}

