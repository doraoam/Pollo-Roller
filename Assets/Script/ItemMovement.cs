using UnityEngine;
using System.Collections;

public class ItemMovement : MonoBehaviour
{
    public float speed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
