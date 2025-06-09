using UnityEngine;

public class Boss : MonoBehaviour
{

    public int health = 8;
    public int endPhase = 0;

    public GameObject stage1;
    public GameObject fixedCamera;
    public GameObject bossPhase2;

    private int attacksUntilHeart;
    private int heartCooldown;
    public bool heartOut = false;

    public GameObject poisonPrefab;
    public GameObject heartPrefab;
    public float fireCooldown = 1.2f;
    public float nextFireTime;

    private Animator animator;
    private bool isSpitting = false;
    private bool phase1Damage = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        nextFireTime = fireCooldown;
        heartCooldown = Random.Range(5, 8);
        attacksUntilHeart = heartCooldown;
    }

    void Update()
    {
        if (health < 5 && endPhase == 0)
        {
            StartPhase2();
        }

        if (endPhase == 0)
        {
            PhaseOne();
        }

        UpdateAnimations();
    }

    public void TakeDamage()
    {
        health--;

        if (endPhase == 0)
        {
            phase1Damage = true;
        }
    }

    public void PhaseOne()
    {
        nextFireTime -= Time.deltaTime;

        if (nextFireTime <= 0)
        {
            if (attacksUntilHeart > 0)
            {
                PoisonAttack();
                PoisonAttack();
                PoisonAttack();
                attacksUntilHeart--;
            }
            else
            {
                if (heartOut)
                {
                    attacksUntilHeart = heartCooldown;
                }
                else
                {
                    SpitHeart();
                    heartOut = true;
                    attacksUntilHeart = heartCooldown;
                }
            }
            nextFireTime = fireCooldown;
        }
    }

    public void PoisonAttack()
    {
        isSpitting = true;
        GameObject poison = Instantiate(poisonPrefab, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
        Rigidbody2D rb = poison.GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(Random.Range(-15, -5), Random.Range(10, 25)), ForceMode2D.Impulse);
    }

    public void SpitHeart()
    {
        isSpitting = true;
        GameObject heart = Instantiate(heartPrefab, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
        Rigidbody2D rb = heart.GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(Random.Range(-15, -5), Random.Range(10, 25)), ForceMode2D.Impulse);
    }

    public void StartPhase2()
    {
        stage1.SetActive(false);
        bossPhase2.SetActive(true);
        fixedCamera.GetComponent<FixedCamera>().MoveToPhase2();
        Destroy(gameObject);
    }

    public void UpdateAnimations()
    {
        animator.SetBool("IsSpitting", isSpitting);
        animator.SetBool("Phase1Damage", phase1Damage);

        isSpitting = false;
        phase1Damage = false;
    }
}
