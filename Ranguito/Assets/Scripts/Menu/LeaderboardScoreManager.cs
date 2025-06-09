using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScoreManager : MonoBehaviour
{
    public GameObject leaderboard;
    public GameObject textNames;
    public GameObject textHits;
    public GameObject textTimes;
    public GameObject textScores;
    public GameObject nameToSubmit;

    void Start()
    {
        UpdateData();
    }

    public void UpdateData()
    {
        WriteData(textNames, 0);
        WriteData(textHits, 2);
        WriteData(textTimes, 1);
        WriteData(textScores, 3);
    }

    public void WriteData(GameObject textBox, int dataType)
    {
        string data = string.Empty;

        int count = 0;
        foreach (Ranking ranking in leaderboard.GetComponent<Leaderboard>().rankings)
        {
            if (dataType == 0)
            {
                data += leaderboard.GetComponent<Leaderboard>().rankings[count].name + "\n";
            }
            else if (dataType == 1)
            {
                data += leaderboard.GetComponent<Leaderboard>().rankings[count].time + "\n";
            }
            else if (dataType == 2)
            {
                data += leaderboard.GetComponent<Leaderboard>().rankings[count].hits + "\n";
            }
            else if (dataType == 3)
            {
                data += leaderboard.GetComponent<Leaderboard>().rankings[count].totalScore + "\n";
            }

            count++;
            if (count >= 10)
            {
                break;
            }
        }

        textBox.GetComponent<TMP_Text>().text = data;
    }

    public void SubmitScore()
    {
        string finalName = nameToSubmit.GetComponent<TMP_InputField>().text;
        leaderboard.GetComponent<Leaderboard>().AddScore(ScoringManager.SubmitScore(finalName));
        UpdateData();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
