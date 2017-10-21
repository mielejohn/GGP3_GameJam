using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public Text TaskText;
	public int taskNumber = 0; 
	public Material ObjectiveMaterial;

	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateTask(){

		switch(taskNumber){

		case 1:
			TaskText.text = "Feed the fish";
			break;

		case 2:
			TaskText.text = "Take out the trash";
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
			TaskText.text = "Go upstairs and sleep.";
			break;
		}
	}
}
