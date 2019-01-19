using UnityEngine;
using System.Collections;

public class orangeScare : MonoBehaviour {
	public float size;
	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (size/2, size/2, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
