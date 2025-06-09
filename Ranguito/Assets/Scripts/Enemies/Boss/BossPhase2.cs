using UnityEngine;

public class BossPhase2 : MonoBehaviour
{
    public int health = 4;
    public int endPhase = 0;

    public GameObject stage2;
    public GameObject stage3;
    public GameObject fixedCamera;
    public GameObject bossPhase3;
    public GameObject[] areaEffectors;

    public GameObject blockSpawner;
    public float fireCooldown = 1.2f;
    public float nextFireTime;
    public float startTime = 12f;
    public bool shouldFire = false;

    public bool shouldMove = false;
    public bool movedDown = false;
    public bool movedLeft = false;
    public bool movedAll = false;
    public int movementSpeed = 8;

    private Animator animator;
    private bool phase2Damage = false;

    private AudioController audioController;
    void Start()
    {
        audioController = GetComponent<AudioController>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !shouldMove)
        {
            TakeDamage();
            collision.GetComponent<PlayerController>().rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }

    public void TakeDamage()
    {
        health--;
        audioController.PlayAudio(0);
        if (health > 2)
        {
            phase2Damage = true;
            if (health == 3)
            {
                shouldMove = true;
            }
        }
    }

    public void MoveToOtherSide()
    {
        if (transform.position == new Vector3(14.5f, -38, 0))
        {
            movedDown = true;
        }

        if (movedDown == false)
        {
            ExecuteMovement(new Vector3(14.5f, -38, 0), movementSpeed);
            return;
        }

        if (transform.position == new Vector3(-14.5f, -38, 0))
        {
            movedLeft = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (movedLeft == false)
        {
            ExecuteMovement(new Vector3(-14.5f, -38, 0), movementSpeed * 4);
            return;
        }

        ExecuteMovement(new Vector3(-14.5f, -26, 0), movementSpeed);

        if (transform.position == new Vector3(-14.5f, -26, 0))
        {
            shouldMove = false;
            movedAll = true;
        }

    }

    public void ExecuteMovement(Vector3 moveTowards, int speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTowards, speed * Time.deltaTime);
    }

    void Update()
    {

        if (shouldMove)
        {
            MoveToOtherSide();
        }
        else
        {
            if (health < 3)
            {
                StartPhase3();
            }

            if (startTime > 0)
            {
                startTime -= Time.deltaTime;
            }
            if (startTime <= 0)
            {
                shouldFire = true;
                foreach (GameObject areaEffector in areaEffectors)
                {
                    areaEffector.SetActive(false);
                }
            }
            if (shouldFire)
            {
                nextFireTime -= Time.deltaTime;
                if (nextFireTime <= 0)
                {
                    blockSpawner.GetComponent<BlockSpawner>().SpawnBlock();
                    nextFireTime = fireCooldown;
                }
            }
        }

        UpdateAnimations();
    }

    public void StartPhase3()
    {
        stage2.SetActive(false);
        stage3.SetActive(true);
        bossPhase3.SetActive(true);
        fixedCamera.GetComponent<FixedCamera>().MoveToPhase3();
        Destroy(gameObject);
    }

    public void UpdateAnimations()
    {
        animator.SetBool("phase2Damage", phase2Damage);
        phase2Damage = false;
    }
}
