using UnityEngine;

public class TheGreat : MonoBehaviour
{
    public KeyManager keyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoringManager.gotGreat = true;
            keyManager.GetGreat();
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
