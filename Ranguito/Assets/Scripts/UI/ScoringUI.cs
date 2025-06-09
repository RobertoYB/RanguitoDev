using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class ScoringUI : MonoBehaviour
{

    public GameObject textBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int hits;
    public float time;

    // Update is called once per frame
    void Update()
    {
        hits = ScoringManager.hits;
        time = MathF.Round(ScoringManager.timeLevel + ScoringManager.timeBoss + ScoringManager.timeBossDeaths);

        UpdateText();
    }

    public void UpdateText()
    {
        textBox.GetComponent<TMPro.TMP_Text>().text = $"TIME: {time} \n HITS: {hits}";
    }
}
