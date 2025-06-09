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
        ScoringManager.hits = 0;
        ScoringManager.timeBoss = 0;
        ScoringManager.timeBossDeaths = 0;
        ScoringManager.timeLevel = 0;
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
