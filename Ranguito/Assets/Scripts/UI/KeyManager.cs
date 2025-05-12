using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject image;
    public KeyDoor keyDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void GetKey()
    {
        image.SetActive(true);
        keyDoor.canOpen = true;
    }

    public void UseKey()
    {
        image.SetActive(false);
    }

}
