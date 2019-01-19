using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour {

	public int intSetting;
	public Sprite greenSetting;
	public Sprite redSetting;
	private Button thisButton;
	private int allowedLevel;
	// Use this for initialization
	void Start () {
		thisButton = gameObject.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Allowed Level") != null) {		
			allowedLevel = PlayerPrefs.GetInt ("Allowed Level");
		}
		if (allowedLevel >= intSetting) {
			thisButton.image.overrideSprite = greenSetting;
			thisButton.interactable = true;
		} else {
			thisButton.interactable = false;
		}
	}
}
