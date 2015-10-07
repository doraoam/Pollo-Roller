using UnityEngine;
using System.Collections;

public class GoalChecker : MonoBehaviour
{
    public static bool isOver;
    public static bool isFail;
    public static bool finishAnimation;

    public bool isPlayingAnimaion;

    Animator animator;

    public GameObject player;

    public GameObject Pop;

    public Camera elevatorCamera;

    public Camera mainCamera;

    void Awake()
    {
        if (isOver == true)
        {
            isOver = false;
            isFail = false;
            isPlayingAnimaion = false;
            finishAnimation = false;
        }

        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

        elevatorCamera = GameObject.FindGameObjectWithTag("ElevatorCamera").GetComponent<Camera>();

        elevatorCamera.enabled = false;

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Elevator_playerEnter"))
        {
            Instantiate(Pop, transform.position, Quaternion.identity);
            animator.SetBool("isFinished", true);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Elevator_Disappear"))
        {
            finishAnimation = true;
        }

        if (isOver == true && finishAnimation == false && isPlayingAnimaion == false)
        {
            isFail = true;
        }
    }

    void OnTriggerEnter(Collider col){
        if (col.CompareTag("Player"))
        {
            isOver = true;
            isPlayingAnimaion = true;

            swapCamera();

            animator.SetBool("isOver", true);
        }
    }

    void swapCamera()
    {
        mainCamera.enabled = false;

        elevatorCamera.enabled = true;
    }
}
