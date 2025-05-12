using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{

    public float speed = 4;
    public bool movingUp;
    private float timer;
    public float changeDirectionCooldown = 5;

    void Start()
    {
        timer = changeDirectionCooldown; 
    }

    
    void Update()
    {
        if (movingUp == true)
        {
            transform.position += speed * Time.deltaTime * Vector3.up;
        }

        if (movingUp == false)
        {
            transform.position += speed * Time.deltaTime * Vector3.down;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = changeDirectionCooldown;
            movingUp = !movingUp;
        }
    }
}
