﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItems : MonoBehaviour {
	public Camera droneCamera;
	private Camera mainCamera;
	public GameObject firstPerson;
	static public Item item_in_use;
	static public int USE = 0;
	private int END = 0;
	private float timeRemaining = -10.0f;
	private float startTime = 0.0f;
	private float timeincrease = 0.0f;
	// Use this for initialization
	void Start () {
		mainCamera = firstPerson.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(USE==1){
			use_item(item_in_use.return_type());
			USE=0;
			startTime = item_in_use.return_remaining_time();
			timeRemaining = 1.0f;
		}
		if (timeRemaining > 0.0f){
			timeincrease += Time.deltaTime; 
			timeRemaining = startTime - timeincrease;
		}	
		if((timeRemaining<=0.0f)&&(timeRemaining>-10.0f)){
			use_item(item_in_use.return_type());
			timeRemaining = -10.0f;
		}	
	}
	public void use_item(Item.Items itemx){
		switch(itemx){
			case Item.Items.Light:
				print("LIGHT STUFF");
			break;
			case Item.Items.Drone:
				Vector3 DronePosition = new Vector3(mainCamera.transform.position.x, 500.0f, mainCamera.transform.position.z); //chose pos based on first person camera
				droneCamera.transform.position = DronePosition;
				mainCamera.enabled = !mainCamera.enabled;
				droneCamera.enabled = !droneCamera.enabled;
			break;
			case Item.Items.Weapon:	
				print("WEAPON STUFF");
			break;
			case Item.Items.Other:
				print("OTHER");
			break;
		}
	}
	public void end_use(Item.Items itemx){
			switch(itemx){
			case Item.Items.Light:
				print("LIGHT STUFF");
			break;
			case Item.Items.Drone:
				mainCamera.enabled = !mainCamera.enabled;
				droneCamera.enabled = !droneCamera.enabled;
			break;
			case Item.Items.Weapon:	
				print("WEAPON STUFF");
			break;
			case Item.Items.Other:
				print("OTHER");
			break;
		}
	}

}
