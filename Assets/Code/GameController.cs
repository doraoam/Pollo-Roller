using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	public Rigidbody rigit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (player.transform.position.y < -20) {
			player.transform.position=new Vector3(0,4,0);
			rigit.velocity = new Vector3(0,0,0);

		}
	}
}
