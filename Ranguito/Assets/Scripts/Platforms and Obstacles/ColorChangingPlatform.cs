using UnityEngine;

public class ColorChangingPlatform : MonoBehaviour
{
    public bool platformColor;
    public float changeCooldown = 1.5f;
    [SerializeField]private float timeUntilChange;
    public CollisionMechanic platformData;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        if (platformColor is false)
        {
            platformData.color = CollisionMechanic.Color.Green;
        }
        else
        {
            platformData.color = CollisionMechanic.Color.Magenta;
        }
        ResetCooldown();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleColorChange();
    }

    public void ResetCooldown()
    {
        timeUntilChange = changeCooldown;
    }
    public void HandleColorChange()
    {
        timeUntilChange -= Time.deltaTime;
        if (timeUntilChange <= 0)
        {
            ChangeColor();
            ResetCooldown();
            UpdateAnimation();
        }
    }

    public void ChangeColor()
    {
        platformColor = !platformColor;

        if (platformColor is false)
        {
            platformData.color = CollisionMechanic.Color.Green;
        }
        else
        {
            platformData.color = CollisionMechanic.Color.Magenta;
        }
    }

    void UpdateAnimation()
    {
        animator.SetBool("Color", platformColor);
    }
}
