using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public Color[] availableColors;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isGrounded = true;
    private bool isEating = false;
    private bool isChangingColor = false;
    private float colorChangeCooldown = 0f;
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.W) && colorChangeCooldown <= 0f)
        {
            StartCoroutine(ChangeColor());
        }
        if (Input.GetKeyDown(KeyCode.E) && !isEating)
        {
            StartCoroutine(Eat());
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    void HandleMovement()
    {
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A)) moveInput = -1f;
        if (Input.GetKey(KeyCode.D)) moveInput = 1f;
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
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
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
    }
    void UpdateCooldowns()
    {
        if (colorChangeCooldown > 0f)
        {
            colorChangeCooldown -= Time.deltaTime;
        }
    }
    System.Collections.IEnumerator ChangeColor()
    {
        isChangingColor = true;
        if (availableColors.Length > 0)
        {
            Color newColor = availableColors[Random.Range(0, availableColors.Length)];
            spriteRenderer.color = newColor;
        }
        yield return new WaitForSeconds(0.5f);
        isChangingColor = false;
        colorChangeCooldown = 1f;
    }
    System.Collections.IEnumerator Eat()
    {
        isEating = true;
        yield return new WaitForSeconds(1f);
        isEating = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
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
        animator.SetBool("IsWalking", Mathf.Abs(rb.velocity.x) > 0.1f && isGrounded);
        animator.SetBool("IsJumping", !isGrounded);
        animator.SetBool("IsEating", isEating);
        animator.SetBool("IsChangingColor", isChangingColor);
    }
    void LateUpdate()
    {
        UpdateAnimations();
    }
}