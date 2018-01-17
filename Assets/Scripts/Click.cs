using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{

	public Texture2D pointer;
	private bool mouseInside;

	void Start ()
	{
		mouseInside = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (mouseInside) {
			Cursor.SetCursor (pointer, Vector2.zero, CursorMode.Auto);
			if (Input.GetMouseButtonDown (0)) {
				GameObject thePlayer = GameObject.Find ("Messages");
				Story playerScript = thePlayer.GetComponent<Story> ();
				bool done = playerScript.finished;
				if (done) {
					SceneManager.LoadScene ("Planet", LoadSceneMode.Single);
				}
			}
		} else {
			Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		}
	}

	void OnMouseOver ()
	{
		mouseInside = true;
		Debug.Log ("Inside");
	}

	void OnMouseExit ()
	{
		mouseInside = false;
		Debug.Log ("Outside");
	}
}
