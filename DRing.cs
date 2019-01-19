using UnityEngine;
using System.Collections;

public class DRing : MonoBehaviour {
	public float size;
	public string color;
	public SpriteRenderer thisRenderer;
	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (size/2, size/2, 1);
		thisRenderer = gameObject.GetComponent<SpriteRenderer> ();
		if (color == "green") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (0f, 1f, 0f, 1f); // Set to opaque green
		} else if (color == "blue") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (0f, 0f, 1f, 1f); // Set to opaque blue
		}
		else if (color == "yellow") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (1f, 0.92f, 0.016f, 1f); // Set to opaque yellow
		}
		else if (color == "orange") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (1f, 0.43f, 0f, 1f); // Set to opaque orange
		}
		else if (color == "purple") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (1f, 0f, 1f, 1f); // Set to opaque purple
		}
		else if (color == "grey") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (0.5f, 0.5f, 0.5f, 1f); // Set to opaque grey
		}
		else if (color == "black") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (0f, 0f, 0f, 1f); // Set to opaque black
		}
		else if (color == "red") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (1f, 0f, 0f, 1f); // Set to opaque red
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
