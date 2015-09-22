using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Text timerText;

    public float timer;
    public static float finalTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
            //timerText.color = Color.red;
            timerText.text = "Game Over";
            finalTime = timer;
            GoalChecker.isOver = true;
        }
    }
}
