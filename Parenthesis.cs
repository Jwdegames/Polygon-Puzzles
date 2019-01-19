using UnityEngine;
using System.Collections;

public class Parenthesis : MonoBehaviour {
	public string color;
	public float size;
	public SpriteRenderer thisRenderer;
	public Sprite black;
	public Sprite blue;
	public Sprite red;
	public Sprite green;
	public Sprite grey;
	public Sprite orange;
	public Sprite purple;
	public Sprite yellow;
	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (size, size, 1);
		thisRenderer = gameObject.GetComponent<SpriteRenderer> ();
		if (color == "green") {
			thisRenderer.sprite = green;
		} else if (color == "blue") {
			thisRenderer.sprite = blue;
		}
		else if (color == "yellow") {
			thisRenderer.sprite = yellow;
		}
		else if (color == "orange") {
			thisRenderer.sprite = orange;
		}
		else if (color == "purple") {
			thisRenderer.sprite = purple;
		}
		else if (color == "grey") {
			thisRenderer.sprite = grey;
		}
		else if (color == "black") {
			thisRenderer.sprite = black;
		}
		else if (color == "red") {
			thisRenderer.sprite = red;
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
