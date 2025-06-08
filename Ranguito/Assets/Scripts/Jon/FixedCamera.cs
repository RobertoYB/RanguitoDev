using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    private Transform startPosition;
    public Transform phase2Position;
    public Transform phase3Position;

    public float speed = 15;
    private Vector3 moveTowards;

    public bool shouldMove = false;

    void Start()
    {
        startPosition = gameObject.transform;
    }

    public void MoveToPhase2()
    {
        shouldMove = true;
        moveTowards = phase2Position.position;
    }

    public void MoveToPhase3()
    {
        shouldMove = true;
        moveTowards = phase3Position.position;
    }

    void FixedUpdate()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTowards, speed * Time.deltaTime);

            if (transform.position == moveTowards)
            {
                startPosition.position = moveTowards;
                shouldMove = false;
            }
        }
    }
}
