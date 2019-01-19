using UnityEngine;
using System.Collections;

public class BoardBarrier : MonoBehaviour {

	public GameObject interceptedObject;
	public string direction = null;
	// Use this for initialization
	void Start () {
		PolygonCollider2D thisPolygon = gameObject.AddComponent<PolygonCollider2D>() as PolygonCollider2D;
		thisPolygon.isTrigger = true; // Make a trigger polygon collider
		SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();
		renderer.color = new Color(0f, 0f, 0f, 0f); // Make the sprite invisible
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other) {
		interceptedObject = other.gameObject;
		if (interceptedObject.GetComponent<ShapeIdentifier> () == null) {
			if (interceptedObject.GetComponent<FaceScript> ().direction == direction) {
				Destroy (other.gameObject); // Destroy the incoming object if it doesn't have the Polygon Shape Script
				Debug.Log ("Destroying GameObject!");
			}
		}
	}
}
