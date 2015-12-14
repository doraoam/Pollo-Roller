using UnityEngine;
using System.Collections;

public class FinalEnemy : MonoBehaviour
{
    public float health = 10;
    public bool alive = true;

    Animator animator;

    void Awake()
    {
        GameObject elevator = GameObject.FindGameObjectWithTag("Elevator");
        animator = elevator.GetComponent<Animator>();

        GetComponent<Animator>().speed = 0.1f;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Item"))
        {
            health--;

            if (health <= 0)
            {
                alive = false;
            }
        }
    }

    void Update()
    {
        if (alive != true)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
        animator.SetBool("isAppear", true);
    }
}
