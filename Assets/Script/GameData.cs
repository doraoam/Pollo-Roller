using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameData
{
    public GameData current;
    public int score;
    public string level;

    public GameData()
    {
        score = Score.totalScore;
        level = Application.loadedLevelName;
    }
}
