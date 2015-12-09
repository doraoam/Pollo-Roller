using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce = 250;

    public bool jumpable = false;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (jumpable == true)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("JumpMouse"))
            {
                Vector3 force = new Vector3(0, 1, 0) * jumpForce;
                rb.AddForce(force);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GoalChecker.isOver != true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
    }
}
