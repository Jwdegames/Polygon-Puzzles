using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;   //Static instance of GameManager which allows it to be accessed by any other script.
	public AIManager aiManagerScript;
	public BoardManager boardManagerScript;
	public List<ShapeIdentifier> Shapearray;
	public List<GameObject> Shapelist = new List<GameObject>();
	public List<ShapeIdentifier> CurrentShapes = new List<ShapeIdentifier>(); 
	public List<GameObject> Shapelistblue = new List<GameObject>();
	public List<ShapeIdentifier> CurrentShapesBlue = new List<ShapeIdentifier>();
	public List<GameObject> ShapelistYellow = new List<GameObject>();
	public List<ShapeIdentifier> CurrentShapesYellow = new List<ShapeIdentifier>();
	public List<GameObject> ShapelistOrange = new List<GameObject>();
	public List<ShapeIdentifier> CurrentShapesOrange = new List<ShapeIdentifier>();
	public List<GameObject> polyFaceGreenRadio = new List<GameObject>(); 
	public List<GameObject> polyFaceBlueRadio = new List<GameObject>(); 
	public List<GameObject> polyFaceYellowRadio = new List<GameObject>();
	public List<GameObject> polyFaceOrangeRadio = new List<GameObject>();
	public List<ShapeIdentifier> polyReceiverGreen = new List<ShapeIdentifier>();
	public List<ShapeIdentifier> polyReceiverBlue = new List<ShapeIdentifier>();
	public List<ShapeIdentifier> polyReceiverYellow = new List<ShapeIdentifier>();
	public List<ShapeIdentifier> polyReceiverOrange = new List<ShapeIdentifier>();
	public List<ShapeIdentifier> polyReceiverGreenFinished = new List<ShapeIdentifier>();
	public List<ShapeIdentifier> polyReceiverBlueFinished = new List<ShapeIdentifier>();
	public List<ShapeIdentifier> polyReceiverYellowFinished = new List<ShapeIdentifier>();
	public List<ShapeIdentifier> polyReceiverOrangeFinished = new List<ShapeIdentifier>();
	public int i = 0;
	public int j = 0;
	public int k = 0;
	public int l = 0;
	public int m = 0;
	public int currentLevel;
	public int turnCounter;
	public int lastTurnOne;
	public int lastTurnTwo;
	public int currentAbility = 1;
	public int shieldLength = 1;
	public int stage = 1;
	public int orangeFireStrength = 1;
	public int orangeFireLife = 2;
	public int orangeFireSpread = 1;
	public bool canScan = true;
	public bool scanning = false;
	public bool canTime = false;
	public bool canScanForLVLComplete = false;
	public bool activateGreenRegen = false;
	public string sendDirection;
	public string sendDirectionBlue;
	public string sendDirectionYellow;
	public string sendDirectionOrange;
	public string colorTurn;
	public string lastColor;
	public float timer = 6f;
	public float bTimer;
	public float cTimer; //Timer for checking if all necessary polygons are green.
	public float turnTimer; //Timer to prevent multiple colored polyfaces on the screen.
	public float initialTimer;
	public bool isTitleScreen = true;
	public bool isLevelSelect = false;
	public bool isNormalLevel = false;
	public bool isOptions = false;
	public bool isCodex = false;
	public bool isChangeLog = false;
	public bool isCredits = false;
	public bool doInitialLevelScan = true;
	public bool searchForLVLSelectCanvas = true;
	public bool hasLVLSelectCanvas = false;
	public bool normalLVLComplete = false;
	public bool canMoveCamera1 = true;
	public bool canMoveCamera2 = false;
	public bool canMoveCamera3 = true;
	public bool isCameraLocation1 = false;
	public bool isCameraLocation2 = true;
	public bool isCameraLocation3 = false;
	public bool isCameraLocation4 = false;
	public bool waitTurns = false;
	public bool testTime = false;
	public GameObject mainCamera;
	public GameObject aiManager;
	public GameObject playButton;
	public GameObject createButton;
	public GameObject codexButton;
	public GameObject awardsButton;
	public GameObject optionsButton;
	public GameObject creditsButton;
	public GameObject lvlOneButton;
	public GameObject lvlTwoButton;
	public GameObject lvlThreeButton;
	public GameObject lvlFourButton;
	public GameObject lvlFiveButton;
	public GameObject lvlSixButton;
	public GameObject lvlSevenButton;
	public GameObject lvlEightButton;
	public GameObject lvlNineButton;
	public GameObject lvlTenButton;
	public GameObject lvlElevenButton;
	public GameObject lvlTwelveButton;
	public GameObject lvlThirteenButton;
	public GameObject lvlFourteenButton;
	public GameObject lvlFifteenButton;
	public GameObject lvlSixteenButton;
	public GameObject lvlSeventeenButton;
	public GameObject lvlEighteenButton;
	public GameObject lvlNineteenButton;
	public GameObject lvlTwentyButton;
	public GameObject exit3Button;
	public GameObject backStageButton;
	public GameObject nextStageButton;
	public GameObject levelSelectCanvas;
	public GameObject optionsPanel;
	public GameObject changeLogPanel;
	public GameObject musicButton;
	public GameObject soundButton;
	public GameObject changeLogButton;
	public GameObject resetSaveButton;
	public GameObject exitOptionsButton;
	public GameObject maxLevelText;
	public GameObject polygonTitles;
	public GameObject temporaryTitle;
	public GameObject newTitle;
	public GameObject musicVS;
	public GameObject soundVS;
	public GameObject levelCompletePanel;
	public GameObject levelCompleteTitle;
	public GameObject retryButton;
	public GameObject nextLevelButton;
	public GameObject exit2Button;
	public GameObject creditCanvas;
	public GameObject gameCanvas;
	public GameObject orangeFirePrefab;
	public GameObject invisPolyFacePrefab;
	public GameObject orangeScarePrefab;
	public Vector3 titleLocation;
	public Vector3 startCameraLocation;
	public Vector3 temporaryCameraLocation;
	public Vector3 LVLCompleteCameraLocation;
	public Vector3 codexCameraLocation;
	public Vector3 creditCameraLocation;
	public Canvas levelSelectCanvasActual;
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
        //Set all important objects
        //PlayerPrefs.SetInt("Allowed Level", 20);
        playButton = GameObject.Find("Play Button");
		createButton = GameObject.Find("Create Button");
		codexButton = GameObject.Find("Codex Button");
		awardsButton = GameObject.Find("Awards Button");
		optionsButton = GameObject.Find("Options Button");
		creditsButton = GameObject.Find("Credits Button");
		lvlOneButton = GameObject.Find ("Level 1");
		lvlTwoButton = GameObject.Find("Level 2");
		lvlThreeButton = GameObject.Find("Level 3");
		lvlFourButton = GameObject.Find("Level 4");
		lvlFiveButton = GameObject.Find("Level 5");
		lvlSixButton = GameObject.Find("Level 6");
		lvlSevenButton = GameObject.Find("Level 7");
		lvlEightButton = GameObject.Find("Level 8");
		lvlNineButton = GameObject.Find("Level 9");
		lvlTenButton = GameObject.Find("Level 10");
		lvlElevenButton = GameObject.Find("Level 11");
		lvlTwelveButton = GameObject.Find("Level 12");
		lvlThirteenButton = GameObject.Find("Level 13");
		lvlFourteenButton = GameObject.Find("Level 14");
		lvlFifteenButton = GameObject.Find("Level 15");
		lvlSixteenButton = GameObject.Find ("Level 16");
		lvlSeventeenButton = GameObject.Find ("Level 17");
		lvlEighteenButton = GameObject.Find ("Level 18");
		lvlNineteenButton = GameObject.Find ("Level 19");
		lvlTwentyButton = GameObject.Find ("Level 20");
		exit3Button = GameObject.Find ("Exit Button 3");
		backStageButton = GameObject.Find ("Back Stage Button");
		nextStageButton = GameObject.Find ("Next Stage Button");
		optionsPanel = GameObject.Find ("Options Panel");
		changeLogPanel = GameObject.Find ("Change Log Panel");
		musicButton = GameObject.Find ("Music Button");
		soundButton = GameObject.Find ("Sound Button");
		changeLogButton = GameObject.Find ("Change Log Button");
		resetSaveButton = GameObject.Find ("Reset Save Button");
		exitOptionsButton = GameObject.Find ("Exit Button");
		maxLevelText = GameObject.Find ("Max Level Text");
		musicVS = GameObject.Find ("MusicVS");
		soundVS = GameObject.Find ("SoundVS");
		levelCompletePanel = GameObject.Find ("Level Complete Panel");
		levelCompleteTitle = GameObject.Find ("PolygonPicturesLVLComplete");
		retryButton = GameObject.Find ("Retry Button");
		nextLevelButton = GameObject.Find ("Next Level Button");
		exit2Button = GameObject.Find ("Exit Button 2");
		aiManager = GameObject.Find ("AI Manager");
		creditCanvas = GameObject.Find ("Credit Canvas");
		gameCanvas = GameObject.Find ("Game Canvas");
		aiManagerScript = aiManager.GetComponent<AIManager> ();
		boardManagerScript = GameObject.Find ("Board Manager").GetComponent<BoardManager> ();
		theMainCamera = mainCamera.GetComponent<UnityEngine.Camera>();
		startCameraLocation = mainCamera.transform.position;
		temporaryCameraLocation.x = 20.1f;
		temporaryCameraLocation.y = 17.25f;
		temporaryCameraLocation.z = -10;
		LVLCompleteCameraLocation.x = 0;
		LVLCompleteCameraLocation.y = 37.25f;
		LVLCompleteCameraLocation.z = -10;
		codexCameraLocation = startCameraLocation;
		codexCameraLocation.x = -100;
		creditCameraLocation = startCameraLocation;
		creditCameraLocation.x = 20.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isNormalLevel) {
			creditCanvas.SetActive(false);
			if (testTime) {
			initialTimer += Time.deltaTime;
			if (initialTimer > 0.1f) {
				doInitialLevelScan = true;
				initialTimer = 0;
					testTime = false;
					canScan = true;
				}
				
			}
			if (doInitialLevelScan && boardManagerScript.buildingBoard == false) {
				//Shapearray.Clear(); // Clear all lists/arrays since we are not using them.
				if (Shapearray.Count == 0) {
					Shapearray = FindObjectsOfType(typeof(ShapeIdentifier)).Cast<ShapeIdentifier>().ToList();//Set the array with all the  shapes
					//Debug.Log (Shapearray);
					//Debug.Log ("The scan is complete.");
					//Debug.Log (Shapearray.Count);
					foreach (ShapeIdentifier shape in Shapearray.ToList()) {
						if (shape.shape == "invis") {
							Shapearray.Remove(shape);
						}
					}
					colorTurn = "green";
					if (currentLevel > 15) {
						activateGreenRegen = true;
					}
					else { 
						activateGreenRegen = false;
					}
				}
				else {
					doInitialLevelScan = false; //Stop the Initial Level Scan
				}
				}
			if (currentLevel > 5) {
			gameCanvas.SetActive(true);
			}
			}
		else {
			creditCanvas.SetActive (true);
			gameCanvas.SetActive(false);
			//Debug.Log ("Clearing the array.");
			Shapearray.Clear(); // Clear all lists/arrays since we are not using them.
			Shapelist.Clear();
			CurrentShapes.Clear();
			Shapelistblue.Clear();
			CurrentShapesBlue.Clear();
			ShapelistYellow.Clear();
			CurrentShapesYellow.Clear();
			ShapelistOrange.Clear();
			CurrentShapesOrange.Clear();
			polyFaceGreenRadio.Clear();
			polyFaceBlueRadio.Clear();
			polyFaceYellowRadio.Clear();
			polyFaceOrangeRadio.Clear();
			doInitialLevelScan = true; //Allow the Initial Level Scan to happen
			turnCounter = 1;
			lastTurnOne = 0;
			lastTurnTwo = 0;
		}
		if (normalLVLComplete) { // Reposition the Camera
			if (canMoveCamera3) {
			mainCamera.transform.position = LVLCompleteCameraLocation;
				canMoveCamera3 = false;
				canMoveCamera2 = true;
				isCameraLocation1 = false;
				isCameraLocation2 = false;
				isCameraLocation3 = true;
			}
			if (PlayerPrefs.GetInt("Allowed Level") <= currentLevel+1) {
				PlayerPrefs.SetInt("Allowed Level", currentLevel+1);
				Debug.Log (PlayerPrefs.GetInt("Allowed Level"));
			}
			levelCompletePanel.SetActive(true);
			levelCompleteTitle.SetActive (true);
			retryButton.SetActive(true);
			nextLevelButton.SetActive(true);
			exit2Button.SetActive(true);
		}
		else {
			levelCompletePanel.SetActive(false);
			levelCompleteTitle.SetActive (false);
			retryButton.SetActive(false);
			nextLevelButton.SetActive(false);
			exit2Button.SetActive(false);
		}
		if (canTime) {
			canScan = false; //Prevent the Player from doing anything with the shapes during this time
			bTimer += Time.deltaTime; //Allow the timer to go on
			//Debug.Log (bTimer); //Log the timer's timer
			if (bTimer >= timer) {
				canTime = false; //If the timer is equal to what we want it to be, stop timing
				canScan = true; // Allow Player Actions again
				bTimer = 0f; //Reset the Timer
			}
		}
		if (!isTitleScreen) { //If we are not on the title screen, turn these things off.
			playButton.SetActive (false);
			createButton.SetActive (false);
			codexButton.SetActive (false);
			awardsButton.SetActive (false);
			optionsButton.SetActive (false);
			creditsButton.SetActive (false);
			if (GameObject.Find("PolygonPicturesTitles") != null) { //Destroy the Title
			temporaryTitle = GameObject.Find("PolygonPicturesTitles");
				Destroy(temporaryTitle);
			}
		} else { //If we are on the title screen, turn these things on;
			playButton.SetActive (true);
			createButton.SetActive (true);
			codexButton.SetActive (true);
			awardsButton.SetActive (true);
			optionsButton.SetActive (true);
			creditsButton.SetActive (true);
			if (GameObject.Find("PolygonPicturesTitles")== null) {
				newTitle = Instantiate(polygonTitles);
			}
			else { //Get the title location
				temporaryTitle = GameObject.Find("PolygonPicturesTitles");
				titleLocation = temporaryTitle.transform.position;
			}

		}
		if (isOptions) {
			if (canMoveCamera1) {
			mainCamera.transform.position = temporaryCameraLocation;
				canMoveCamera1 = false;
				canMoveCamera2 = true;
				isCameraLocation1 = true;
				isCameraLocation2 = false;
				isCameraLocation3 = false;
			}
			if (!isChangeLog){ 
			optionsPanel.SetActive (true);
			changeLogPanel.SetActive (false);
			musicButton.SetActive (true);
			soundButton.SetActive (true);
			changeLogButton.SetActive (true);
			exitOptionsButton.SetActive (true);
			musicVS.SetActive (true);
			soundVS.SetActive (true);
			resetSaveButton.SetActive (true);
			maxLevelText.GetComponent<Text>().text = "Levels Unlocked: "+ (PlayerPrefs.GetInt("Allowed Level"));
			}
			else {
				optionsPanel.SetActive (false);
				changeLogPanel.SetActive (true);
				musicButton.SetActive (false);
				soundButton.SetActive (false);
				changeLogButton.SetActive (false);
				exitOptionsButton.SetActive (false);
				musicVS.SetActive (false);
				soundVS.SetActive (false);
				resetSaveButton.SetActive (false);
				maxLevelText.GetComponent<Text>().text = "";
			}

		} else {
			if (!normalLVLComplete) {
				if (canMoveCamera2) {
					mainCamera.transform.position = startCameraLocation;
					canMoveCamera2 = false;
					canMoveCamera1 = true;
					canMoveCamera3 = true;
					isCameraLocation1 = false;
					isCameraLocation2 = true;
					isCameraLocation3 = false;
				}
			}
			optionsPanel.SetActive (false);
			changeLogPanel.SetActive (false);
			musicButton.SetActive (false);
			soundButton.SetActive (false);
			changeLogButton.SetActive (false);
			exitOptionsButton.SetActive (false);
			musicVS.SetActive (false);
			soundVS.SetActive (false);
			resetSaveButton.SetActive (false);
			maxLevelText.GetComponent<Text>().text = "";

		}
		if (isLevelSelect) { // Set all the level select objects
			mainCamera.transform.position = startCameraLocation;
			if (stage == 1) {
			lvlOneButton.SetActive (true);
			lvlTwoButton.SetActive (true);
			lvlThreeButton.SetActive (true);
			lvlFourButton.SetActive (true);
			lvlFiveButton.SetActive (true);
			lvlSixButton.SetActive (true);
			lvlSevenButton.SetActive (true);
			lvlEightButton.SetActive (true);
			lvlNineButton.SetActive (true);
			lvlTenButton.SetActive (true);
			lvlElevenButton.SetActive(true);
			lvlTwelveButton.SetActive(true);
			lvlThirteenButton.SetActive(true);
			lvlFourteenButton.SetActive(true);
			lvlFifteenButton.SetActive(true);
			}
			else {
				lvlOneButton.SetActive (false);
				lvlTwoButton.SetActive (false);
				lvlThreeButton.SetActive (false);
				lvlFourButton.SetActive (false);
				lvlFiveButton.SetActive (false);
				lvlSixButton.SetActive (false);
				lvlSevenButton.SetActive (false);
				lvlEightButton.SetActive (false);
				lvlNineButton.SetActive (false);
				lvlTenButton.SetActive (false);
				lvlElevenButton.SetActive(false);
				lvlTwelveButton.SetActive(false);
				lvlThirteenButton.SetActive(false);
				lvlFourteenButton.SetActive(false);
				lvlFifteenButton.SetActive(false);
			}
			if (stage == 2) {
				lvlSixteenButton.SetActive(true);
				lvlSeventeenButton.SetActive(true);
				lvlEighteenButton.SetActive(true);
				lvlNineteenButton.SetActive(true);
				lvlTwentyButton.SetActive(true);
			}
			else {
				lvlSixteenButton.SetActive(false);
				lvlSeventeenButton.SetActive(false);
				lvlEighteenButton.SetActive(false);
				lvlNineteenButton.SetActive(false);
				lvlTwentyButton.SetActive(false);
			}
			exit3Button.SetActive(true);
			nextStageButton.SetActive(true);
			backStageButton.SetActive(true);
			if (searchForLVLSelectCanvas) {
				//Debug.Log ("Searching for Canvas");
			levelSelectCanvas = GameObject.Find ("Level Select Canvas 2");
				if (levelSelectCanvas != null) {
					levelSelectCanvasActual = levelSelectCanvas.GetComponent<Canvas>();

				if (levelSelectCanvasActual != null) {
			levelSelectCanvasActual.worldCamera = theMainCamera;
					hasLVLSelectCanvas = true;
						searchForLVLSelectCanvas = false;
					}
				}
			}
		} else {
			if (hasLVLSelectCanvas) {
			    if (levelSelectCanvasActual !=null)
                 {
                     levelSelectCanvasActual.worldCamera = null;
                 }
			levelSelectCanvasActual = null;
                
			levelSelectCanvas = null;
			hasLVLSelectCanvas = false;
			}
			searchForLVLSelectCanvas = true;
			lvlOneButton.SetActive (false);
			lvlTwoButton.SetActive (false);
			lvlThreeButton.SetActive (false);
			lvlFourButton.SetActive (false);
			lvlFiveButton.SetActive (false);
			lvlSixButton.SetActive (false);
			lvlSevenButton.SetActive (false);
			lvlEightButton.SetActive (false);
			lvlNineButton.SetActive (false);
			lvlTenButton.SetActive (false);
			lvlElevenButton.SetActive(false);
			lvlTwelveButton.SetActive(false);
			lvlThirteenButton.SetActive(false);
			lvlFourteenButton.SetActive(false);
			lvlFifteenButton.SetActive(false);
			lvlSixteenButton.SetActive(false);
			lvlSeventeenButton.SetActive(false);
			lvlEighteenButton.SetActive(false);
			lvlNineteenButton.SetActive(false);
			lvlTwentyButton.SetActive(false);
			exit3Button.SetActive(false);
			nextStageButton.SetActive(false);
			backStageButton.SetActive(false);
		}
		//for(int i = 0; i < list1.Length; i++) {
			//Debug.Log (list1);
		//}
		if (colorTurn == "green") {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {//Get if Left Arrow Key is down and start scanning for green shapes
				if (canScan) {
					canTime = true; //Allow the Timer to be on
					canScan = false; //Stop the loop
					scanning = true; //Allow the scanning of the shapes to begin
					sendDirection = "left"; //Tell what direction the shapes are now assigned to if they are green
					//Debug.Log ("scanning");
				}
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {//Get if Down Arrow Key is down
				if (canScan) {
					canTime = true;
					canScan = false;
					scanning = true;
					sendDirection = "down";
					//Debug.Log ("scanning");
				}
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {//Get if Right Arrow Key is down
				if (canScan) {
					canTime = true;
					canScan = false;
					scanning = true;
					sendDirection = "right";
					//Debug.Log ("scanning");
				}
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {//Get if Up Arrow Key is down
				if (canScan) {
					canTime = true;
					canScan = false;
					scanning = true;
					sendDirection = "up";
					//Debug.Log ("scanning");
				}
			}
		}
		if (!waitTurns) {
			if (scanning) {
				//Debug.Log ("scanning");
				//Debug.Log (Shapearray.Count);
				Shapelist.Clear ();
				Shapelistblue.Clear ();
				CurrentShapes.Clear ();
			CurrentShapesBlue.Clear ();
				ShapelistYellow.Clear();
				CurrentShapesYellow.Clear();
				for (i = 0; i < Shapearray.Count; i++) { //
					if (Shapearray [i].color == "green" && scanning) {
						//Debug.Log (Shapearray [i]); //Print the current item in the array on the console
						Shapelist.Add (Shapearray [i].gameObject); //Add all green polygons to the shapelist
						//Debug.Log ("Green:i is " + i + " and the length of the array is " + Shapearray.Count); 
					} 
				}
				//Debug.Log ("i is " + i + " and the length of the array is " + Shapearray.Length);
				if (i == Shapearray.Count) {
					for (j = 0; j < Shapelist.Count; j++) {
						//Debug.Log (Shapelist [j]);
						CurrentShapes.Add (Shapelist [j].GetComponent<ShapeIdentifier> ()); //Add the scripts with the certain color to a new likst
						//Debug.Log ("j is " + j + " and the count of the list is " + Shapelist.Count);
						//Debug.Log (CurrentShapes [0]);
					 
					}
				}
				if (j == Shapelist.Count) {
					for (k = 0; k < CurrentShapes.Count; k++) {
                        //Debug.Log (CurrentShapes [k]);
                        
                            //Debug.Log("Last Color: " + lastColor + " and color Turn:" + colorTurn);
                            CurrentShapes[k].sendFace = true; //tell the polygon it can send a polyface
                            CurrentShapes[k].direction = sendDirection; // tell the polygon what direction to send the polyface
                        }

					}
				

				if (k == CurrentShapes.Count) {
					scanning = false; // The Scan has finished
					canScanForLVLComplete = true;
					waitTurns = true;
                    canScan = false;
					lastColor = "green";
				}
			}
		}
		if (!waitTurns) {
			if (colorTurn == "blue") {
				Shapelist.Clear ();
				Shapelistblue.Clear ();
				CurrentShapes.Clear ();
				CurrentShapesBlue.Clear ();
				ShapelistYellow.Clear();
				CurrentShapesYellow.Clear();
				ShapelistOrange.Clear();
				CurrentShapesOrange.Clear();
			for (i = 0; i < Shapearray.Count; i++) {
				if (Shapearray [i].color == "blue") {
					Shapelistblue.Add (Shapearray [i].gameObject); //Add all blue polygons to the shapelist
					//Debug.Log ("Blue:i is " + i + " and the length of the array is " + Shapearray.Count); 
				}
			}
				for (l = 0; l < Shapelistblue.Count; l++) {
					CurrentShapesBlue.Add (Shapelistblue [l].GetComponent<ShapeIdentifier> ());
					//Debug.Log ("l is " + l + " and the count of the list is " + Shapelistblue.Count);
				}
				if (l == Shapelistblue.Count) {
					aiManagerScript.blueDecision ();
					for (m = 0; m < CurrentShapesBlue.Count; m++) {
						CurrentShapesBlue [m].sendFace = true; //tell the polygon it can send a polyface
						CurrentShapesBlue [m].direction = sendDirectionBlue; // tell the polygon what direction to send the polyface
						Debug.Log (sendDirectionBlue);
						waitTurns = true;
						lastColor = "blue";
					}
				}
			}
			else if (colorTurn == "yellow") {
				Shapelist.Clear ();
				Shapelistblue.Clear ();
				ShapelistYellow.Clear();
				CurrentShapes.Clear ();
				CurrentShapesBlue.Clear ();
				CurrentShapesYellow.Clear();
				ShapelistOrange.Clear();
				CurrentShapesOrange.Clear();
				for (i = 0; i < Shapearray.Count; i++) { //
					if (Shapearray [i].color == "green") {
						//Debug.Log (Shapearray [i]); //Print the current item in the array on the console
						Shapelist.Add (Shapearray [i].gameObject); //Add all green polygons to the shapelist
						//Debug.Log ("Green:i is " + i + " and the length of the array is " + Shapearray.Count); 
					} 
				}
				for (i = 0; i < Shapearray.Count; i++) {
					if (Shapearray [i].color == "blue") {
						Shapelistblue.Add (Shapearray [i].gameObject); //Add all blue polygons to the shapelist
						//Debug.Log ("Blue:i is " + i + " and the length of the array is " + Shapearray.Count); 
					}
				}
				for (i = 0; i < Shapearray.Count; i++) {
					if (Shapearray [i].color == "yellow") {
						ShapelistYellow.Add (Shapearray [i].gameObject); //Add all blue polygons to the shapelist
						//Debug.Log ("Yellow:i is " + i + " and the length of the array is " + Shapearray.Count); 
					}
				}
				for (l = 0; l < ShapelistYellow.Count; l++) {
					CurrentShapesYellow.Add (ShapelistYellow [l].GetComponent<ShapeIdentifier> ());
					//Debug.Log ("l is " + l + " and the count of the list is " + ShapelistYellow.Count);
				}
				if (l == ShapelistYellow.Count) {
					aiManagerScript.yellowDecision ();
					for (m = 0; m < CurrentShapesYellow.Count; m++) {
						CurrentShapesYellow [m].sendFace = true; //tell the polygon it can send a polyface
						CurrentShapesYellow [m].direction = sendDirectionYellow; // tell the polygon what direction to send the polyface
						//Debug.Log (sendDirectionYellow);
						waitTurns = true;
						lastColor = "yellow";
					}
				}
				}
			else if (colorTurn == "orange") {
				Shapelist.Clear ();
				Shapelistblue.Clear ();
				ShapelistYellow.Clear();
				CurrentShapes.Clear ();
				CurrentShapesBlue.Clear ();
				CurrentShapesYellow.Clear();
				ShapelistOrange.Clear();
				CurrentShapesOrange.Clear();
				for (i = 0; i < Shapearray.Count; i++) { //
					if (Shapearray [i].color == "green") {
						//Debug.Log (Shapearray [i]); //Print the current item in the array on the console
						Shapelist.Add (Shapearray [i].gameObject); //Add all green polygons to the shapelist
						//Debug.Log ("Green:i is " + i + " and the length of the array is " + Shapearray.Count); 
					} 
				}
				for (i = 0; i < Shapearray.Count; i++) {
					if (Shapearray [i].color == "orange") {
						ShapelistOrange.Add (Shapearray [i].gameObject); //Add all blue polygons to the shapelist
						//Debug.Log ("Orange:i is " + i + " and the length of the array is " + Shapearray.Count); 
					}
				}
				for (l = 0; l < ShapelistOrange.Count; l++) {
					CurrentShapesOrange.Add (ShapelistOrange [l].GetComponent<ShapeIdentifier> ());
					//Debug.Log ("l is " + l + " and the count of the list is " + Shapelistblue.Count);
				}
				if (l == ShapelistOrange.Count) {
					aiManagerScript.orangeDecision ();
					for (m = 0; m < CurrentShapesOrange.Count; m++) {
						CurrentShapesOrange [m].sendFace = true; //tell the polygon it can send a polyface
						CurrentShapesOrange [m].direction = sendDirectionOrange; // tell the polygon what direction to send the polyface
						//Debug.Log (sendDirectionBlue);
						waitTurns = true;
						lastColor = "orange";
					}
				}
			}
		}
		/* if (all colors green)
		finish = true;
		 else green turn = true*/

		if (waitTurns) { //Clear all lists to refresh them
			Shapelist.Clear ();
			CurrentShapes.Clear ();
			Shapelistblue.Clear ();
			CurrentShapesBlue.Clear ();
			ShapelistYellow.Clear();
			CurrentShapesYellow.Clear();
			ShapelistOrange.Clear();
			CurrentShapesOrange.Clear();
			polyReceiverGreen.Clear();
			polyReceiverGreenFinished.Clear();
			polyReceiverBlue.Clear();
			polyReceiverBlueFinished.Clear();
			polyReceiverYellow.Clear();
			polyReceiverYellowFinished.Clear();
			polyReceiverOrange.Clear();
			polyReceiverOrangeFinished.Clear();
			turnTimer += Time.deltaTime;
			for (i = 0; i < Shapearray.Count; i++) { //
				if (Shapearray [i].color == "green") {
					//Debug.Log (Shapearray [i]); //Print the current item in the array on the console
					Shapelist.Add (Shapearray [i].gameObject); //Add all green polygons to the shapelist
					//Debug.Log ("Green:i is " + i + " and the length of the array is " + Shapearray.Count); 
				} 
			}
			for (i = 0; i < Shapearray.Count; i++) {
				if (Shapearray [i].color == "blue") {
					Shapelistblue.Add (Shapearray [i].gameObject); //Add all blue polygons to the shapelist
					//Debug.Log ("Blue:i is " + i + " and the length of the array is " + Shapearray.Count);
				}
			}
			for (i = 0; i < Shapearray.Count; i++) {
				if (Shapearray [i].color == "yellow") {
					ShapelistYellow.Add (Shapearray [i].gameObject); //Add all blue polygons to the shapelist
					//Debug.Log ("Yellow:i is " + i + " and the length of the array is " + Shapearray.Count);
				}
			}
			for (i = 0; i < Shapearray.Count; i++) {
				if (Shapearray [i].color == "orange") {
					ShapelistOrange.Add (Shapearray [i].gameObject); //Add all orange polygons to the shapelist
					//Debug.Log ("Orange:i is " + i + " and the length of the array is " + Shapearray.Count); 
				}
			}
			for (i = 0; i < Shapearray.Count; i++) {
				if (Shapearray [i].color == "green" && Shapearray[i].GetComponent<ShapeIdentifier>().shape == "receiver") {
					if (!polyReceiverGreen.Contains(Shapearray[i].GetComponent<ShapeIdentifier>())) {
					polyReceiverGreen.Add (Shapearray[i].GetComponent<ShapeIdentifier>());
					//Debug.Log("Green: Reciever found!");
					}
					if (Shapearray[i].color != "green" && polyReceiverGreen.Contains(Shapearray[i].GetComponent<ShapeIdentifier>())) {
						polyReceiverGreen.Remove(Shapearray[i]);
					}
				}
			}
			for (i = 0; i < Shapearray.Count; i++) {
				if (Shapearray [i].color == "blue" && Shapearray[i].GetComponent<ShapeIdentifier>().shape == "receiver") {
					if (!polyReceiverBlue.Contains(Shapearray[i].GetComponent<ShapeIdentifier>())) {
					polyReceiverBlue.Add (Shapearray[i].GetComponent<ShapeIdentifier>());
					//Debug.Log("Blue: Reciever found!");
					}
					if (Shapearray[i].color != "blue" && polyReceiverBlue.Contains(Shapearray[i].GetComponent<ShapeIdentifier>())) {
						polyReceiverBlue.Remove(Shapearray[i]);
					}
				}
			}
			for (i = 0; i < Shapearray.Count; i++) {
				if (Shapearray [i].color == "yellow" && Shapearray[i].GetComponent<ShapeIdentifier>().shape == "receiver") {
						if (!polyReceiverYellow.Contains(Shapearray[i].GetComponent<ShapeIdentifier>())) {
					polyReceiverYellow.Add (Shapearray[i].GetComponent<ShapeIdentifier>());
					//Debug.Log("Yellow: Reciever found!");
					}
					if (Shapearray[i].color != "yellow" && polyReceiverYellow.Contains(Shapearray[i].GetComponent<ShapeIdentifier>())) {
						polyReceiverYellow.Remove(Shapearray[i]);
					}
				}
			}
			for (i = 0; i < Shapearray.Count; i++) {
				if (Shapearray [i].color == "orange" && Shapearray[i].GetComponent<ShapeIdentifier>().shape == "receiver") {
					if (!polyReceiverOrange.Contains(Shapearray[i].GetComponent<ShapeIdentifier>())) {
						polyReceiverOrange.Add (Shapearray[i].GetComponent<ShapeIdentifier>());
						//Debug.Log("Blue: Reciever found!");
					}
					if (Shapearray[i].color != "orange" && polyReceiverOrange.Contains(Shapearray[i].GetComponent<ShapeIdentifier>())) {
						polyReceiverOrange.Remove(Shapearray[i]);
					}
				}
			}
			if (polyReceiverGreen.Count == polyReceiverGreenFinished.Count) {
				polyFaceGreenRadio.Clear();
				polyReceiverGreenFinished.Clear();
			}
			if (polyReceiverBlue.Count == polyReceiverBlueFinished.Count) {
				polyFaceBlueRadio.Clear();
				polyReceiverBlueFinished.Clear();
			}
			if (polyReceiverYellow.Count == polyReceiverYellowFinished.Count) {
				polyFaceYellowRadio.Clear();
				polyReceiverYellowFinished.Clear();
			}
			if (polyReceiverOrange.Count == polyReceiverOrangeFinished.Count) {
				polyFaceOrangeRadio.Clear();
				polyReceiverOrangeFinished.Clear();
			}
			if (turnTimer >= 3f) {
				Debug.Log("Turn Timer Complete!");
				Debug.Log ("There are "+Shapelistblue.Count()+" blue shapes.");
				if (lastColor == "green" && Shapelistblue.Count() != 0) {
					colorTurn = "blue";
					//Debug.Log("It's now blue's turn!");

				}
				else if ((lastColor == "blue" || lastColor == "green") && ShapelistYellow.Count() != 0) {
					colorTurn = "yellow";
					//Debug.Log("It's now yellow's turn!");
					if (turnCounter % 3 == 0) {
					aiManagerScript.yellowStorm();
					}
				}
				else if ((lastColor == "blue" || lastColor == "green" || lastColor == "yellow") && ShapelistOrange.Count() != 0) {
					colorTurn = "orange";
					if (turnCounter % 4 == 0) {
						aiManagerScript.orangeFire();
					}
					if (turnCounter % 3 == 0) {
					aiManagerScript.orangeScare();
					}
				}
				else  {
                    if (lastColor == "green")
                    {
                        Debug.LogError("We should not be going");
                    }
					colorTurn = "green";
					turnCounter += 1;
					Debug.Log("It's now green's turn!");
				}
				turnTimer = 0;
				waitTurns = false;
			}
		}
		if (canScanForLVLComplete) {
			cTimer += Time.deltaTime;
			//Debug.Log(cTimer);
			if (cTimer >= 3f) {
				Shapelist.Clear();
				CurrentShapes.Clear();
				i = 0;
				j = 0;
				k = 0;
				for (i = 0; i < Shapearray.Count; i++) { //
					if (Shapearray [i].color == "green") {
						//Debug.Log (Shapearray [i]); //Print the current item in the array on the console
						Shapelist.Add (Shapearray [i].gameObject); //Add all green polygons to the shapelist
						//Debug.Log ("Check 2: i is " + i + " and the length of the array is " + Shapearray.Count); 
					}
				}
				if (i == Shapearray.Count) {
					for (j = 0; j < Shapelist.Count; j++) {
						//Debug.Log (Shapelist [j]);
						CurrentShapes.Add (Shapelist [j].GetComponent<ShapeIdentifier> ()); //Add the scripts with the certain color to a new likst
						//Debug.Log ("Check 2: j is " + j + " and the count of the list is " + Shapelist.Count);
						//Debug.Log (CurrentShapes [0]);	
					}
				}
				if (j == Shapelist.Count) {
					for (k = 0; k < CurrentShapes.Count; k++) { 
						//Debug.Log (CurrentShapes [k]);
					}
				}
				if (k == CurrentShapes.Count) {
					if (Shapearray.Count == CurrentShapes.Count) {
						//Debug.Log("Level Complete!");
						normalLVLComplete = true;
					}
				}
				//Debug.Log ("k is "+k+" and the length of Current Shapes is "+CurrentShapes.Count);
				//Debug.Log("The length of Shaperarray is "+Shapearray.Count);
				//Debug.Log ("Resetting Timer!");
				cTimer = 0;
				canScanForLVLComplete = false;
				canScan = true;
			
			}
		}
		if (isCodex) {
			mainCamera.transform.position = codexCameraLocation;
			isCameraLocation1 = false;
			isCameraLocation2 = false;
			isCameraLocation3 = false;
			isCameraLocation4 = true;
		} else {
			if (!isOptions && !normalLVLComplete && !isCredits) {
			mainCamera.transform.position = startCameraLocation;
			isCameraLocation1 = true;
			isCameraLocation2 = false;
			isCameraLocation3 = false;
			isCameraLocation4 = false;
			}
		}
		if (isCredits) {
			mainCamera.transform.position = creditCameraLocation;
		} else {
			if (!isOptions && !normalLVLComplete && !isCodex) {
				mainCamera.transform.position = startCameraLocation;
				isCameraLocation1 = true;
				isCameraLocation2 = false;
				isCameraLocation3 = false;
				isCameraLocation4 = false;
			}
		}
}
	public void toTitleScreen () {
		Application.LoadLevel("Title"); //Load The Title Screen
		isTitleScreen = true; //Turn The Title Buttons On
		isLevelSelect = false; //Turn The Level Select Buttons Off
		isNormalLevel = false; //Turn The Normal Level Objects Off
		isChangeLog = false; //Turn The Changelog Objects Off
		isOptions = false; //Turn the Options Objects Off
		normalLVLComplete = false;
	}
	public void toLevelSelect() {
		Application.LoadLevel("Level Select"); //Load The Level Select Screen
		isTitleScreen = false; //Turn The Title Buttons Off
		isLevelSelect = true; //Turn The Level Select Buttons On
		isNormalLevel = false; //Turn The Normal Level Objects Off
		isChangeLog = false; //Turn The Changelog Objects Off
		isOptions = false; //Turn the Options Objects Off
		normalLVLComplete = false;
	}
	public void toNormalLevel(int number) {
		Application.LoadLevel ("Level "+number);
		isTitleScreen = false; //Turn The Title Buttons Off
		isLevelSelect = false; //Turn The Level Select Buttons Off
		isNormalLevel = true; //Turn The Normal Level Objects On
		isChangeLog = false; //Turn The Changelog Objects Off
		isOptions = false; //Turn the Options Objects Off
		currentLevel = number;
	}
	public void activateOptions () {
		isChangeLog = false; //Turn The Changelog Objects Off
		isOptions = true; //Turn the Options Objects On
	}
	public void activateChangeLog () {
		isChangeLog = true; //Turn The Changelog Objects On
	}
	public void disableChangeLog () {
		isChangeLog = false; //Turn The Changelog Objects On
	}
	public void leaveOptions() {
		isOptions = false; //Turn The Changelog Objects Off
		isChangeLog = false; //Turn the Options Objects Off
	}
	public void resetSave () { //Delete save data
		PlayerPrefs.SetInt ("Allowed Level", 0);
	}
	public void activateCodex() {
		isCodex = true;
	}
	public void deactivateCodex() {
		isCodex = false;
	}
	public void retryNormalLevel() {
		//isNormalLevel = false;
 // Clear all lists/arrays since we are not using them.
		Application.LoadLevel ("Level "+currentLevel);
		Shapearray = new List<ShapeIdentifier>();
		Shapearray.TrimExcess ();
		Shapearray.Clear ();
		Shapelist.Clear();
		CurrentShapes.Clear();
		Shapelistblue.Clear();
		CurrentShapesBlue.Clear();
		ShapelistYellow.Clear();
		CurrentShapesYellow.Clear();
		ShapelistOrange.Clear();
		CurrentShapesOrange.Clear();
		polyFaceGreenRadio.Clear();
		polyFaceBlueRadio.Clear();
		polyFaceYellowRadio.Clear();
		polyFaceOrangeRadio.Clear ();
		switch (currentLevel) {
		case 3:	
			boardManagerScript.startBuilding (7);
			break;
		case 4:	
			boardManagerScript.startBuilding (10);
			break;
		case 5:	
			boardManagerScript.startBuilding (13);
			break;
		case 6:	
			boardManagerScript.startBuilding (4);
			break;
		case 7:	
			boardManagerScript.startBuilding (7);
			break;
		case 8:	
			boardManagerScript.startBuilding (10);
			break;
		case 9:	
			boardManagerScript.startBuilding (12);
			break;
		case 10:	
			boardManagerScript.startBuilding (14);
			break;
		case 11:	
			boardManagerScript.startBuilding (5);
			break;
		case 12:	
			boardManagerScript.startBuilding (7);
			break;
		case 13:	
			boardManagerScript.startBuilding (10);
			break;
		case 14:	
			boardManagerScript.startBuilding (6);
			break;
		case 15:	
			boardManagerScript.startBuilding (15);
			break;
		}
		boardManagerScript.levelNumber (currentLevel);
		currentLevel = 1;
		normalLVLComplete = false;
		isNormalLevel = true;
		testTime = true;
		canScan = false;
	}
	public void nextNormalLevel () {
		//isNormalLevel = false;
	 // Clear all lists/arrays since we are not using them.

		Application.LoadLevel ("Level "+(currentLevel+1));
		Shapearray = new List<ShapeIdentifier>();
		Shapearray.TrimExcess ();
		Shapearray.Clear ();
		Shapelist.Clear();
		CurrentShapes.Clear();
		Shapelistblue.Clear();
		CurrentShapesBlue.Clear();
		ShapelistYellow.Clear();
		CurrentShapesYellow.Clear();
		ShapelistOrange.Clear();
		CurrentShapesOrange.Clear();
		polyFaceGreenRadio.Clear();
		polyFaceBlueRadio.Clear();
		polyFaceYellowRadio.Clear();
		polyFaceOrangeRadio.Clear ();
		lastTurnOne = 0;
		lastTurnTwo = 0;
		turnCounter = 1;
		switch (currentLevel) {
		case 2:	
		boardManagerScript.startBuilding (7);
			break;
		case 3:	
		boardManagerScript.startBuilding (10);
			break;
		case 4:	
		boardManagerScript.startBuilding (13);
			break;
		case 5:	
			boardManagerScript.startBuilding (4);
			break;
		case 6:	
			boardManagerScript.startBuilding (7);
			break;
		case 7:	
			boardManagerScript.startBuilding (10);
			break;
		case 8:	
			boardManagerScript.startBuilding (12);
			break;
		case 9:	
			boardManagerScript.startBuilding (14);
			break;
		case 10:	
			boardManagerScript.startBuilding (5);
			break;
		case 11:	
			boardManagerScript.startBuilding (7);
			break;
		case 12:	
			boardManagerScript.startBuilding (10);
			break;
		case 13:	
			boardManagerScript.startBuilding (6);
			break;
		case 14:	
			boardManagerScript.startBuilding (15);
			break;
		case 15:	
			boardManagerScript.startBuilding (4);
			break;
		case 16:	
			boardManagerScript.startBuilding (7);
			break;
		case 17:	
			boardManagerScript.startBuilding (10);
			break;
		case 18:	
			boardManagerScript.startBuilding (12);
			break;
		case 19:	
			boardManagerScript.startBuilding (14);
			break;
		}
		boardManagerScript.levelNumber (currentLevel+1);
		currentLevel += 1;
		normalLVLComplete = false;
		isNormalLevel = true;
		testTime = true;
		canScan = false;
	}
	public void enableCredits() {
		isCredits = true;
	}
	public void disableCredits () {
		isCredits = false;
	}
	public void nextStage () {
		if (stage != 3) {
			stage += 1;
		}
	}
	public void backStage () {
		if (stage != 1) {
			stage -=1;
		}
	}
}
