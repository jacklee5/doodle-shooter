using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{

	public string[] messages;
	public Text element;
	public Text skip;
	public string lastMessage;
	public string lastSkip;
	public bool finished;

	private int current;
	private GameObject camera;


	// Use this for initialization
	void Start ()
	{
		current = 0;
		displayText ();
		finished = false;
		camera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonUp (0)) {
			try{
				Pan pan = camera.GetComponent<Pan> ();
				if (pan.isDrag) {
					current++;
					displayText ();
				}
			}
			catch{
				current++;
				displayText ();
			}
		}
	}

	void displayText ()
	{
		if (current < messages.Length) {
			element.text = messages [current];
		} else {
			element.text = lastMessage;
			skip.text = lastSkip;
			finished = true;
		}
	}
}
