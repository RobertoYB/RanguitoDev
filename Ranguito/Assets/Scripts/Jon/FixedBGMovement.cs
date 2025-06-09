using UnityEngine;

public class FixedBGMovement : MonoBehaviour
{
    public GameObject fixedCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var playerPosition = fixedCamera.transform.position;
        UpdateCameraPosition(playerPosition);
    }

    public void UpdateCameraPosition(Vector3 playerPosition)
    {
        if (playerPosition.x != transform.position.x || playerPosition.y != transform.position.y)
        {
            transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
        }
    }
}
