using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	int speed = 44;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		
		if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
			transform.Rotate(Vector3.left * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
			transform.Rotate(Vector3.right * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.back * speed * Time.deltaTime);
		
	}

}