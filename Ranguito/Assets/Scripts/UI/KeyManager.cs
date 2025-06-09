using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject image;
    public GameObject image2;
    public KeyDoor keyDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (ScoringManager.gotGreat)
        {
            image2.SetActive(true);
        }
    }
    public void GetKey()
    {
        image.SetActive(true);
        keyDoor.canOpen = true;
    }

    public void GetGreat()
    {
        image2.SetActive(true);
    }

    public void UseKey()
    {
        image.SetActive(false);
    }

}
