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
    public GameObject showScoreGameOverCanvas;

    // Use this for initialization
    void Start()
    {
        levelScore = 0;

        showScoreCanvas.SetActive(false);
        showScoreGameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalChecker.isOver == true && levelScore == 0 && ((GoalChecker.finishAnimation == true) || (GoalChecker.isFail == true)))
        {
            levelScore = (int)Timer.finalTime - BomberWall.totalDead;
            totalScore += levelScore;
            Debug.Log(levelScore + " " + totalScore);

            if (GoalChecker.isFail != true)
            {
                showScoreCanvas.SetActive(true);
            }
            else
            {
                showScoreGameOverCanvas.SetActive(true);
            }
            
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
