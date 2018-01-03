using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[InitializeOnLoad]
public class DrawShip {
	//0 = none, t = thruster, r = reactor, x = turret
	public string[] blueprint;
	public GameObject thruster;
	public GameObject reactor;
	public GameObject turret;
	private Dictionary<char, GameObject> dict = new Dictionary<char, GameObject>();
	static DrawShip()
	{
		blueprint = new string[] {
			"xr",
			"rx",
			"tt"
		};
		for (int i = 0; i < blueprint.Length; i++) {
			for (int j = 0; j < blueprint [i].Length; i++) {
				char current = blueprint [i] [j];
				if (current != '0') {
					
				}
			}
		}

	}
}