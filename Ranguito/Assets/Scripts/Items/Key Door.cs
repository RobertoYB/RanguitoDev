using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoor : MonoBehaviour
{
    public bool canOpen = false;
    public KeyManager keyManager;

    private void OnCollisionEnter2D()
    {
        if (canOpen)
        {
            keyManager.UseKey();
            SceneManager.LoadScene("lv1-2_boss");
        }
    }

}
