using UnityEngine;
using System.Collections;

public class Blockade : MonoBehaviour {
	public FaceScript polyFaceScript;
	public int strength = 0;
	// Use this for initialization
	void Start () {
		PolygonCollider2D thisPolygon = gameObject.AddComponent<PolygonCollider2D> () as PolygonCollider2D;
		thisPolygon.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.GetComponent<BoardBarrier>() == null && other.gameObject.GetComponent<ShapeIdentifier>() == null && other.gameObject.GetComponent<Blockade>() == null) { //Only collect polyfaces.
			polyFaceScript = other.GetComponent<FaceScript>();
			if (polyFaceScript.strength == 1)  {
				Destroy (other.gameObject);
				Debug.Log("Destroying GameObject!");
			}
			else {
				polyFaceScript.strength -= (strength + 1);
			}
			if (strength == 0) {
				Destroy (gameObject);
					}
		}
		
	}
}
