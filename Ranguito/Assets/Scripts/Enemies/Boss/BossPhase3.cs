using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPhase3 : MonoBehaviour
{
    public int health = 2;
    public bool dying = false;

    public GameObject bonePrefab;
    public float boneRate;
    public float nextBoneTime = 0f;
    public float boneSpeed = 5f;
    public Transform player;

    public GameObject fallingBonePrefab;

    public float spikeFallTime = 1.2f;
    public float nextSpikeFallTime;

    public GameObject poisonPrefab;
    public float poisonCooldown = 8f;
    public float nextPoisonTime;

    public float nextFallingBones = 7f;
    public float fallingBonesCooldown = 3f;

    public GameObject RedSpike1;
    public GameObject RedSpike2;

    private Animator animator;
    private bool isDamaged = false;
    private bool isAttacking = false;

    private float endTime = 8f;

    private bool shouldFire;
    public float startTime = 6f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (startTime > 0)
        {
            startTime -= Time.deltaTime;
        }
        if (startTime <= 0)
        {
            shouldFire = true;
        }
        if (shouldFire)
        {

            if (!dying)
            {
                nextSpikeFallTime -= Time.deltaTime;
                nextPoisonTime -= Time.deltaTime;
                nextFallingBones -= Time.deltaTime;

                if (nextSpikeFallTime <= 0)
                {
                    if (RedSpike1 != null)
                    {
                        RedSpike1.GetComponent<Rigidbody2D>().gravityScale = 2;
                    }
                    else
                    {
                        RedSpike2.GetComponent<Rigidbody2D>().gravityScale = 2;
                    }
                    nextSpikeFallTime = spikeFallTime;
                }

                if (nextPoisonTime <= 0)
                {
                    PoisonAttack();
                    PoisonAttack();
                    PoisonAttack();
                    nextPoisonTime = poisonCooldown;
                }

                if (nextFallingBones <= 0)
                {
                    FallingBones();
                    nextFallingBones = fallingBonesCooldown;
                }


                //Bone Attack
                if (Time.time >= nextBoneTime)
                {
                    Vector2 directionToPlayer = player.position - transform.position;
                    ThrowBone(directionToPlayer.normalized);
                    nextBoneTime = Time.time + 1f / boneRate;
                }
                UpdateAnimations();
            }
            else
            {
                endTime -= Time.deltaTime;
                Death();

                if (endTime <= 0)
                {
                    EndGame();
                }
            }
        }
    }

    public void FallingBones()
    {
        GameObject fallingBone1 = Instantiate(fallingBonePrefab, new Vector3(-16f, -35f, -0f), Quaternion.identity);
        GameObject fallingBone2 = Instantiate(fallingBonePrefab, new Vector3(-12f, -35f, -0f), Quaternion.identity);
        GameObject fallingBone3 = Instantiate(fallingBonePrefab, new Vector3(-8f, -35f, -0f), Quaternion.identity);
        GameObject fallingBone4 = Instantiate(fallingBonePrefab, new Vector3(-4f, -35f, -0f), Quaternion.identity);
        GameObject fallingBone5 = Instantiate(fallingBonePrefab, new Vector3(0f, -35f, -0f), Quaternion.identity);
        GameObject fallingBone6 = Instantiate(fallingBonePrefab, new Vector3(4f, -35f, -0f), Quaternion.identity);
        GameObject fallingBone7 = Instantiate(fallingBonePrefab, new Vector3(8f, -35f, -0f), Quaternion.identity);
    }

    private void ThrowBone(Vector2 direction)
    {
        GameObject bullet = Instantiate(bonePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * boneSpeed;
    }

    public void PoisonAttack()
    {
        isAttacking = true;
        GameObject poison = Instantiate(poisonPrefab, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
        poison.GetComponent<BossCheck>().phase = BossCheck.Phase.Three;
        Rigidbody2D rb = poison.GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(Random.Range(-15, -5), Random.Range(10, 25)), ForceMode2D.Impulse);
    }

    public void TakeDamage()
    {
        health--;
        isDamaged = true;
        if (health <= 0)
        {
            dying = true;
            Death();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("victory");
    }

    private void Death()
    {
        isDamaged = true;

        if (transform.position != new Vector3(13.5f, -55, 0))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(13.5f, -55, 0), 5 * Time.deltaTime);
        }
        UpdateAnimations();
    }



    public void UpdateAnimations()
    {
        animator.SetBool("isDamaged", isDamaged);
        animator.SetBool("isAttacking", isAttacking);
        isAttacking = false;
        isDamaged = false;
    }
}
