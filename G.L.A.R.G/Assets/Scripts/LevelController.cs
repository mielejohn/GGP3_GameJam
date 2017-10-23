using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	//Public variables
	public Text TaskText;
	public int taskNumber = 1; 
	public Material ObjectiveMaterial;
	public Material DefaultMaterial;
	public GameObject Player;
	public GameObject SC;
	//public bool GoneToBasement;


	//HeldItem
	public bool Itemheld = false;
	public bool DropPointActive = false;
	public GameObject HandPoint;
	public Rigidbody RB;
	public GameObject BasementDoorway;

	// TaskItems
	public GameObject TaskObject;
	public GameObject PlacePoint;
	public GameObject FishFood;
	public GameObject TrashBag;
	public GameObject Trashcan;
	public GameObject Clock;
	public GameObject Dishes;
	public GameObject DirtyClothes;
	public GameObject WashingMachine;
	public GameObject WetClothes;
	public GameObject Dryer;
	public GameObject DoorLock;
	public GameObject BasementDoor;
	/*public GameObject LightSwitch;
	public GameObject Stains;
	public GameObject Rags;
	public GameObject Axe;*/
	public GameObject DeadTrash;
	public GameObject Hole;
	public GameObject Dinner;

	void Start () {
		DontDestroyOnLoad (this);
		//taskNumber = 1;
		UpdateTask ();

		//if (PlayerPrefs.HasKey("GoneToBasement")) {
		if (taskNumber >= 10) {
			Debug.Log ("Has key is true");
			Debug.Log ("TaskNumber is: " + PlayerPrefs.GetInt("TaskNumber"));
			taskNumber = PlayerPrefs.GetInt("TaskNumber");
			Player.gameObject.transform.position = new Vector3 (BasementDoorway.transform.position.x, BasementDoorway.transform.position.y, BasementDoorway.transform.position.z);
			TaskObject = DeadTrash;
			PlacePoint = Hole;
			TaskObject.gameObject.transform.position = new Vector3 (HandPoint.transform.position.x,HandPoint.transform.position.y,HandPoint.transform.position.z);
			PlacePoint.gameObject.GetComponent<Renderer> ().material = ObjectiveMaterial;
			TaskObject.transform.SetParent (Player.transform);
			DropPointActive = true;
			Itemheld = true;
			UpdateTask ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		RB = TaskObject.GetComponent<Rigidbody> ();

		if (Input.GetButtonDown("Interact")) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (TaskObject.gameObject.GetComponent<Collider>().Raycast (ray, out hit, 5.0f)) {
				if (taskNumber == 2 || taskNumber == 12 || taskNumber == 13 && Itemheld == false && DropPointActive == false) {
					TaskObject.gameObject.transform.position = new Vector3 (HandPoint.transform.position.x,HandPoint.transform.position.y,HandPoint.transform.position.z);
					PlacePoint.gameObject.GetComponent<Renderer> ().material = ObjectiveMaterial;
					TaskObject.transform.SetParent (Player.transform);
					DropPointActive = true;
					Itemheld = true;
				}
				if (taskNumber == 6 || taskNumber == 7) {
					TaskObject.gameObject.SetActive (false);
				}
				taskNumber++;
				TaskObject.gameObject.GetComponent<Renderer> ().material = DefaultMaterial;
				UpdateTask();	
			}


		}

		if (Input.GetButtonDown ("Drop") && Itemheld == true&&DropPointActive == true) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (PlacePoint.gameObject.GetComponent<Collider> ().Raycast (ray, out hit, 5.0f)) {
				TaskObject.gameObject.transform.parent = null;
				TaskObject.gameObject.SetActive (false);
				Itemheld = false;
				PlacePoint.gameObject.GetComponent<Renderer> ().material = DefaultMaterial;
				DropPointActive = false;
				taskNumber++;
				UpdateTask();
			}
		}
	}

	public void UpdateTask(){

		switch(taskNumber){

		case 0:
			TaskText.text = "";

			break;

		case 1:
			TaskText.text = "Feed the fish";
			TaskObject = FishFood;
			break;

		case 2:
			TaskText.text = "Take out the trash";
			TaskObject = TrashBag;
			PlacePoint = Trashcan;
			break;
		case 3:
			TaskText.text = "Take out the trash";
			TaskObject = TrashBag;
			PlacePoint = Trashcan;
			break;

		case 4:
			TaskText.text = "Set the clock";
			TaskObject = Clock;
			break;

		case 5:
			TaskText.text = "Wash the dishes";
			TaskObject = Dishes;
			break;

		case 6:
			TaskText.text = "Put clothes in the washer";
			TaskObject = DirtyClothes;
			//PlacePoint = WashingMachine;
			break;

		case 7:
			TaskText.text = "Put clothes in the Dryer";
			TaskObject = WetClothes;
			//PlacePoint = Dryer;
			break;

		case 8:
			TaskText.text = "Lock the door.";
			TaskObject = DoorLock;
			break;

		case 9:
			TaskText.text = "Go to the basement.";
			TaskObject = BasementDoor;
			break;

		/*case 10:
			TaskText.text = "Turn on the lights";
			TaskObject = LightSwitch;
			break;

		case 11:
			TaskText.text = "Clean up the stains.";
			TaskObject = Stains;
			break;

		case 12:
			TaskText.text = "Throw out the rags.";
			TaskObject = Rags;
			break;

		case 13:
			TaskText.text = "Grab the shovel.";
			TaskObject = Axe;
			break;

		case 14:
			TaskText.text = "Take out the trash.";
			TaskObject = DeadTrash;
			break;
		*/
		case 15:
			TaskText.text = "Bury the trash outside.";
			TaskObject = DeadTrash;
			PlacePoint = Hole;
			break;

		case 16:
			TaskText.text = "Cook dinner";
			TaskObject = Dinner;
			break;

		case 17:
			TaskText.text = "Serve dinner";
			break;

		case 18:
			TaskText.text = "Go upstairs";
			break;
			
		}
		if (TaskObject != null) {
			TaskObject.gameObject.GetComponent<Renderer> ().material = ObjectiveMaterial;
		}
	}
}
