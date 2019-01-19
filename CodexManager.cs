using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CodexManager : MonoBehaviour {
	public static CodexManager instance = null;   //Static instance of GameManager which allows it to be accessed by any other script.
	public GameObject codexText;
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
		codexText = GameObject.Find ("Codex Text");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setCodexText(int request) {
		switch (request) {
		case 0:
			codexText.GetComponent<Text>().text = "This is the Codex. It has information on all the shapes and abilities in Polygon Puzzles.";
			break;
		case 1:
			codexText.GetComponent<Text>().text = "The Square is a shape in Polygon Puzzles. It can send a polyface of strength one in any direction.";
			break;
		case 2:
			codexText.GetComponent<Text>().text = "The Triangle is a shape in Polygon Puzzles. It can send a polyface of strength one in the direction it's pointing at.";
			break;
		case 3:
			codexText.GetComponent<Text>().text = "The Pentagon is a shape in Polygon Puzzles. It can send a polyface of strength one in any direction and another polyface toward its pointed direction.";
			break;
		case 4:
			codexText.GetComponent<Text>().text = "The Double Triangle is a shape in Polygon Puzzles. It can send a polyface of strength two in the direction it's pointing at.";
			break;
		case 5:
			codexText.GetComponent<Text>().text = "The Hexagon is a shape in Polygon Puzzles. It can send a polyface of strength one in any direction and another polyface in the direction oppisite of that direction.";
			break;
		case 6:
			codexText.GetComponent<Text>().text = "The Wall is an interactable object in Polygon Puzzles. It takes 1 strength from a polyface that comes into contact with it, destroying itself in the process.";
			break;
		case 7:
			codexText.GetComponent<Text>().text = "The Heptagon is a shape in Polygon Puzzles. It can send a polyface of strength one in any direction and another polyface of strength two in it's pointed direction.";
			break;
		case 8:
			codexText.GetComponent<Text>().text = "The Boss Square 1 is a shape in Polygon Puzzles. It can send a polyface of strength four in any direction.";
			break;
		case 9:
			codexText.GetComponent<Text>().text = "The Acid Ability is an ability in Polygon Puzzles. It can be used every other turn. It causes the acid effect, which does one green damage to a shape over two turns. This ability can be upgraded.";
			break;
		case 10:
			codexText.GetComponent<Text>().text = "The Octagon is a shape in Polygon Puzzles. It can send a polyface of strength two in any direction and another polyface of strength two in the direction oppisite of that direction.";
			break;
		case 11:
			codexText.GetComponent<Text>().text = "The Decagon is a shape in Polygon Puzzles. It sends two polyfaces of strength two " +
				"to the left and right. It can also send a polyface of strength 1 up or down.";
			break;
		case 12:
			codexText.GetComponent<Text>().text = "The Dodecagon is a shape in Polygon Puzzles. It can send a polyface of strength three in any direction and another polyface of strength three in the direction oppisite of that direction.";
			break;
		case 13:
			codexText.GetComponent<Text>().text = "The Storm Ability is an ability in Polygon Puzzles. It used by the yellow enemy and occurs every three turns. It damages a random shape and the lightning may spread.";
			break;
		case 14:
			codexText.GetComponent<Text>().text = "The Max Triangle is a shape in Polygon Puzzles. It can send a polyface that's invincible in the direction it's pointing at.";
			break;
		case 15:
			codexText.GetComponent<Text>().text = "The Shield Ability is an ability in Polygon Puzzles. It can protect a green shape from any other polyface. It can be used every three turns.";
			break;
		}

	}
}
