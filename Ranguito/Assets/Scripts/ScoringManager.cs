using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoringManager : MonoBehaviour
{
    public static int hits = 0;
    public static float timeLevel = 0;
    public static float timeBoss = 0;
    public static float timeBossDeaths = 0;


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "NIVEL")
        {
            timeLevel = Time.timeSinceLevelLoad;
        }
        else if (SceneManager.GetActiveScene().name == "lv1-2_boss")
        {
            timeBoss = Time.timeSinceLevelLoad;
        }
    }
}
