using UnityEngine;
using System.Collections;

public class SemiEnemy : MonoBehaviour
{
    public float health = 0;
    public bool alive = true;
    public bool isDeadAble;

    HeadShot head;

    void Awake()
    {
        head = GetComponentInChildren<HeadShot>();
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

    public void setDeath()
    {
        alive = false;
    }

    void Update()
    {
        if (alive != true)
        {
            Death();
        }

        if (head.isHurt == true)
        {
            health--;

            if (health <= 0)
            {
                alive = false;
            }
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
