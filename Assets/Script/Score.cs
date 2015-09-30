using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    static int totalScore;
    int levelScore;

    // Use this for initialization
    void Start()
    {
        levelScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalChecker.isOver == true && levelScore == 0)
        {
            levelScore = (int)Timer.finalTime - BomberWall.totalDead;
            totalScore += levelScore;
            Debug.Log(levelScore + " " + totalScore);
        }
    }
}
