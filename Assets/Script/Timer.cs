using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Text timerText;

    public float timer;
    public static float finalTime;

    public bool isFree;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isFree != true)
        {
            if (timer > 0)
            {
                if (GoalChecker.isOver != true)
                {
                    timer -= Time.deltaTime;
                    timerText.text = timer.ToString("F0");
                }
                else
                {
                    finalTime = timer;
                }
            }
            else
            {
                timerText.text = "Game Over";
                finalTime = timer;
                if (finalTime < 0) {
                    finalTime = 0;
                }
                GoalChecker.isOver = true;
            }
        }
        else
        {
            timer = 60;

            timerText.text = "Free Play";
            finalTime = timer;
        }
    }
}
