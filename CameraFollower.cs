using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {
	public GameObject mCamera;
	public Vector3 cameraPosition;
	public float xOffset = 4.544035f;
	public float yOffset = 7.951268f;
	public float zPosition = -3;
	public bool ratioNeeded = false;
	public float ratio;
	private Vector3 rescaledSize;
	// Use this for initialization
	void Start () {
		mCamera = GameObject.Find("Main Camera");

	}
	
	// Update is called once per frame
	void Update () {
		/* Set the postition of the object using the offset and the zposition
		 Resize the object if neccesary using a ratio*/
		cameraPosition.x = mCamera.transform.position.x + xOffset;
		cameraPosition.y = mCamera.transform.position.y + yOffset;
		cameraPosition.z = zPosition;
		transform.position = cameraPosition;
		if (ratioNeeded) {
			rescaledSize.x = mCamera.GetComponent<UnityEngine.Camera> ().orthographicSize / ratio;
			rescaledSize.y = mCamera.GetComponent<UnityEngine.Camera> ().orthographicSize / ratio;
			rescaledSize.z = mCamera.GetComponent<UnityEngine.Camera> ().orthographicSize / ratio;
			transform.localScale = rescaledSize;
		}

	}
}
