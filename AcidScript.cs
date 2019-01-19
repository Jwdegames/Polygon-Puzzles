using UnityEngine;
using System.Collections;

public class AcidScript : MonoBehaviour {
	public string direction;
	public Vector3 start;
	public Vector3 target;
	public float speed = 0.75f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		start = transform.position;
		target.x = start.x;
		target.y = start.y - 100;
		target.z = start.z;
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
		if (gameObject.transform.localScale.x >= 0.505) {
			gameObject.transform.localScale = new Vector3 (transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, 1);
		}
	}
}
