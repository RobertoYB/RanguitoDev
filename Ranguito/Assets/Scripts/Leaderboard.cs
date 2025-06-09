using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using Newtonsoft.Json;
using UnityEngine;
using JetBrains.Annotations;

public class Leaderboard : MonoBehaviour
{
    public List<Ranking> rankings;

    private void Awake()
    {
        rankings = new List<Ranking>();
        LoadScores();
        OrderScores();
    }

    public void AddScore(Ranking ranking)
    {
        rankings.Add(ranking);
        OrderScores();
        SaveScores();
    }

    private void OrderScores()
    {
        rankings.Sort((x, y) => x.totalScore.CompareTo(y.totalScore));
        rankings.Reverse();
    }
    
    public void SaveScores()
    {
        string json = JsonConvert.SerializeObject(rankings);
        using (StreamWriter writer = new(Application.dataPath + Path.AltDirectorySeparatorChar + "Leaderboard.json"))
        {
            writer.Write(json);
        };
    }

    private void LoadScores()
    {
        string json = string.Empty;

        using (StreamReader reader = new(Application.dataPath + Path.AltDirectorySeparatorChar + "Leaderboard.json"))
        {
            json = reader.ReadToEnd();
        }

        rankings = JsonConvert.DeserializeObject<List<Ranking>>(json);
    }
}
