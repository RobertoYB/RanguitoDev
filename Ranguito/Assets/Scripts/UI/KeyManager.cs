using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void GetKey()
    {
        image.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
