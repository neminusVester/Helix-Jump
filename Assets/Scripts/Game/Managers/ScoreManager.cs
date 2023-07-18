using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _platformValue = 50;
    public int score = 0;
    public int levelScore = 0;

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
        if (levelScore > SLS.Data.MaxScore.Value)
        {
            SLS.Data.MaxScore.Value = levelScore;
            SLS.Data.MaxScore.OnValueChanged += TestFunc;
        }
        score = 0;
    }

    public void TestFunc(int t)
    {
        Debug.Log($"Max score: {SLS.Data.MaxScore.Value}");
    }
}
