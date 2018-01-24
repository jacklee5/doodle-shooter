using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class destroy : MonoBehaviour {

	public string[] tags;

	void OnTriggerExit2D(Collider2D other)
	{
		print ("hi");
		print (other.tag);
		if (tags.Contains (other.tag)) {
			Destroy (other.gameObject);
		}
	}
}
