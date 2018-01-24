﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Shoot : MonoBehaviour {

	public GameObject lazer;
	public int speed;
	public int reload;
	private Timer tmr; 
	private Transform ship;
	private double coolDown;

	// Use this for initialization
	void Start () {
		speed = 10;
		tmr = new Timer();
		ship = transform.parent;
		coolDown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && coolDown <= 0) {
			Vector2 target = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
			Vector2 myPos = new Vector2 (transform.position.x, transform.position.y + 1);
			Vector2 direction = target - myPos;
			direction.Normalize ();
			Quaternion rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg + 90);
			GameObject projectile = (GameObject)Instantiate (lazer, myPos, rotation);
			projectile.GetComponent<Rigidbody2D> ().velocity = direction * speed;
//TODO: delete projectile after a couple seconds
			EnergyManager shipEnergy = ship.GetComponent<EnergyManager> ();
			shipEnergy.energyUsed += 6;
			coolDown = reload;
		}
		coolDown -= Time.deltaTime;
		print (coolDown);
	}
}
