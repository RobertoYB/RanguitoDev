using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isGrounded = true;
    //private bool isEating = false;
    private bool canDoubleJump = false;
    private bool isDoubleJumping = false;

    private bool isChangingColor = false; //Might not be necessary.

    //TODO: Add a boolean to check the character's color.

    void Start()
    {
        //Initialize components
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        HandleInput();
        UpdateCooldowns();
    }
    void FixedUpdate()
    {
        HandleMovement();
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(ChangeColor());
        }

        /*if (Input.GetKeyDown(KeyCode.E) && !isEating)
        {
            StartCoroutine(Eat());
        }
        */

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isGrounded)
            {
                Jump();
            } else if (canDoubleJump)
            {
                isDoubleJumping = true;
                Jump();
                canDoubleJump = false;
            }
        }
    }
    void HandleMovement()
    {
        //Change sign depending on input (left or right)
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1f;

        //Move
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //Flip character sprite depending on input (left or right)
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
        rb.linearVelocity += Vector2.up * jumpForce;
        isGrounded = false;
    }
    void UpdateCooldowns()
    {
        
    }

    //TODO: Should be instantaneous.
    System.Collections.IEnumerator ChangeColor()
    {
        isChangingColor = true;
        yield return new WaitForSeconds(0.5f);
        isChangingColor = false;
    }

    /*System.Collections.IEnumerator Eat()
    {
        isEating = true;
        yield return new WaitForSeconds(1f);
        isEating = false;
    }*/


    //Ground detection
    //TODO: Since it uses its collision with objects tagged as "Ground" to determine
    //whether it's grounded, this will complicate the implementation of walls, since
    //we'll need to differentiate them as otherwise the character won't be able to
    //jump while touching them. It might be best to use gizmos.
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = true;
            isDoubleJumping = false;
        }
        
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void UpdateAnimations()
    {
        animator.SetBool("IsWalking", Mathf.Abs(rb.linearVelocity.x) > 0.1f && isGrounded);
        animator.SetBool("IsJumping", !isGrounded);
        animator.SetBool("IsDoubleJumping", !isDoubleJumping);
        //animator.SetBool("IsEating", isEating);
        animator.SetBool("IsChangingColor", isChangingColor);
    }
    void LateUpdate()
    {
        UpdateAnimations();
    }
}