using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    static int totalScore;
    int levelScore;

    public Text levelScoreText;
    public Text TotalScoreText;

    public string nextLevel;

    public GameObject showScoreCanvas;

    // Use this for initialization
    void Start()
    {
        levelScore = 0;

        showScoreCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalChecker.isOver == true && levelScore == 0)
        {
            levelScore = (int)Timer.finalTime - BomberWall.totalDead;
            totalScore += levelScore;
            Debug.Log(levelScore + " " + totalScore);

            showScoreCanvas.SetActive(true);
            levelScoreText.text = "Level Score : " + levelScore;
            TotalScoreText.text = "Total Score : " + totalScore; 
        }
    }

    public void Replay()
    {
        totalScore -= levelScore;
        GoalChecker.isOver = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void NextLevel()
    {
        Application.LoadLevel(nextLevel);
    }
}
