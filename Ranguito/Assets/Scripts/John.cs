using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
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


    public bool playerColor = false; // False is Green, True is Magenta

    [SerializeField] private Vector2 jumpGizmo;
    [SerializeField] private Vector2 groundCollisionBox;
    [SerializeField] private float groundCollisionAngle;
    public LayerMask layer;

    void Start()
    {
        //Initialize components
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        layer = LayerMask.GetMask("Ground");
    }
    void Update()
    {
        HandleInput();
        UpdateCooldowns();
    }
    void FixedUpdate()
    {
        GroundDetection();
        HandleMovement();
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ChangeColor();
        }

        /*if (Input.GetKeyDown(KeyCode.E) && !isEating)
        {
            StartCoroutine(Eat());
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump)
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

    public void ChangeColor()
    {
        if (playerColor is true)
        {
            playerColor = false;
        }
        else if (playerColor is false)
        {
            playerColor = true;
        }

    }

    /*System.Collections.IEnumerator Eat()
    {
        isEating = true;
        yield return new WaitForSeconds(1f);
        isEating = false;
    }*/


    private void GroundDetection()
    {
        isGrounded = Physics2D.OverlapBox((Vector2)transform.position + jumpGizmo, groundCollisionBox, groundCollisionAngle, layer);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube((Vector2)transform.position + jumpGizmo, groundCollisionBox);
    }

    void UpdateAnimations()
    {
        animator.SetBool("IsWalking", Mathf.Abs(rb.linearVelocity.x) > 0.1f && isGrounded);
        animator.SetBool("IsJumping", !isGrounded);
        animator.SetBool("IsDoubleJumping", isDoubleJumping);
        animator.SetBool("playerColor", playerColor);
        //animator.SetBool("IsEating", isEating);

    }
    void LateUpdate()
    {
        UpdateAnimations();
    }
}