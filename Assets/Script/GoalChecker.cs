using UnityEngine;
using System.Collections;

public class GoalChecker : MonoBehaviour
{
    public string nextLevel;
    public static bool isOver;

    void Awake()
    {
        if (isOver == true)
        {
            isOver = false;
        }
    }

    void OnTriggerEnter(Collider col){
        if (col.CompareTag("Player"))
        {
            isOver = true;

            Application.LoadLevel(nextLevel);
        }
    }
}
