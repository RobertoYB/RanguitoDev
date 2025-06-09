using UnityEngine;

public class Ranking
{
    public int time;
    public int hits;
    public string name;
    public int totalScore;

    public Ranking(int time, int hits, string name)
    {
        this.time = time;
        this.hits = hits;
        this.name = name;

        totalScore = 10000-time*hits;
    }   
}
