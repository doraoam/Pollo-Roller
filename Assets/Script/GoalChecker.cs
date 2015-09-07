using UnityEngine;
using System.Collections;

public class GoalChecker : MonoBehaviour
{
    void OnTriggerEnter(Collider col){
        if (col.CompareTag("Player"))
        {
            Debug.Log("You win!!");
        }
    }
}
