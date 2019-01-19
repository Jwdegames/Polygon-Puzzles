using UnityEngine;
using System.Collections;

public class AIManager : MonoBehaviour {

	public static AIManager instance = null;   //Static instance of GameManager which allows it to be accessed by any other script.
	public GameObject gameManager;
	public GameManager gameManagerScript;
	public int direction;
	public int yellowOrgMax;
	public int yellowTarMax;
	public int orangeOrgMax;
	public int orangeTarMax;
	public GameObject yellowOrg;
	public GameObject yellowTar;
	public GameObject orangeOrg;
	public GameObject orangeTar;
	public bool yellowVertical = false;
	public bool orangeHorizantal = false;
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void blueDecision () {
		direction = Random.Range (1, 5);
		if (direction == 1) {
			gameManagerScript.sendDirectionBlue = "up";
		}
		if (direction == 2) {
			gameManagerScript.sendDirectionBlue = "left";
		}
		if (direction == 3) {
			gameManagerScript.sendDirectionBlue = "down";
		}
		if (direction == 4) {
			gameManagerScript.sendDirectionBlue = "right";
		}
	}
	public void yellowDecision () {
		yellowOrgMax = gameManagerScript.ShapelistYellow.Count;
		yellowOrg = gameManagerScript.ShapelistYellow [Random.Range(0, yellowOrgMax)];
		yellowTarMax = gameManagerScript.Shapelist.Count;
		yellowTar = gameManagerScript.Shapelist[Random.Range (0, yellowTarMax)];
		if (yellowOrg.transform.position.y < yellowTar.transform.position.y && yellowVertical == false) {
			gameManagerScript.sendDirectionYellow = "up";
			yellowVertical = true;
		} else if (yellowOrg.transform.position.y > yellowTar.transform.position.y && yellowVertical == false) {
			gameManagerScript.sendDirectionYellow = "down";
			yellowVertical = true;
		}
		else if (yellowOrg.transform.position.x < yellowTar.transform.position.x) {
			gameManagerScript.sendDirectionYellow = "right";
			yellowVertical = false;
		}
		else if (yellowOrg.transform.position.x > yellowTar.transform.position.x) {
			gameManagerScript.sendDirectionYellow = "left";
			yellowVertical = false;
		}
}
	public void yellowStorm () {
		if (Random.Range (1, 3) == 2 || gameManagerScript.Shapelistblue.Count == 0) {
			yellowTarMax = gameManagerScript.Shapelist.Count;
			yellowTar = gameManagerScript.Shapelist [Random.Range (0, yellowTarMax)];
		} else {
			yellowTarMax = gameManagerScript.Shapelistblue.Count;
			yellowTar = gameManagerScript.Shapelistblue [Random.Range (0, yellowTarMax)];
		}
		yellowTar.GetComponent<ShapeIdentifier> ().yellowStorm ();
	}
	public void orangeDecision() {
		orangeOrgMax = gameManagerScript.ShapelistOrange.Count;
		orangeOrg = gameManagerScript.ShapelistOrange [Random.Range(0, orangeOrgMax)];
		orangeTarMax = gameManagerScript.Shapelist.Count;
		orangeTar = gameManagerScript.Shapelist[Random.Range (0, orangeTarMax)];
		if (orangeOrg.transform.position.x < orangeTar.transform.position.x && orangeHorizantal == false) {
			gameManagerScript.sendDirectionOrange = "right";
			orangeHorizantal = true;
		} else if (orangeOrg.transform.position.x > orangeTar.transform.position.x && orangeHorizantal == false) {
			gameManagerScript.sendDirectionOrange = "left";
			orangeHorizantal = true;
		}
		else if (orangeOrg.transform.position.y < orangeTar.transform.position.y) {
			gameManagerScript.sendDirectionOrange = "up";
			orangeHorizantal = false;
		}
		else if (orangeOrg.transform.position.y > orangeTar.transform.position.y) {
			gameManagerScript.sendDirectionOrange = "down";
			orangeHorizantal = false;
		}
	}
	public void orangeFire () {
			if (Random.Range (1,4) == 2 && gameManagerScript.ShapelistYellow.Count != 0) {
				orangeTarMax = gameManagerScript.ShapelistYellow.Count;
				orangeTar = gameManagerScript.ShapelistYellow [Random.Range (0, orangeTarMax)];
			}
			else if (Random.Range (1,3) == 2 && gameManagerScript.Shapelistblue.Count != 0) {
			orangeTarMax = gameManagerScript.Shapelistblue.Count;
			orangeTar = gameManagerScript.Shapelistblue [Random.Range (0, orangeTarMax)];
			}
			else {
			orangeTarMax = gameManagerScript.Shapelist.Count;
			orangeTar = gameManagerScript.Shapelist[Random.Range (0, orangeTarMax)];
			}
		orangeTar.GetComponent<ShapeIdentifier> ().orangeFire (0);
	}
	public void orangeScare () {
		if (Random.Range (1,4) == 2 && gameManagerScript.ShapelistYellow.Count != 0) {
			orangeTarMax = gameManagerScript.ShapelistYellow.Count;
			orangeTar = gameManagerScript.ShapelistYellow [Random.Range (0, orangeTarMax)];
		}
		else if (Random.Range (1,3) == 2 && gameManagerScript.Shapelistblue.Count != 0) {
			orangeTarMax = gameManagerScript.Shapelistblue.Count;
			orangeTar = gameManagerScript.Shapelistblue [Random.Range (0, orangeTarMax)];
		}
		else {
			orangeTarMax = gameManagerScript.Shapelist.Count;
			orangeTar = gameManagerScript.Shapelist[Random.Range (0, orangeTarMax)];
		}
		orangeTar.GetComponent<ShapeIdentifier> ().orangeScare (0);
	}
}