using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour
{
    public float health = 0;
    bool isAlive = true;

    public void TakeDamage(float amount)
    {
        if (isAlive == false)
        {
            return;
        }

        health -= amount;
        if (amount < 0)
        {
            isAlive = false;
            Dead();
        }
    }

    public virtual void Dead()
    {
        Destroy(this);
    }
}
