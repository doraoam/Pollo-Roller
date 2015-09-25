using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BomberWall : MonoBehaviour
{
    public Text deadCountText;
    public float respawnPointX;
    public float respawnPointY;
    public float respawnPointZ;
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

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player") && GoalChecker.isOver != true)
        {
            deadCount += 1;

            player.transform.position = new Vector3(respawnPointX, respawnPointY, respawnPointZ);

            deadCountText.text = "Dead Count : " + deadCount;
        }
    }
}
