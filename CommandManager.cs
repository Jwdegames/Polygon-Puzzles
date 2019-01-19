using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class CommandManager : MonoBehaviour {
	public static CommandManager instance = null;   //Static instance of GameManager which allows it to be accessed by any other script.
	public bool commandsOn = false;
	public GameObject commandCanvas;
	public GameObject commandText;
	public GameObject commandField;
	public GameObject gameManager;
	public string[] commandString;
	public int j;
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
		commandCanvas = GameObject.Find ("Command Canvas");
		commandText = GameObject.Find ("Command Text");
		commandField = GameObject.Find ("Command InputField");
		gameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown (KeyCode.Slash)) {
			commandsOn = true;
		}
		if (commandsOn) {
			commandCanvas.SetActive (true);
		} else {
			commandCanvas.SetActive(false);
		}
	}
	public void setCommandText() {
		commandText.GetComponent<Text> ().text = "\n" + commandText.GetComponent<Text> ().text + "\n" + commandField.GetComponent<InputField> ().text;
		if (commandField.GetComponent<InputField> ().text.Contains("/Allowed Level") == true) {
			commandString = null;
			commandString = commandField.GetComponent<InputField> ().text.Split(new string[] {":"}, System.StringSplitOptions.None);
			int.TryParse(commandString[1],out j);
			PlayerPrefs.SetInt("Allowed Level", j);
		}
		if (commandField.GetComponent<InputField> ().text.Contains ("/win")) {
			gameManager.GetComponent<GameManager>().normalLVLComplete = true;
		}
		commandField.GetComponent<InputField> ().text = "";
	}
	public void deactivateCommands () {
		commandsOn = false;
	}
}
