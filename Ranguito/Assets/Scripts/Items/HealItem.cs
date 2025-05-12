using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int heal = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>().health < 3)
            {
                collision.gameObject.GetComponent<PlayerController>().Heal(heal);
                Destroy(gameObject);
            }
        }
    }
}
