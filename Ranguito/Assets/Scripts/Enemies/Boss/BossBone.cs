using UnityEngine;

public class BossBone : MonoBehaviour
{

    public float nextFlip;
    public float flipCooldown = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextFlip = flipCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        nextFlip -= Time.deltaTime;
        if (nextFlip <= 0)
        {
            transform.localScale = new Vector3(transform.localScale.x*-1, 1, 1);
            nextFlip = flipCooldown;
        }
    }
}
