using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    public static int health = 3;
    public int damageCooldown = 2;

    public Rigidbody2D rb;
    private Animator animator;
    private AudioController audioController;
    [SerializeField]private bool isGrounded = true;
    //private bool isEating = false;
    [SerializeField] private bool canDoubleJump = true;
    [SerializeField] private bool isDoubleJumping = false;


    public bool playerColor = false; // False is Green, True is Magenta

    [SerializeField] private Vector2 jumpGizmo;
    [SerializeField] private Vector2 groundCollisionBox;
    [SerializeField] private float groundCollisionAngle;
    public LayerMask groundLayer;

    void Start()
    {
        //Initialize components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioController = GetComponent<AudioController>();
        groundLayer = LayerMask.GetMask("Ground");
    }
    void Update()
    {
        HandleInput();
        UpdateCooldowns();
    }
    void FixedUpdate()
    {
        GroundDetection();
        if (isGrounded)
        {
            isDoubleJumping = false;
            canDoubleJump = true;
        }
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isGrounded)
            {
                Jump();
                audioController.PlayAudio(1);
            }
            else if (canDoubleJump)
            {
                isDoubleJumping = true;
                Jump();
                audioController.PlayAudio(2);
                canDoubleJump = false;
            }
        }
    }

    public void TakeDamage()
    {
        health--;
        audioController.PlayAudio(0);
        ScoringManager.hits++;

        if (health == 0)
        { 
            if(SceneManager.GetActiveScene().name == "NIVEL")
            {
                ScoringManager.hits = 0;
                SceneManager.LoadScene("MenuPrincipal");
            }
            if(SceneManager.GetActiveScene().name == "lv1-2_boss")
            {
                health = 3;
                ScoringManager.timeBossDeaths += Time.timeSinceLevelLoad;
                SceneManager.LoadScene("lv1-2_boss");
            }
            
        }
    }

    public void Heal(int heal)
    {
        health += heal;

        if (health > 3)
        {
            health = 3;
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
        isGrounded = Physics2D.OverlapBox((Vector2)transform.position + jumpGizmo, groundCollisionBox, groundCollisionAngle, groundLayer);
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
        animator.SetBool("IsDoubleJumping", isDoubleJumping && !isGrounded);
        animator.SetBool("playerColor", playerColor);
        //animator.SetBool("IsEating", isEating);

    }
    void LateUpdate()
    {
        UpdateAnimations();
    }
}