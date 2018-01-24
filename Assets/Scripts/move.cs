using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	public double speed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb.AddForce (new Vector2 (0, 10));
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			rb.AddForce (new Vector2 (0, -10));
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.AddTorque (1);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.AddTorque (-1);
		}
	}
}
