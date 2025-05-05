using UnityEngine;

public class TriggerCollisionMechanic : MonoBehaviour
{
    public Color color;
    public enum Color
    {
        Red, Green, Magenta
    }

    private int invincibilityFrames = 7;
    [SerializeField] private int damageCooldown;

    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Determine color.
            bool playerColor = collision.GetComponent<PlayerController>().playerColor;

            //Give damage
            if (color == Color.Red)
            {
                GiveDamage(collision);
            }

            if (color == Color.Green)
            {
                if (playerColor)
                {
                    GiveDamage(collision);
                }
                else
                {
                    ResetCooldown();
                }
            }

            if (color == Color.Magenta)
            {
                if (!playerColor)
                {
                    GiveDamage(collision);
                }
                else
                {
                    ResetCooldown();
                }
            }
        }
    }

    private void GiveDamage(Collider2D collision)
    {
        if (damageCooldown > 0)
        {
            damageCooldown--;
            return;
        }

        collision.GetComponent<PlayerController>().TakeDamage();
        damageCooldown = invincibilityFrames;
    }

    private void ResetCooldown()
    {
        damageCooldown = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ResetCooldown();
    }

    void Update()
    {

    }
}
