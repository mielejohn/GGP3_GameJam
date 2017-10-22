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


	//HeldItem
	public bool Itemheld = false;
	public GameObject HandPoint;
	public Rigidbody RB;

	// TaskItems
	public GameObject TaskObject;
	public GameObject FishFood;
	public GameObject FishBowl;
	public GameObject TrashBag;

	void Start () {
		DontDestroyOnLoad (this);
		taskNumber = 1;
		UpdateTask ();
	}
	
	// Update is called once per frame
	void Update () {
		RB = TaskObject.GetComponent<Rigidbody> ();

		if (Input.GetButtonDown("Interact")) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (TaskObject.gameObject.GetComponent<Collider>().Raycast (ray, out hit, 5.0f)) {
				if (taskNumber == 2 || taskNumber == 12 || taskNumber == 13 && Itemheld == false) {
					RB.useGravity =false;
					TaskObject.gameObject.transform.position = new Vector3 (HandPoint.transform.position.x,HandPoint.transform.position.y,HandPoint.transform.position.z);
					TaskObject.transform.SetParent (Player.transform);
					Itemheld = true;
				}
				taskNumber++;
				TaskObject.gameObject.GetComponent<Renderer> ().material = DefaultMaterial;
				UpdateTask();	
			}
		}

		if (Input.GetButtonDown ("Drop") && Itemheld == true) {
			TaskObject.gameObject.transform.parent = null;
			RB.useGravity = true;
			Itemheld = false;
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
			TaskObject = FishBowl;
			break;

		case 3:
			TaskText.text = "Set the clock";
			break;

		case 4:
			TaskText.text = "Run the dishwasher";
			break;

		case 5:
			TaskText.text = "Put clothes in the washer";
			break;

		case 6:
			TaskText.text = "Put clothes in the Dryer";
			break;

		case 7:
			TaskText.text = "Lock the door.";
			break;

		case 8:
			TaskText.text = "Go to the basement.";
			break;

		case 9:
			TaskText.text = "Turn on the lights";
			break;

		case 10:
			TaskText.text = "Clean up the stains.";
			break;

		case 11:
			TaskText.text = "Throw out the rags.";
			break;

		case 12:
			TaskText.text = "Grab the shovel.";
			break;

		case 13:
			TaskText.text = "Take out the trash.";
			break;

		case 14:
			TaskText.text = "Bury the trash outside.";
			break;

		case 15:
			TaskText.text = "Cook dinner";
			break;

		case 16:
			TaskText.text = "Set the table";
			break;

		case 17:
			TaskText.text = "Serve dinner";
			break;

		case 18:
			TaskText.text = "Go upstairs";
			break;
		
		case 19:
			TaskText.text = "Go to sleep.";
		break;
			
		}
		if (TaskObject != null) {
			TaskObject.gameObject.GetComponent<Renderer> ().material = ObjectiveMaterial;
		}
	}
}
