using UnityEngine;

public class BossRedSpike : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossPhase3>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
