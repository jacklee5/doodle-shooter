using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour {

	public Texture2D move;

	public float zoomSpeed = 1;
	public Camera camera;
	public GameObject background;
	public bool isDrag;

	private bool mouseDown;
	private float pmouseX;
	private float pmouseY;
	private Bounds bounds;
	private float panSpeed;

	void Start(){
		if (background.transform.childCount > 0) {
			bounds = GetChildRendererBounds (background);
		} else {
			bounds = background.GetComponent<Renderer> ().bounds;
		}
		isDrag = false;
		panSpeed = 50; //pan speed increases as this goes down
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			mouseDown = true;
			isDrag = true;
		} 
		if (Input.GetMouseButtonUp(0)){
			mouseDown = false;
		}
		if (mouseDown) {
			if (pmouseX != default(float) && pmouseY != default(float)) {
				float xOff = (Input.mousePosition.x - pmouseX) / panSpeed;
				float yOff = (Input.mousePosition.y - pmouseY) / panSpeed;
				float newX = transform.position.x - xOff;
				float newY = transform.position.y - yOff;
				//TODO: Make pan constrain to background bounds.
				Vector3 bottomLeft = new Vector3(background.transform.position.x - bounds.extents.x, background.transform.position.y - bounds.extents.y, 0);
				Vector3 topRight = new Vector3 (background.transform.position.x + bounds.extents.x, background.transform.position.y + bounds.extents.y, 0);
				//if the background GameObject is on screen (e.g. left is true when the left edge is on screen)
				bool left = camera.WorldToViewportPoint(bottomLeft).x > 0;
				bool right = camera.WorldToViewportPoint (topRight).x < 1;
				bool bottom = camera.WorldToViewportPoint (bottomLeft).y > 0;
				bool top = camera.WorldToViewportPoint (topRight).y < 1;
				bool canMoveX = (newX > transform.position.x && !right) || (newX < transform.position.x && !left);
				bool canMoveY = (newY > transform.position.y && !top) || (newY < transform.position.y && !bottom);
				transform.position = new Vector3 (canMoveX ? newX : transform.position.x, canMoveY ? newY : transform.position.y, -10);
				if (!(pmouseX == Input.mousePosition.x && pmouseY == Input.mousePosition.y)) {
					Cursor.SetCursor (move, Vector2.zero, CursorMode.Auto);
					isDrag = false;
				}
			}
			pmouseX = Input.mousePosition.x;
			pmouseY = Input.mousePosition.y;
		} else {
			pmouseX = default(float);
			pmouseY = default(float);
			Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		}
		camera.orthographicSize = Mathf.Clamp(Mathf.Lerp(camera.orthographicSize, camera.orthographicSize + Input.GetAxis("Mouse ScrollWheel") * -100, Time.deltaTime * zoomSpeed),0,Mathf.Infinity);
		panSpeed = 250/Mathf.Clamp (Mathf.Lerp (camera.orthographicSize, camera.orthographicSize + Input.GetAxis ("Mouse ScrollWheel") * -100, Time.deltaTime * zoomSpeed), 0, Mathf.Infinity);
	}

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
}
