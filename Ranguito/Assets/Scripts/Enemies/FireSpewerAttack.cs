using UnityEngine;

public class FireSpewerAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireCooldown = 1.2f;
    public float nextFireTime = 0f;
    public float bulletSpeed = 4f;
    public bool facingLeft;
    private Animator animator;
    private bool attacking;
    private float attackingAnimationTimer;
    private float attackingAnimationCooldown = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        nextFireTime = fireCooldown;
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        nextFireTime -= Time.deltaTime;

        if(attackingAnimationTimer > 0)
        {
            attackingAnimationTimer -= Time.deltaTime;
        }

        if(attacking == true && attackingAnimationTimer <= 0)
        {
            attacking = false;
        }

        if(nextFireTime <= 0)
        {
            Attack();
            attacking = true;
            attackingAnimationTimer = attackingAnimationCooldown;
        }
        
        UpdateAnimations();
    }

    public void Attack()
    {
        GameObject bullet = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (facingLeft)
        {
            rb.linearVelocity = Vector2.left * bulletSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.right * bulletSpeed;
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        nextFireTime = fireCooldown;
    }

    public void UpdateAnimations()
    {
        animator.SetBool("Attacking", attacking);
    }
}
