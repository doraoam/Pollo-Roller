using UnityEngine;
using System.Collections;

public class SemiEnemy : MonoBehaviour
{
    public float health = 0;
    public bool alive = true;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Item") || col.collider.CompareTag("Player"))
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
    }
}
