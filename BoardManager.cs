using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BoardManager : MonoBehaviour {

	public static BoardManager instance = null;//Static instance of GameManager which allows it to be accessed by any other script.
	public int boardDimensions = 1;
	public int x;
	public int y; 
	public int x2;
	public int y2;
	public int x3;
	public int y3;
	public int x4;
	public int y4;
	public float x5 =0;
	public float y5 =0;
	public float interceptTimer;
	public int start1 = 0;
	public int end1 = 0;
	public int start2 = 0;
	public int end2 = 0;
	public int start3 = 0;
	public int end3 = 0;
	public int start4 = 0;
	public int end4 = 0;
	public int start5 = 0;
	public int end5 = 0;
	public int start6 = 0;
	public int end6 = 0;
	public int level;
	public int i;
	public bool buildingBoard = false;
	public bool check = false;
	public GameObject horizontalLine;
	public GameObject verticalLine;
	public GameObject horizantalBarrier;
	public GameObject verticalBarrier;
	public GameObject polygonSquare;
	public GameObject boardSquare;
	private GameObject holder1;
	private GameObject holder2;
	private GameObject holder3;
	public GameObject polyFaceInvisPrefab;
	public GameObject polyFaceTester;
	private GameObject holder4;
	public List<ShapeIdentifier> polygons = new List<ShapeIdentifier>();
	public Quaternion verticalLineQuaternion;
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
		verticalLineQuaternion = verticalLine.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (level != null) {
			if (Application.loadedLevelName == "Level " +level) {
				start1 = (boardDimensions - 2) * -1;
				end1 = boardDimensions;
				start2 = (boardDimensions - 1) * -1;
				end2 = boardDimensions;
				start3 = (boardDimensions -1) * -1;
				end3 = boardDimensions;
				start4 = (boardDimensions -1) * -1;
				end4 = boardDimensions;
				if (level >= 19) {
					start5 = (boardDimensions -1)* -1;
					end5 = boardDimensions +1;
					start6 = boardDimensions -1;
					end6 = boardDimensions -1;
				}

				if (buildingBoard) {
					/*if (check) {
						interceptTimer += Time.deltaTime;
						if (interceptTimer >= 1f) {
							if (polyFaceTester == null) {
								check = false;
							}
							else {
								Destroy (polyFaceTester);
							}
							interceptTimer = 0;
						}
					}*/
					polygons = FindObjectsOfType(typeof(ShapeIdentifier)).Cast<ShapeIdentifier>().ToList();;
					for (x = start1; x < end1; x = x + 2) {
						for (y = start2; y < end2; y = y + 2) {
							Instantiate (horizontalLine, new Vector3 (x, y, 0), Quaternion.identity);
						}
					}
					for (x2 = start2; x2 < end2; x2 = x2 + 2) {
						for (y2 = start1; y2 < end1; y2 = y2 + 2) {
							Instantiate (verticalLine, new Vector3 (x2, y2, 0), verticalLineQuaternion);
						}
					}
					for (x3 = start3; x3 < end3; x3 = x3 + 2) {
						holder1 = Instantiate (horizantalBarrier, new Vector3 (x3, boardDimensions + 0.75f, 0), Quaternion.identity) as GameObject;
						holder1.GetComponent<BoardBarrier>().direction = "up";
						holder1 = null;
						//Debug.Log ("Complete!");
					}
					for (x4 = start4; x4 < end4; x4 = x4 + 2) {
						holder2 = Instantiate (horizantalBarrier, new Vector3 (x4, (boardDimensions + 0.75f) * -1, 0), Quaternion.identity)as GameObject;
						holder2.GetComponent<BoardBarrier>().direction = "down";
						holder2 = null;
						//Debug.Log ("Complete!");
					}
					for (y3 = start3; y3 < end3; y3 = y3 + 2) {
						holder3 = Instantiate (verticalBarrier, new Vector3 (boardDimensions + 0.75f, y3, 0), verticalLineQuaternion)as GameObject;
						holder3.GetComponent<BoardBarrier>().direction = "right";
						holder3 = null;
					}
					for (y4 = start4; y4 < end4; y4 = y4 + 2) {
						holder4 = Instantiate (verticalBarrier, new Vector3 ((boardDimensions + 0.75f) * -1, y4, 0), verticalLineQuaternion)as GameObject;
						holder4.GetComponent<BoardBarrier>().direction = "left";
						holder4 = null;
					}
					for (x5 = start5; x5 < end5; x5 = x5 + 2) {
						for (y5 = start5; y5 < end5; y5 = y5 + 2) {
							checkGrid();
							/*if (polyFaceTester == null) {
								check = false;
							}
							else  {
								Destroy (polyFaceTester);
							}*/
							if (check) {
								boardSquare = Instantiate (polygonSquare, new Vector3 (x5,y5, -1), Quaternion.identity) as GameObject;
								boardSquare.GetComponent<ShapeIdentifier>().boardCreated = true;
								boardSquare = null;
							}
							
						}
						}
				}
				if (x == end1) {
					//	Debug.Log ("1st portion of the board is complete! Y is "+y+" while the requirement is "+end2);
						if (y >= end2) {
						//	Debug.Log ("2nd portion of the board is complete!");
							if (x2 >= end2) {
							//	Debug.Log ("3rd portion of the board is complete!");
								if (y2 >= end1) {
								//	Debug.Log ("4th portion of the board is complete!");
									if (x3 >= end3) {
										if (x4 >= end4) {
											if (y3 >= end3) {
												if (y4 >= end4) {
													if (x5 >= end5) {
														if (y5 >= end5){
							buildingBoard = false;
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

	public void startBuilding (int number) {
		boardDimensions = number;
		buildingBoard = true;
	}
	public void levelNumber (int levelNumber) {
		level = levelNumber;
	}
	public void checkGrid () {
		check = true;
		foreach (ShapeIdentifier shape in polygons) {
			if (shape.gameObject.transform.position.x == x5 && shape.gameObject.transform.position.y == y5) {
				check = false;
			}
			//polyFaceTester = Instantiate (polyFaceInvisPrefab, new Vector3 (x5, y5, -1), Quaternion.identity) as GameObject;
		}
	}
}
