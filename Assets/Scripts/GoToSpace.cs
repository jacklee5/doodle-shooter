using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSpace : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		GameObject thePlayer = GameObject.Find ("Messages");
		Story playerScript = thePlayer.GetComponent<Story> ();
		bool done = playerScript.finished;
		if (done) {
			SceneManager.LoadScene ("Battle", LoadSceneMode.Single);
		}
	}
}
