using UnityEngine;
using System.Collections;

public class yellowStorm : MonoBehaviour {
	public bool isFinished = false;
	public GameObject creator;
	public GameObject audioManager;
	// Use this for initialization
	void Start () {
		audioManager = GameObject.Find ("AudioManager");
	}
	
	// Update is called once per frame
	void Update () {
	if (isFinished) {
			if (creator.GetComponent<ShapeIdentifier>().color != "yellow" ) {
				if (creator.GetComponent<ShapeIdentifier>().strength == 0) {
			creator.GetComponent<ShapeIdentifier>().color = "yellow";
				}
				else {
					creator.GetComponent<ShapeIdentifier>().strength -= 1;
				}
			}
			else {
				if (creator.GetComponent<ShapeIdentifier>().strength <= 2) {
					creator.GetComponent<ShapeIdentifier>().strength += 1;
				}
			}
			audioManager.GetComponent<AudioManager>().playSoundEffect(1);
			Destroy(gameObject);
		}
	}
}
