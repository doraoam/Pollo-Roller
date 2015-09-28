using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        GameObject slope = GameObject.FindGameObjectWithTag("slope");
        animator = slope.GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player") && GoalChecker.isOver != true)
        {
            animator.SetBool("isEnabled",true);
        }
    }
}
