using UnityEngine;
using System.Collections;

public class FloorTrigger : MonoBehaviour
{
    public float deletedTime = 0.3f;
    float storedTime;
    bool isDestroying = false;
    public string targetTag;

    void Awake()
    {
        storedTime = deletedTime;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag(targetTag))
        {
            isDestroying = true;
        }
    }

    void Update()
    {
        if (isDestroying == true)
        {
            deletedTime -= Time.deltaTime;
        }

        if (deletedTime <= Time.deltaTime)
        {
            GameObject[] gameObject = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject target in gameObject)
            {
                Destroy(target);
            }
            FallingItem.setClear();
            deletedTime = storedTime;
        }
    }
}
