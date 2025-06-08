using UnityEngine;

public class BossPhase3 : MonoBehaviour
{
    public int health = 2;
    public bool dying = false;

    public GameObject bonePrefab;
    public float boneRate;
    public float nextBoneTime = 0f;
    public float boneSpeed = 5f;
    public Transform player;

    public float spikeFallTime = 1.2f;
    public float nextSpikeFallTime;

    public GameObject RedSpike1;
    public GameObject RedSpike2;

    void Start()
    {

    }

    void Update()
    {
        if (!dying)
        {
            nextSpikeFallTime -= Time.deltaTime;
            if(nextSpikeFallTime <= 0)
            {
                if(RedSpike1 != null)
                {
                    RedSpike1.GetComponent<Rigidbody2D>().gravityScale = 2;
                }
                else
                {
                    RedSpike2.GetComponent<Rigidbody2D>().gravityScale = 2;
                }
                nextSpikeFallTime = spikeFallTime;
            }
            

            //Bone Attack
            if (Time.time >= nextBoneTime)
            {
                Vector2 directionToPlayer = player.position - transform.position;
                ThrowBone(directionToPlayer.normalized);
                nextBoneTime = Time.time + 1f / boneRate;
            }
        }
    }

    private void ThrowBone(Vector2 direction)
    {
        GameObject bullet = Instantiate(bonePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * boneSpeed;
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            dying = true;
            Death();
        }
    }

    private void Death()
    {

    }
}
