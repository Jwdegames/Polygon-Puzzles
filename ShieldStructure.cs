using UnityEngine;
using System.Collections;

public class ShieldStructure : MonoBehaviour {
	public float size;
	public FaceScript interceptedObject;
	public GameObject gameManager;
	public int life;
	public int lastTurn = 0;
	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (size * 0.75f, size, 1);
		gameManager = GameObject.Find("GameManager");
		life = gameManager.GetComponent<GameManager> ().shieldLength;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.GetComponent<GameManager> ().turnCounter != lastTurn) {
			if (life == 0) {
				Destroy(gameObject);
			}
			else {
			life -= 1;
			}
			lastTurn = gameManager.GetComponent<GameManager> ().turnCounter;
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<FaceScript> () != null) {
			interceptedObject = other.GetComponent<FaceScript> ();
			if (interceptedObject.color != "green" ) {
				Destroy (other.gameObject);
			}
		}
	}
}
