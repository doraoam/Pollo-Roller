using UnityEngine;
using System.Collections;

public class HeadShot : MonoBehaviour
{
    public bool isHurt = false;

    public float delayTime = 0.5f;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player") || col.collider.CompareTag("Item"))
        {
            isHurt = true;
        }
    }

    void Update()
    {
        if (isHurt == true)
        {
            delayTime -= Time.deltaTime;

            if (delayTime < 0)
            {
                isHurt = false;
            }
        }
    }
}
