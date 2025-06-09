using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static bool enableSubmit = false;
    void Start()
    {
        
    }

    public void GoToMainMenu()
    {
        enableSubmit = false;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void GoToRankings()
    {
        SceneManager.LoadScene("ranking");
    }
    void Update()
    {
        
    }
}
