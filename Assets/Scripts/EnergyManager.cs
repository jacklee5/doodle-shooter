﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour {

	public int reactorEnergy;
	private double energyLimit;
	private double energyUsed;
	private string[] blueprint;

	// Use this for initialization
	void Start () {
		Ship self = GetComponent<Ship> ();
		blueprint = self.blueprint;
		for (int i = 0; i < blueprint.Length; i++) {
			for (int j = 0; j < blueprint[i].Length; j++) {
				if (blueprint [i] [j] == 'r') {
					energyLimit += reactorEnergy;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
