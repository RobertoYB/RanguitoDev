using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject image;
    public GameObject image2;
    public KeyDoor keyDoor;
    private AudioController audioController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        audioController = GetComponent<AudioController>();
        if (ScoringManager.gotGreat)
        {
            image2.SetActive(true);
        }
    }
    public void GetKey()
    {
        audioController.PlayAudio(0);
        image.SetActive(true);
        keyDoor.canOpen = true;
    }

    public void GetGreat()
    {
        audioController.PlayAudio(0);
        image2.SetActive(true);
    }

    public void UseKey()
    {
        image.SetActive(false);
    }

}
