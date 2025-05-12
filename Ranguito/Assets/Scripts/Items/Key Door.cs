using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool canOpen = false;
    public KeyManager keyManager;

    private void OnCollisionEnter2D()
    {
        if (canOpen)
        {
            keyManager.UseKey();
            Destroy(gameObject);
        }
    }

}
