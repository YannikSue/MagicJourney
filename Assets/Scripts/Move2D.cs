using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{

    public Animator animator;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public float jumpForce = 10f;
    public float dashSpeed = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Transform startingPoint;
    private Rigidbody2D rb;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (startingPoint != null)
        {
            transform.position = startingPoint.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(groundCheck.position.x, groundCheck.position.y), new Vector2(groundCheck.position.x + 0.5f, groundCheck.position.y - 0.51f), groundLayer);
        Jump();
        Dash();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
        {
            //animator.SetFloat("Speed", moveSpeed);
            Flip();
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
        {
            //animator.SetFloat("Speed", moveSpeed);
            Flip();


        }
        transform.position += movement * Time.deltaTime * moveSpeed;


    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (facingRight)
                rb.AddForce(new Vector2(dashSpeed, 0f), ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(-dashSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
