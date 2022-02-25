using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    public float jumpForce = 25f;
    private Rigidbody2D rb;
    float x;
    float y;
    float xRaw;
    float yRaw;
    bool isGrounded = true;

    // Better Jumps
    public float fallMultiplier;
    public float lowJumpMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(Vector2.up);
            isGrounded = false;
        }

        //Better Jump Feel
        if (rb.velocity.y < 0) // Triggered right after reaching max height
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // If going up, but jump is not pressed
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 dir = new Vector2(xRaw, yRaw);
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        Debug.Log(Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void Jump(Vector2 jumpDir)
    {
        // Set y velocity to 0 first
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += jumpDir * jumpForce;
    }
}
