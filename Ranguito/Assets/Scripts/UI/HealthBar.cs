using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 3;
    public int health;
    public PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
            healthSlider.maxValue = maxHealth;
            health = maxHealth;
            healthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = PlayerController.health;
    }
}
