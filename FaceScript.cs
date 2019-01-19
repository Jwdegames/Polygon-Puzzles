using UnityEngine;
using System.Collections;

public class FaceScript : MonoBehaviour {

	public string direction;
	public string color;
	public Vector3 start;
	public Vector3 target;
	public float speed = 0.75f;
	public float strength = 1;
	public float desTimer= 0.001f;
	public float timer;
	public bool selfDestruct = false;
	public bool indestructible;
	public bool generateShield = false;
	public bool invis = false;
	public bool continueFire = false;
	public int fireLife = 0;
	// Use this for initialization
	void Start () {
		start = transform.position;
		if (color == "green") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (0f, 1f, 0f, 1f); // Set to opaque green
			gameObject.layer = LayerMask.NameToLayer ("Green");
		}
		if (color == "blue") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (0f, 0f, 1f, 1f); // Set to opaque green
			gameObject.layer = LayerMask.NameToLayer ("Blue");
		}
		if (color == "yellow") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (1f, 0.92f, 0.016f, 1f); // Set to opaque green
			gameObject.layer = LayerMask.NameToLayer ("Yellow");
		}
		if (color == "orange") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (1f, 0.43f, 0f, 1f); // Set to opaque yellow
			gameObject.layer = LayerMask.NameToLayer ("Orange");
		}
		PolygonCollider2D thisPolygon = gameObject.AddComponent<PolygonCollider2D> ();
		thisPolygon.isTrigger = true;
		gameObject.transform.localScale = new Vector3 (strength, strength, 1);
		speed = speed * strength;
		if (indestructible) {
			speed = 0.75f * 18;
		}
		if (invis) {
			speed = 0.75f * 18;
		}
	}
	// Update is called once per frame
	void Update () {
		if (direction == "left") {
			target.x = start.x - 100;
			target.y = start.y;
			target.z = start.z;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		else if (direction == "down") {
			target.x = start.x;
			target.y = start.y - 100;
			target.z = start.z;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		else if (direction == "right") {
			target.x = start.x + 100;
			target.y = start.y;
			target.z = start.z;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		else if (direction == "up") {
			target.x = start.x;
			target.y = start.y + 100;
			target.z = start.z;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		else if (direction == "upleft") {
			target.x = start.x - 100;
			target.y = start.y + 100;
			target.z = start.z;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		else if (direction == "downleft") {
			target.x = start.x - 100;
			target.y = start.y - 100;
			target.z = start.z;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		else if (direction == "upright") {
			target.x = start.x + 100;
			target.y = start.y + 100;
			target.z = start.z;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		else if (direction == "downright") {
			target.x = start.x + 100;
			target.y = start.y - 100;
			target.z = start.z;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		if (desTimer != 0 && selfDestruct) {
			timer += Time.deltaTime;
			if (desTimer <= timer) {
				Destroy(gameObject);
			}
		}
	}
}
