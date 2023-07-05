using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _platformValue = 50;
    public int score = 0;
    public int levelScore = 0;
    public int maxScore = 0;

    public void Init()
    {
        GameEvents.Instance.OnPlatformPassed += ScoreCounter;
        GameEvents.Instance.OnTochedEnd += CountLevelScore;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnPlatformPassed -= ScoreCounter;
        GameEvents.Instance.OnTochedEnd -= CountLevelScore;
    }

    private void ScoreCounter()
    {
        score += _platformValue;
    }

    private void CountLevelScore()
    {
        levelScore = score;
        score = 0;
    }
}
