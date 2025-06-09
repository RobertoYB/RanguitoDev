using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    public void GoToMainMenu()
    {
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
