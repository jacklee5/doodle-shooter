using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	public double speed;
	private Rigidbody2D rb;
	private Transform ship;
	private Rigidbody2D shipRb;
	private bool isMoving;
	private bool hasCounted;
	EnergyManager shipEnergy;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		ship = transform.parent;
		shipRb = ship.GetComponent<Rigidbody2D> ();
		isMoving = false;
		hasCounted = false;
		shipEnergy = ship.GetComponent<EnergyManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		isMoving = false;
		if (Input.GetKey (KeyCode.UpArrow)) {
			shipRb.AddForce(ship.up);
			isMoving = true;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			shipRb.AddForce (-ship.up);
			isMoving = true;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			shipRb.AddTorque (-1);
			isMoving = true;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			shipRb.AddTorque (1);
			isMoving = true;
		}

		if (isMoving && !hasCounted) {
			shipEnergy.energyUsed++;
			hasCounted = true;
		}

		if (!isMoving && hasCounted) {
			shipEnergy.energyUsed--;
			hasCounted = false;

		}
	}
}
