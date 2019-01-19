using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour {
	public GameObject gameManager;
	public GameObject abilityImage;
	public GameObject abilityText;
	public GameManager gameManagerScript;
	public Image aiRenderer;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;
	public Sprite sprite6;
	public Sprite sprite7;
	public Sprite sprite8;
	public Sprite sprite9;
	public Sprite available;
	public Sprite charging;
	public Text number;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		gameManagerScript = gameManager.GetComponent<GameManager> ();
		abilityImage = GameObject.Find ("Ability Image");
		abilityText = GameObject.Find ("Ability Text");
		aiRenderer = abilityImage.GetComponent<Image>();
		number = abilityText.GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManagerScript.currentAbility == 1 && gameManagerScript.turnCounter - gameManagerScript.lastTurnOne >= 2 && gameManagerScript.currentLevel >5) {
			gameObject.GetComponent<Image> ().sprite = available;
		} else if (gameManagerScript.currentAbility == 2 && gameManagerScript.turnCounter - gameManagerScript.lastTurnTwo >= 3 && gameManagerScript.currentLevel >10) {
			gameObject.GetComponent<Image> ().sprite = available;
		} else if (gameManagerScript.currentLevel > 15 && gameManagerScript.currentAbility == 3) {
			gameObject.GetComponent<Image> ().sprite = available;
		} else {
			gameObject.GetComponent<Image> ().sprite = charging;
		}
	}
	public void updateButton () {
		/* Set the text of the button
		 */

		if (number.text == "1") {
			number.text = "2";
			aiRenderer.sprite = sprite2;
			gameManagerScript.currentAbility = 2;
		} else if (number.text == "2") {
			number.text = "3";
			aiRenderer.sprite = sprite3;
			gameManagerScript.currentAbility = 3;
		}
		else if (number.text == "3"){ 
			number.text = "4";
			aiRenderer.sprite = sprite3;
			gameManagerScript.currentAbility = 3;
		}
		else if (number.text == "4"){ 
			number.text = "5";
			aiRenderer.sprite = sprite4;
			gameManagerScript.currentAbility = 4;
		}
		else if (number.text == "5"){ 
			number.text = "1";
			aiRenderer.sprite = sprite1;
			gameManagerScript.currentAbility = 1;
		}
	}
}
