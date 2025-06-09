using System;
using TMPro;
using UnityEngine;

public class VictoryScreenData : MonoBehaviour
{
    public GameObject textBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuManager.enableSubmit = true;
        int hits = ScoringManager.hits;
        int time = (int)MathF.Round(ScoringManager.timeLevel + ScoringManager.timeBoss + ScoringManager.timeBossDeaths);
        int totalScore = 10000 - hits * time;
        textBox.GetComponent<TMP_Text>().text = $"HITS: + {hits} \n TIME: {time} \n TOTAL SCORE: {totalScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
