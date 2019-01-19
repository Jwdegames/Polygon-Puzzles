using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public static Camera instance = null;   //Static instance of GameManager which allows it to be accessed by any other script.
	public GameObject gameManager;
	public GameManager gameManagerScript;
	public float speed = 5f;
	public float maxHeight;
	public float maxLength;
	public float minHeight;
	public float minLength;
	public float minOrtho = 1f;
	public float maxOrtho = 10f;
	public float d;
	public float defaultOrtho = 6f;
	public UnityEngine.Camera theMainCamera;
	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			
			//if not, set instance to this
			instance = this;
		
		//If instance already exists and it's not this:
		else if (instance != this)
			
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);
	}
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		gameManagerScript = gameManager.GetComponent<GameManager>();
		theMainCamera = gameObject.GetComponent<UnityEngine.Camera> ();
	}

	// Update is called once per frame
	void Update () {
		if (gameManagerScript.isNormalLevel) {
			// Set the size of the camera by scrolling
			d = Input.GetAxis ("Mouse ScrollWheel");
			if (theMainCamera.orthographicSize - d <= maxOrtho && theMainCamera.orthographicSize - d >= minOrtho) {
				if (d < 0f) {
					theMainCamera.orthographicSize -= d;
				} else if (d > 0f) {
					theMainCamera.orthographicSize -= d;
				}
			}
		} else {
			theMainCamera.orthographicSize = defaultOrtho;
		}
	if (gameManagerScript.isCameraLocation1) {

		} else if (gameManagerScript.isCameraLocation2) {
			maxHeight = transform.position.y + 10f;
			maxLength = transform.position.x + 10f;
			minHeight = transform.position.y - 10f;
			minLength = transform.position.x - 10f;
			if  (gameManagerScript.isNormalLevel) {
			if (Input.GetKey (KeyCode.W)) {
				if (maxHeight >= transform.position.y) {
					transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
				}
			}
				if (Input.GetKey (KeyCode.D)) {
					if (maxLength >= transform.position.x) {
						transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
					}
				}
					if (Input.GetKey (KeyCode.S)) {
						if (minHeight <= transform.position.y) {
							transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
						}
					}
						if (Input.GetKey (KeyCode.A)) {
							if (minLength <= transform.position.x) {
								transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
							}
						}
			}
		} else if (gameManagerScript.isCameraLocation3) {

		}
	}
}
