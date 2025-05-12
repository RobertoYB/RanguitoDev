using UnityEngine;

public class FireballDestroy : MonoBehaviour
{
    private float timer;
    public float destroyCooldown = 6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = destroyCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
