using UnityEngine;

public class BossCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Phase phase;
    private Boss bossPhase1;
    private BossPhase2 bossPhase2;
    private BossPhase3 bossPhase3;

    public enum Phase
    {
        One, Two, Three
    }

    void Start()
    {
        if (phase == Phase.One)
        {
            bossPhase1 = FindAnyObjectByType<Boss>();
        }

        if (phase == Phase.Two)
        {
            bossPhase2 = FindAnyObjectByType<BossPhase2>();
        }

        if (phase == Phase.Three)
        {
            bossPhase3 = FindAnyObjectByType<BossPhase3>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == Phase.One)
        {
            if (!bossPhase1.isActiveAndEnabled)
            {
                Destroy(gameObject);
            }
        }

        if (phase == Phase.Two)
        {
            if (!bossPhase2.isActiveAndEnabled)
            {
                Destroy(gameObject);
            }
        }

        if (phase == Phase.Three)
        {
            if (!bossPhase3.isActiveAndEnabled)
            {
                Destroy(gameObject);
            }
        }
    }
}
