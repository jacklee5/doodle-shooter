using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
	//0 = none, t = thruster, r = reactor, x = turret, s = shipReactor
	private string[] blueprint;
	private float x;
	private float y;
	public GameObject thruster;
	public GameObject reactor;
	public GameObject turret;
	public GameObject shipBay;
	public GameObject bridge;
	public Dictionary<char, GameObject> parts;

	Bounds GetChildRendererBounds (GameObject go)
	{
		Renderer[] renderers = go.GetComponentsInChildren<Renderer> ();

		if (renderers.Length > 0) {
			Bounds bounds = renderers [0].bounds;
			for (int i = 1, ni = renderers.Length; i < ni; i++) {
				bounds.Encapsulate (renderers [i].bounds);
			}
			return bounds;
		} else {
			return new Bounds ();
		}
	}
	// Use this for initialization
	void Start ()
	{
		Ship self = GetComponent<Ship> ();
		blueprint = self.blueprint;
		x = transform.position.x;
		y = transform.position.y;
		parts = new Dictionary<char, GameObject> () {
			{ 't',thruster },
			{ 'r',reactor },
			{ 'x',turret },
			{ 's', shipBay },
			{ 'b', bridge }
		};
		for (int i = 0; i < blueprint.Length; i++) {
			for (int j = 0; j < blueprint [i].Length; j++) {
				char current = blueprint [i] [j];
				if (current != '0') {
					float xOff = (float)j;
					Bounds bounds = GetChildRendererBounds (parts [current]);
					float yOff = (float)i - ((bounds.size.y >= (float)0.96) ? 0 : (float)0.96 - (bounds.size.y));
					if (parts.ContainsKey (current)) {
						GameObject part = Instantiate (parts [current], new Vector2 (x * (float)0.96 + xOff, y * (float)0.96 - yOff), Quaternion.identity) as GameObject;
						part.transform.parent = this.transform;
					}
				}
			}
		}
	}
}
