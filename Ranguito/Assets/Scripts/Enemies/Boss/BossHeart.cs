using UnityEngine;

public class BossHeart : MonoBehaviour
{
    public Boss boss;
    void Start()
    {
        boss = FindAnyObjectByType<Boss>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DamageBoss();
            collision.GetComponent<PlayerController>().rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }

    void DamageBoss()
    {
        boss.heartOut = false;
        boss.GetComponent<Boss>().TakeDamage();
    }
}
