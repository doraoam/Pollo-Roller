using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BomberWall : MonoBehaviour
{
    public Text deadCountText;

    public GameObject player;

    int deadCount;

    public static int totalDead;

    void Awake()
    {
        deadCount = 0;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void update()
    {
        if (GoalChecker.isOver == true)
        {
            totalDead = deadCount;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && GoalChecker.isOver != true)
        {
            deadCount += 1;

            player.transform.position = new Vector3(0, 0.5f, -3.5f);

            deadCountText.text = "Dead Count : " + deadCount;
        }
    }
}
