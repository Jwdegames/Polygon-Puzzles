using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance = null;//Static instance of GameManager which allows it to be accessed by any other script.
	public AudioSource musicSource;
	public AudioSource soundSource;
	public AudioClip click1;
	public AudioClip click2;
	public AudioClip music1;
	public AudioClip music2;
    public AudioClip music3;
	public AudioClip soundEffect1;
	public AudioClip soundEffect2;
	public bool isMusic = true;
	public bool isSound = true;
	public GameObject gameManager;
	public float randomPitch;
	public float upperSFXP = 1.05f;
	public float lowerSFXP = 0.95f;

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
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.GetComponent<GameManager> ().currentLevel % 5 == 0 && gameManager.GetComponent<GameManager> ().currentLevel != 0) {
			if (musicSource.clip != music2) {
				playMusic ();
			}
		}
        else if (gameManager.GetComponent<GameManager>().currentLevel % 5 == 3 || gameManager.GetComponent<GameManager>().currentLevel % 5 == 4)
        {
			if (musicSource.clip != music3) {
				playMusic();
			}
		}
        else
        {
            if (musicSource.clip != music1)
            {
                playMusic();
            } 
        }
	}
	public void enableMusic() {
		if (isMusic) {
			musicSource.enabled = false;
			isMusic = false;
			musicSource.Play ();
		} else {
			musicSource.enabled = true;
			isMusic = true;
			musicSource.Play ();
		}

	}
	public void enableSound() {
		if (isSound) {
			soundSource.enabled = false;
			isSound = false;
		} else {
			soundSource.enabled = true;
			isSound = true;
		}
	}
	public void musicVM(float newVolume) {
		musicSource.volume = newVolume;
	}
	public void soundVM(float newVolume) {
		soundSource.volume = newVolume;
	}
	public void playClickSound (int songNumber) {
		if (songNumber == 0) {
			soundSource.clip = click1;
		} else if (songNumber == 1) {
			soundSource.clip = click2;
		}
		soundSource.Play ();
	}
	public void playMusic () {
		if (gameManager.GetComponent<GameManager> ().currentLevel % 5 == 0 && gameManager.GetComponent<GameManager> ().currentLevel != 0) {
			musicSource.clip = music2;
		}
		else if (gameManager.GetComponent<GameManager> ().currentLevel % 5 == 3|| gameManager.GetComponent<GameManager>().currentLevel % 5 == 4)
        {
			musicSource.clip = music3;
		}
        else
        {
            musicSource.clip = music1;
        }
		musicSource.Play ();
	}
	public void playSoundEffect (int sound) {
		if (sound == 1) {
			soundSource.clip = soundEffect1;
		} else if (sound == 2) {
			soundSource.clip = soundEffect2;
		}
		randomPitch = Random.Range (lowerSFXP, upperSFXP);
		soundSource.pitch = randomPitch;
		soundSource.Play ();
	}
}
