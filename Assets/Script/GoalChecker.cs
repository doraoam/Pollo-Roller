using UnityEngine;
using System.Collections;

public class GoalChecker : MonoBehaviour
{
    public static bool isOver;

    Animator animator;

    public GameObject player;

    public Camera elevatorCamera;

    public Camera mainCamera;

    void Awake()
    {
        if (isOver == true)
        {
            isOver = false;
        }

        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

        elevatorCamera = GameObject.FindGameObjectWithTag("ElevatorCamera").GetComponent<Camera>();

        elevatorCamera.enabled = false;

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void OnTriggerEnter(Collider col){
        if (col.CompareTag("Player"))
        {
            swapCamera();

            animator.SetBool("isOver", true);

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Elevator_playerEnter"))
            {
                
            }
            else if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Elevator_waiting"))
            {
                //isOver = true;
            }
        }
    }

    void swapCamera()
    {
        mainCamera.enabled = false;

        elevatorCamera.enabled = true;

        Destroy(player);
    }
}
