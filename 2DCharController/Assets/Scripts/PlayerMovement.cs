using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    float horizontal;
    private bool isFacingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJump = 2;
    private int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        Debug.Log(isGrounded);

        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if((!isFacingRight && horizontal > 0) || (isFacingRight && horizontal < 0))
        {
            Flip();
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && jumpCount < extraJump)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpCount++;
            Debug.Log(extraJump);
        }
        if(jumpCount >= extraJump && isGrounded)
        {
            jumpCount = 0;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 Scalar = transform.localScale;
        Scalar.x *= -1;
        transform.localScale = Scalar;
    }
}
