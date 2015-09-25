using UnityEngine;
using System.Collections;

public class GoalChecker : MonoBehaviour
{
    public string nextLevel;
    public static bool isOver;

    void OnTriggerEnter(Collider col){
        if (col.CompareTag("Player"))
        {
            Debug.Log("You win!!");

            isOver = true;

            Application.LoadLevel(nextLevel);
        }
    }
}
