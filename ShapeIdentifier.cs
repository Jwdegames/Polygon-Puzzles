using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;

public class ShapeIdentifier : MonoBehaviour {

	public GameObject polyFace;
	public GameObject polyFace2;
	public GameObject polyFace3;
	public GameObject polyFace4;
	public GameObject polyFace5;
	public GameObject polyFace6;
	public GameObject polyFace7;
	public GameObject polyFace8;
	public GameObject polyFaceExtra;
	public GameObject polyFaceExtra2;
	public GameObject polyFaceExtra3;
	public GameObject polyFaceExtra4;
	public GameObject polyFacePrefab;
	public GameObject polyFaceRecieved;
	public GameObject defense;
	public GameObject parenthesisPrefab;
	public GameObject bracketPrefab;
	public GameObject dRingPrefab;
	public GameObject acidPrefab;
	public GameObject yellowStormPrefab;
	public GameObject gameManager;
	public GameObject acid;
	public GameObject yellowStorm1;
	public GameObject orangeFire1;
	public GameObject radioPolyFace;
	public GameObject shieldStructurePrefab;
	public GameObject shieldStructure;
	public GameObject orangeScare1;
	public GameManager gameManagerScript;
	public Parenthesis parenthesisScript;
	public Bracket bracketScript;
	public DRing dRingScript;
	public FaceScript polyScript;
	public FaceScript polyScript2;
	public FaceScript polyScript3;
	public FaceScript polyScript4;
	public FaceScript polyScript5;
	public FaceScript polyScript6;
	public FaceScript polyScript7;
	public FaceScript polyScript8;
	public FaceScript polyFaceScript;
	public string colorToChange;
	public float strength = 0;
	public int shapeType = 0;
	public int lastTurn;
	public int acidEffect;
	public int fireEffect;
	public int i;
	public int scareEffect;
	public string shape = "square";
	public string color = "white";
	public string pointedDirection = "null";
	public string direction;
	public bool sendFace = false;
	public bool leftEdge = false;
	public bool topEdge = false;
	public bool rightEdge = false;
	public bool bottomEdged = false;
	public bool boardCreated = false;
    public bool canSend = true;
	public bool scared = false;
	// Use this for initialization
	void Start () {
		lastTurn = 0;
		//Debug.Log (gameObject.transform.eulerAngles);
		gameManager = GameObject.Find ("GameManager");
		gameManagerScript = gameManager.GetComponent<GameManager> ();
		if (shape != "invis") {
			PolygonCollider2D thisPolygon = gameObject.AddComponent<PolygonCollider2D> () as PolygonCollider2D; //Make a polygon collider
			thisPolygon.isTrigger = true; //Make the collider a trigger
		}
		if (shape == "pentagon" || shape == "heptagon" || shape == "star") { //Certain sprites are rotated in different ways, so set the type of rotation.
			shapeType = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (shape == "receiver") {
			if (gameManagerScript.polyFaceYellowRadio != null && color == "yellow") {
				for (i = 0; i < gameManagerScript.polyFaceYellowRadio.Count; i++) {
					if (gameManagerScript.polyFaceYellowRadio [i] != null) {
						//Debug.LogError("HELP!");
					radioPolyFace = Instantiate (gameManagerScript.polyFaceYellowRadio [i], transform.position, Quaternion.identity) as GameObject;
						radioPolyFace.GetComponent<FaceScript>().selfDestruct = false;
					}
				}
				if (i == gameManagerScript.polyFaceYellowRadio.Count && radioPolyFace != null) {
					//Debug.LogError  (radioPolyFace.name);
					if (!gameManagerScript.polyReceiverYellowFinished.Contains(this)) {
					gameManagerScript.polyReceiverYellowFinished.Add(this);
					}
				}
			}
			if (gameManagerScript.polyFaceGreenRadio != null && color == "green") {
				for (i = 0; i < gameManagerScript.polyFaceGreenRadio.Count; i++) {
					if (gameManagerScript.polyFaceGreenRadio [i] != null) {
						//Debug.LogError("HELP!");
					radioPolyFace = Instantiate (gameManagerScript.polyFaceGreenRadio [i], transform.position, Quaternion.identity) as GameObject;
						radioPolyFace.GetComponent<FaceScript>().selfDestruct = false;
					}
				}
				if (i == gameManagerScript.polyFaceGreenRadio.Count && radioPolyFace != null) {
					//Debug.LogError  (radioPolyFace.name);
					if (!gameManagerScript.polyReceiverGreenFinished.Contains(this)) {
					gameManagerScript.polyReceiverGreenFinished.Add(this);
					}
				}
			}
				if (gameManagerScript.polyFaceBlueRadio != null && color == "blue") {
				for (i = 0; i < gameManagerScript.polyFaceBlueRadio.Count; i++) {
					if (gameManagerScript.polyFaceBlueRadio [i] != null) {
						//Debug.LogError("HELP!");
					radioPolyFace = Instantiate (gameManagerScript.polyFaceBlueRadio [i], transform.position, Quaternion.identity) as GameObject;
						radioPolyFace.GetComponent<FaceScript>().selfDestruct = false;
					}
				}
				if (i == gameManagerScript.polyFaceBlueRadio.Count && radioPolyFace != null) {
					//Debug.LogError (radioPolyFace.name);
					if (!gameManagerScript.polyReceiverBlueFinished.Contains(this)) {
					gameManagerScript.polyReceiverBlueFinished.Add(this);
					}
				}
			}
			if (gameManagerScript.polyFaceOrangeRadio != null && color == "orange") {
				for (i = 0; i < gameManagerScript.polyFaceOrangeRadio.Count; i++) {
					if (gameManagerScript.polyFaceOrangeRadio [i] != null) {
						//Debug.LogError("HELP!");
						radioPolyFace = Instantiate (gameManagerScript.polyFaceOrangeRadio [i], transform.position, Quaternion.identity) as GameObject;
						radioPolyFace.GetComponent<FaceScript>().selfDestruct = false;
					}
				}
				if (i == gameManagerScript.polyFaceOrangeRadio.Count && radioPolyFace != null) {
					//Debug.LogError (radioPolyFace.name);
					if (!gameManagerScript.polyReceiverOrangeFinished.Contains(this)) {
						gameManagerScript.polyReceiverOrangeFinished.Add(this);
					}
				}
			}
		}
			if (gameManagerScript.turnCounter != lastTurn) {
			if (gameManagerScript.activateGreenRegen == true && color == "green" && gameManagerScript.turnCounter % 5 == 0) {
				strength += 1;
			}
			if (acidEffect > 0) {
				if (color == "green") {
					strength += 1;
				}
				else {
					if (strength == 0) {
						color = "green";
					}
					else {
						strength -= 1;
					}
				}
				acidEffect -= 1;
			}
			if (fireEffect > 0) {
				if (color == "orange") {
					fireEffect = 0;
					Destroy (orangeFire1);
				}
				else {
					if (strength <= 0) {
						color = "orange";
						fireEffect = 0;
						Destroy (orangeFire1);
					}
					else {
						strength -=1;
						if (strength <= 0) {
							color = "orange";
							fireEffect = 0;
							Destroy (orangeFire1);
						}
					}
					if (Random.Range (1, (12 - gameManagerScript.orangeFireSpread)) == 2) {
						polyFaceExtra = Instantiate (gameManagerScript.invisPolyFacePrefab, transform.position, Quaternion.identity) as GameObject;
						polyFaceExtra.GetComponent<FaceScript>().direction = "left";
						polyFaceExtra.GetComponent<FaceScript>().continueFire = true;
						polyFaceExtra.GetComponent<FaceScript>().fireLife = fireEffect;
					}
					if (Random.Range (1, (12 - gameManagerScript.orangeFireSpread)) == 2) {
						polyFaceExtra2 = Instantiate (gameManagerScript.invisPolyFacePrefab, transform.position, Quaternion.identity) as GameObject;
						polyFaceExtra2.GetComponent<FaceScript>().direction = "right";
						polyFaceExtra2.GetComponent<FaceScript>().continueFire = true;
						polyFaceExtra2.GetComponent<FaceScript>().fireLife = fireEffect;
					}
					if (Random.Range (1, (12 - gameManagerScript.orangeFireSpread)) == 2) {
						polyFaceExtra3 = Instantiate (gameManagerScript.invisPolyFacePrefab, transform.position, Quaternion.identity) as GameObject;
						polyFaceExtra3.GetComponent<FaceScript>().direction = "up";
						polyFaceExtra3.GetComponent<FaceScript>().continueFire = true;
						polyFaceExtra3.GetComponent<FaceScript>().fireLife = fireEffect;
					}
					if (Random.Range (1, (12 - gameManagerScript.orangeFireSpread)) == 2) {
						polyFaceExtra4 = Instantiate (gameManagerScript.invisPolyFacePrefab, transform.position, Quaternion.identity) as GameObject;
						polyFaceExtra4.GetComponent<FaceScript>().direction = "down";
						polyFaceExtra4.GetComponent<FaceScript>().continueFire = true;
						polyFaceExtra4.GetComponent<FaceScript>().fireLife = fireEffect;
					}
					fireEffect -= 1;
					if (fireEffect <= 0) {
						fireEffect = 0;
						Destroy (orangeFire1);
					}
				}
			}
			if (scareEffect > 0) {
				scareEffect -= 1;
				if (scareEffect <= 0) {
					scared = false;
					Destroy (orangeScare1);
				}
			}
			else {
				Destroy (orangeFire1);
				fireEffect = 0;
			}
			defenseCreation();
			lastTurn = gameManagerScript.turnCounter;
		}
		if (gameObject.transform.rotation.eulerAngles.z == 0) { //Determine the pointed direction of a polygon
			if (shapeType == 0) {
				pointedDirection = "left";
			} else if (shapeType == 1) {
				pointedDirection = "up";
				//Debug.Log (shapeType);
			}
		}
		if (Mathf.Round (gameObject.transform.rotation.eulerAngles.z) == 90) {
			if (shapeType == 0) {
				pointedDirection = "down";
			} else if (shapeType == 1) {
				pointedDirection = "left";
			}
		}
		if (Mathf.Round (gameObject.transform.rotation.eulerAngles.z) == 180) {
			if (shapeType == 0) {
				pointedDirection = "right";
			} else if (shapeType == 1) {
				pointedDirection = "down";
			}
		}
		if (gameObject.transform.rotation.eulerAngles.z == 270 || gameObject.transform.rotation.eulerAngles.z == -90) {
			if (shapeType == 0) {
				pointedDirection = "up";
			} else if (shapeType == 1) {
				pointedDirection = "right";
			}
		}
		if (color == "white") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (1f, 1f, 1f, 1f); // Set to opaque white
		}
		if (color == "green") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (0f, 1f, 0f, 1f); // Set to opaque green
			gameObject.layer = LayerMask.NameToLayer ("Green");
		}
		if (color == "blue") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (0f, 0f, 1f, 1f); // Set to opaque blue
			gameObject.layer = LayerMask.NameToLayer ("Blue");
		}
		if (color == "yellow") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (1f, 0.92f, 0.016f, 1f); // Set to opaque yellow
			gameObject.layer = LayerMask.NameToLayer ("Yellow");
		}
		if (color == "orange") {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();//Get the renderer via GetComponent or have it cached previously
			renderer.color = new Color (1f, 0.43f, 0f, 1f); // Set to opaque yellow
			gameObject.layer = LayerMask.NameToLayer ("Orange");
		}
		if (sendFace == true && scared == false && canSend) {
			if (shape == "square") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = direction;
				polyScript.color = color;
				sendFace = false;
			} else if (shape == "triangle") {
				if (pointedDirection == direction) {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = direction;
					polyScript.color = color;
					sendFace = false;
				}
			} else if (shape == "pentagon") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = direction;
				polyScript.color = color;

				if (pointedDirection != direction) {
					polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript2 = polyFace2.GetComponent<FaceScript> ();
					polyScript2.direction = pointedDirection;
					polyScript2.color = color;
					sendFace = false;
				} else {
					Debug.Log ("The pointed direction is " + pointedDirection + " and the send direction is " + direction);
					sendFace = false;
				}
			} else if (shape == "double triangle") {
				if (pointedDirection == direction) {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = direction;
					polyScript.color = color;
					polyScript.strength = 2;
					sendFace = false;
				}
			}
			else if (shape == "hexagon") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = direction;
				polyScript.color = color;
				polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript2 = polyFace2.GetComponent<FaceScript> ();
				polyScript2.color = color;
				sendFace = false;
				if (direction == "up") {
				polyScript2.direction = "down";
				}
				if (direction == "right") {
					polyScript2.direction = "left";
				}

				if (direction == "down") {
					polyScript2.direction = "up";
				}

				if (direction == "left") {
					polyScript2.direction = "right";
				}


			}
			else if (shape == "heptagon") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = direction;
				polyScript.color = color;
				
				if (pointedDirection != direction) {
					polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript2 = polyFace2.GetComponent<FaceScript> ();
					polyScript2.direction = pointedDirection;
					polyScript2.color = color;
					polyScript2.strength = 2;
					sendFace = false;
				} else {
					polyScript.strength = 2;
					Debug.Log ("The pointed direction is " + pointedDirection + " and the send direction is " + direction);
					sendFace = false;
				}
			}
			else if (shape == "octagon") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = direction;
				polyScript.color = color;
				polyScript.strength = 2;
				polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript2 = polyFace2.GetComponent<FaceScript> ();
				polyScript2.color = color;
				polyScript2.strength = 2;
				sendFace = false;
				if (direction == "up") {
					polyScript2.direction = "down";
				}
				if (direction == "right") {
					polyScript2.direction = "left";
				}
				
				if (direction == "down") {
					polyScript2.direction = "up";
				}
				
				if (direction == "left") {
					polyScript2.direction = "right";
				}
			}
			else if (shape == "boss_square") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = direction;
				polyScript.color = color;
				polyScript.strength = 4;
				sendFace = false;
			}
			else if (shape == "decagon") {
				polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript2 = polyFace2.GetComponent<FaceScript> ();
				polyScript2.color = color;
				polyScript2.strength = 2;
				polyFace3 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript3 = polyFace3.GetComponent<FaceScript> ();
				polyScript3.color = color;
				polyScript3.strength = 2;
				if (pointedDirection == "left" || pointedDirection == "right") {
					polyScript2.direction = "left";
					polyScript3.direction = "right";
					if (direction != "left" && direction != "right") {
						polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
						polyScript = polyFace.GetComponent<FaceScript> ();
						polyScript.direction = direction;
						polyScript.color = color;
					}
				}
				if (pointedDirection == "up" || pointedDirection == "down") {
					polyScript2.direction = "up";
					polyScript3.direction = "down";
					if (direction != "up" && direction != "down") {
						polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
						polyScript = polyFace.GetComponent<FaceScript> ();
						polyScript.direction = direction;
						polyScript.color = color;

					}
				}
				sendFace = false;
			}
			else if (shape == "dodecagon") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = direction;
				polyScript.color = color;
				polyScript.strength = 3;
				polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript2 = polyFace2.GetComponent<FaceScript> ();
				polyScript2.color = color;
				polyScript2.strength = 3;
				sendFace = false;
				if (direction == "up") {
					polyScript2.direction = "down";
				}
				if (direction == "right") {
					polyScript2.direction = "left";
				}
				
				if (direction == "down") {
					polyScript2.direction = "up";
				}
				
				if (direction == "left") {
					polyScript2.direction = "right";
				}
			}
			else if (shape =="max_triangle") {
				if (pointedDirection == direction) {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = direction;
					polyScript.color = color;
					polyScript.indestructible = true;
					sendFace = false;
				}
			}
			else if (shape == "circle") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = "up";
				polyScript.color = color;
				polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript2 = polyFace2.GetComponent<FaceScript> ();
				polyScript2.direction = "down";
				polyScript2.color = color;
				polyFace3 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript3 = polyFace3.GetComponent<FaceScript> ();
				polyScript3.direction = "right";
				polyScript3.color = color;
				polyFace4 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript4 = polyFace4.GetComponent<FaceScript> ();
				polyScript4.direction = "left";
				polyScript4.color = color;
				sendFace = false;
			}
			else if (shape =="super_circle") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = "up";
				polyScript.color = color;
				polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript2 = polyFace2.GetComponent<FaceScript> ();
				polyScript2.direction = "down";
				polyScript2.color = color;
				polyFace3 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript3 = polyFace3.GetComponent<FaceScript> ();
				polyScript3.direction = "right";
				polyScript3.color = color;
				polyFace4 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript4 = polyFace4.GetComponent<FaceScript> ();
				polyScript4.direction = "left";
				polyScript4.color = color;
				polyFace5 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript5 = polyFace5.GetComponent<FaceScript> ();
				polyScript5.direction = "upleft";
				polyScript5.color = color;
				polyFace6 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript6 = polyFace6.GetComponent<FaceScript> ();
				polyScript6.direction = "downleft";
				polyScript6.color = color;
				polyFace7 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript7 = polyFace7.GetComponent<FaceScript> ();
				polyScript7.direction = "upright";
				polyScript7.color = color;
				polyFace8 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript8 = polyFace8.GetComponent<FaceScript> ();
				polyScript8.direction = "downright";
				polyScript8.color = color;
				sendFace = false;
			}
			else if (shape == "star") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = "upleft";
				polyScript.color = color;
				polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript2 = polyFace2.GetComponent<FaceScript> ();
				polyScript2.direction = "downleft";
				polyScript2.color = color;
				polyFace3 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript3 = polyFace3.GetComponent<FaceScript> ();
				polyScript3.direction = "upright";
				polyScript3.color = color;
				polyFace4 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript4 = polyFace4.GetComponent<FaceScript> ();
				polyScript4.direction = "downright";
				polyScript4.color = color;
				polyFace5 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript5 = polyFace5.GetComponent<FaceScript> ();
				polyScript5.direction = pointedDirection;
				polyScript5.color = color;
				sendFace = false;
			}
			else if (shape == "shield") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = direction;
				polyScript.color = color;
				polyScript.generateShield = true;
				sendFace = false;
			}
			else if (shape == "cut_circle") {
				if (pointedDirection == "up") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = "up";
				polyScript.color = color;
				polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript2 = polyFace2.GetComponent<FaceScript> ();
				polyScript2.direction = "left";
				polyScript2.color = color;
				polyFace3 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript3 = polyFace3.GetComponent<FaceScript> ();
				polyScript3.direction = "right";
				polyScript3.color = color;
				}
				else if (pointedDirection == "down") {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = "down";
					polyScript.color = color;
					polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript2 = polyFace2.GetComponent<FaceScript> ();
					polyScript2.direction = "left";
					polyScript2.color = color;
					polyFace3 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript3 = polyFace3.GetComponent<FaceScript> ();
					polyScript3.direction = "right";
					polyScript3.color = color;
				}
				else if (pointedDirection == "right") {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = "up";
					polyScript.color = color;
					polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript2 = polyFace2.GetComponent<FaceScript> ();
					polyScript2.direction = "down";
					polyScript2.color = color;
					polyFace3 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript3 = polyFace3.GetComponent<FaceScript> ();
					polyScript3.direction = "right";
					polyScript3.color = color;
				}
				else if (pointedDirection == "left") {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = "up";
					polyScript.color = color;
					polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript2 = polyFace2.GetComponent<FaceScript> ();
					polyScript2.direction = "down";
					polyScript2.color = color;
					polyFace3 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript3 = polyFace3.GetComponent<FaceScript> ();
					polyScript3.direction = "left";
					polyScript3.color = color;
				}
				sendFace = false;
			}
			else if (shape == "l") {
				if (pointedDirection == "up") {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = "down";
					polyScript.color = color;
					polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript2 = polyFace2.GetComponent<FaceScript> ();
					polyScript2.direction = "left";
					polyScript2.color = color;
				}
				else if (pointedDirection == "down") {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = "up";
					polyScript.color = color;
					polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript2 = polyFace2.GetComponent<FaceScript> ();
					polyScript2.direction = "right";
					polyScript2.color = color;
				}
				else if (pointedDirection == "right") {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = "up";
					polyScript.color = color;
					polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript2 = polyFace2.GetComponent<FaceScript> ();
					polyScript2.direction = "left";
					polyScript2.color = color;
				}
				else if (pointedDirection == "left") {
					polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript = polyFace.GetComponent<FaceScript> ();
					polyScript.direction = "right";
					polyScript.color = color;
					polyFace2 = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
					polyScript2 = polyFace2.GetComponent<FaceScript> ();
					polyScript2.direction = "down";
					polyScript2.color = color;
				}
				sendFace = false;
			}
			else if (shape == "big_boss_square") {
				polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
				polyScript = polyFace.GetComponent<FaceScript> ();
				polyScript.direction = direction;
				polyScript.color = color;
				polyScript.strength = 9;
				sendFace = false;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.gameObject.name + " has entered!");
		if (other.gameObject == acid) {
			//Debug.Log("Acid found!");
			acidEffect += 2;
			Destroy (other.gameObject);
		}
		if (other.gameObject.GetComponent<FaceScript> () != null) { //Deletes polyfaces and determines strength and color.
			Debug.Log (other.name);
			polyFaceRecieved = other.gameObject;
			polyFaceScript = polyFaceRecieved.GetComponent<FaceScript> ();
			colorToChange = polyFaceScript.color;
			if (polyFaceRecieved != polyFace) {
				if (polyFaceRecieved != polyFace2) {
					if (polyFaceRecieved != polyFace3) {
						if (polyFaceRecieved != polyFace4) {
							if (polyFaceRecieved != polyFace5) {
								if (polyFaceRecieved != polyFace6) {
									if (polyFaceRecieved != polyFace7) {
										if (polyFaceRecieved != polyFace8) {
											if (polyFaceRecieved != radioPolyFace) {
												if (polyFaceRecieved != polyFaceExtra) {
													if (polyFaceRecieved != polyFaceExtra2) {
														if (polyFaceRecieved != polyFaceExtra3) {
															if (polyFaceRecieved != polyFaceExtra4) {
																if (polyFaceScript.continueFire) {
																	this.orangeFire(polyFaceScript.fireLife);
																}
												if (color != colorToChange && polyFaceScript.invis != true) {

													strength -= (polyFaceScript.strength + 0);

												} else {
													if (polyFaceScript.generateShield) {
														shieldStructureCreation ();
													}
														if (strength <= 2 && polyFaceScript.invis == false) {
														strength += 1;
													}
												}
												if (strength < 0) {
													if (shape == "canceler") {
														polyFace = Instantiate (polyFacePrefab, transform.position, Quaternion.identity) as GameObject; //Instansiate the poly face
														polyScript = polyFace.GetComponent<FaceScript> ();
														if (polyFaceScript.direction == "left") {
															polyScript.direction = "right";
														}
														if (polyFaceScript.direction == "right") {
															polyScript.direction = "left";
														}
														if (polyFaceScript.direction == "up") {
															polyScript.direction = "down";
														}
														if (polyFaceScript.direction == "down") {
															polyScript.direction = "up";
														}
														if (polyFaceScript.direction == "upleft") {
															polyScript.direction = "downright";
														}
														if (polyFaceScript.direction == "downleft") {
															polyScript.direction = "upright";
														}
														if (polyFaceScript.direction == "upright") {
															polyScript.direction = "downleft";					
														}
														if (polyFaceScript.direction == "downright") {
															polyScript.direction = "upleft";					
														}
														polyScript.color = color;
													}
													color = colorToChange;
													strength = 0;
												}
												if (strength == 1) {
													if (defense != null) {
														Destroy (defense, 0f);
													}
													defense = Instantiate (parenthesisPrefab, transform.position, Quaternion.identity) as GameObject;
													parenthesisScript = defense.GetComponent<Parenthesis> ();
													parenthesisScript.color = color;
													parenthesisScript.size = transform.localScale.x / 2;
												} else if (strength == 2) {
													if (defense != null) {
														Destroy (defense, 0f);
													}
													defense = Instantiate (bracketPrefab, transform.position, Quaternion.identity) as GameObject;
													bracketScript = defense.GetComponent<Bracket> ();
													bracketScript.color = color;
													bracketScript.size = transform.localScale.x / 2;
												} else if (strength == 3) {
													if (defense != null) {
														Destroy (defense, 0f);
													}
													defense = Instantiate (dRingPrefab, transform.position, Quaternion.identity) as GameObject;
													dRingScript = defense.GetComponent<DRing> ();
													dRingScript.color = color;
													dRingScript.size = transform.localScale.x / 2;
													//Debug.LogError ("Made Defense!");
												} else {
													if (defense != null) {
														Destroy (defense, 0f);
													}
												}
												if (polyFaceScript.indestructible == false && shape != "sender") { // Destroy the polyface if it's not needed
													if ((polyFaceScript.strength) <= 1) {
														Destroy (other.gameObject);
														//Debug.Log("Destroying GameObject!");
													} else {
														if (color != colorToChange) {
															polyFaceScript.strength -= (strength + 1);
															if (polyFaceScript.strength <= 0) {
																Destroy (other.gameObject);
															}
														} else {
															polyFaceScript.strength -= 1;
															if (polyFaceScript.strength <= 0) {
																Destroy (other.gameObject);
															}
														}
													}

												} else if (shape == "sender") {
								
													if (polyFaceScript.color == "green" && color == "green") {
														gameManagerScript.polyFaceGreenRadio.Add (polyFaceRecieved);
														//Debug.Log("Adding Green shape to the radio.");
														if (gameManagerScript.polyFaceGreenRadio.Contains (polyFaceRecieved)) {
															polyFaceScript.selfDestruct = true;
														}
													}
													if (polyFaceScript.color == "blue" && color == "blue") {
														gameManagerScript.polyFaceBlueRadio.Add (polyFaceRecieved);
														//Debug.Log("Adding Blue shape to the radio.");
														if (gameManagerScript.polyFaceBlueRadio.Contains (polyFaceRecieved)) {
															polyFaceScript.selfDestruct = true;
														}
										

													}
													if (polyFaceScript.color == "yellow" && color == "yellow") {
														gameManagerScript.polyFaceYellowRadio.Add (polyFaceRecieved);
														//Debug.Log("Adding Yellow shape to the radio.");
														if (gameManagerScript.polyFaceYellowRadio.Contains (polyFaceRecieved)) {
															polyFaceScript.selfDestruct = true;
														}
																	}
														if (polyFaceScript.color == "orange" && color == "orange") {
															gameManagerScript.polyFaceOrangeRadio.Add (polyFaceRecieved);

															//Debug.Log("Adding Orange shape to the radio.");
															if (gameManagerScript.polyFaceOrangeRadio.Contains (polyFaceRecieved)) {
																polyFaceScript.selfDestruct = true;
															}
																		}
																		//Debug.Log ("The face's color is "+polyFaceScript.color+" and the sender's color is "+color);
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}

		}
	}
	void OnMouseDown() {
		if (gameManagerScript.turnCounter >= 2 && gameManagerScript.currentAbility == 1) {
			if (gameManagerScript.lastTurnOne == null || (gameManagerScript.turnCounter - gameManagerScript.lastTurnOne) >= 2) {
				if (gameManagerScript.currentLevel > 5) {
					acid = Instantiate (acidPrefab, new Vector3 (transform.position.x, transform.position.y + 3f, -2), Quaternion.identity) as GameObject;
					gameManagerScript.lastTurnOne = gameManagerScript.turnCounter;
				}
			} else {

			}
		} else if (gameManagerScript.turnCounter >= 3 && gameManagerScript.currentAbility == 2 && color == "green" && gameManagerScript.currentLevel > 10) {
			if (gameManagerScript.lastTurnTwo == null || (gameManagerScript.turnCounter - gameManagerScript.lastTurnTwo) >= 3) {
				shieldStructure = Instantiate (shieldStructurePrefab, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
				gameManagerScript.lastTurnTwo = gameManagerScript.turnCounter;
				shieldStructure.GetComponent<ShieldStructure> ().size = transform.localScale.x / 2;
			}
		}
	}
	void defenseCreation() {
		if (strength == 1) {
			if (defense != null) {
				Destroy (defense, 0f);
			}
			defense = Instantiate (parenthesisPrefab, transform.position, Quaternion.identity) as GameObject;
			parenthesisScript = defense.GetComponent<Parenthesis>();
			parenthesisScript.color = color;
			parenthesisScript.size = transform.localScale.x/2;
		}
		else if (strength == 2) {
			if (defense != null) {
				Destroy (defense, 0f);
			}
			defense = Instantiate (bracketPrefab, transform.position, Quaternion.identity) as GameObject;
			bracketScript = defense.GetComponent<Bracket>();
			bracketScript.color = color;
			bracketScript.size = transform.localScale.x/2;
		}
		else if (strength == 3) {
			if (defense != null) {
				Destroy (defense, 0f);
			}
			defense = Instantiate (dRingPrefab, transform.position, Quaternion.identity) as GameObject;
			dRingScript = defense.GetComponent<DRing>();
			dRingScript.color = color;
			dRingScript.size = transform.localScale.x/2;
			//Debug.LogError ("Made Defense!");
		}
		else {
			if (defense != null) {
				//Debug.Log ("Destroying" +defense +" "+ gameObject.name);
				Destroy (defense, 0f);
			}
		}
	}
	public void yellowStorm () {
		yellowStorm1 = Instantiate (yellowStormPrefab, new Vector3(transform.position.x+ 1f, transform.position.y + 1f, -2), Quaternion.identity) as GameObject;
		yellowStorm1.GetComponent<yellowStorm> ().creator = this.gameObject;
	}
	public void shieldStructureCreation () {
		if (color == "green") {
			shieldStructure = Instantiate (shieldStructurePrefab, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
			shieldStructure.GetComponent<ShieldStructure> ().size = transform.localScale.x / 2;
		}
	}
	public void orangeFire(int fireActual) {
		orangeFire1 = Instantiate (gameManagerScript.orangeFirePrefab, transform.position, Quaternion.identity) as GameObject;
		if (fireActual == 0) {
			fireEffect = gameManagerScript.orangeFireLife + 1;
			fireActual = 0;
		} else {
			fireEffect = fireActual;
		}
		GameObject.Find ("AudioManager").GetComponent<AudioManager> ().playSoundEffect (2);
}
	public void orangeScare(int scareActual) {
		orangeScare1 = Instantiate (gameManagerScript.orangeScarePrefab, transform.position, Quaternion.identity) as GameObject;
		orangeScare1.GetComponent<orangeScare> ().size = transform.localScale.x;
		scareEffect = 2;
		scared = true;
	}
}