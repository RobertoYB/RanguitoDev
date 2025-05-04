using UnityEngine;

public class CollisionMechanic : MonoBehaviour
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

    private void OnCollisionStay2D(UnityEngine.Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Determine color.
            bool playerColor = collision.collider.GetComponent<PlayerController>().playerColor;

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

    private void GiveDamage(Collision2D collision)
    {
        if (damageCooldown > 0)
        {
            damageCooldown--;
            return;
        }

        collision.collider.GetComponent<PlayerController>().TakeDamage();
        damageCooldown = invincibilityFrames;
    }

    private void ResetCooldown()
    {
        damageCooldown = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ResetCooldown();
    }

    void Update()
    {

    }
}
