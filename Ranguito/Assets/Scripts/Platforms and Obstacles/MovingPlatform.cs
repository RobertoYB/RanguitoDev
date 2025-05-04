using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public Transform startPosition;
    public Transform endPosition;


    public float speed;
    private Vector3 moveTowards;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveTowards = endPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, moveTowards, speed * Time.deltaTime);

        if (platform.transform.position == startPosition.position)
        {
            moveTowards = endPosition.position;
        }

        if (platform.transform.position == endPosition.position)
        {
            moveTowards = startPosition.position;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
