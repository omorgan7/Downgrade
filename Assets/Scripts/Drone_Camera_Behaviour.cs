using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Camera_Behaviour : MonoBehaviour {

	public GameObject firstPerson;
	public Camera droneCamera;
	private Camera mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = firstPerson.GetComponent<Camera>();
		if(mainCamera==null){
			print("camera is null");
		}
		mainCamera.enabled = true;
		droneCamera.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		// if (Input.GetKeyDown(KeyCode.C)) { // if c code pressed then swap cameras.

		// 	Vector3 DronePosition = new Vector3(mainCamera.transform.position.x, 20.0f, mainCamera.transform.position.z); //chose pos based on first person camera
		// 	droneCamera.transform.position = DronePosition;
		// 	mainCamera.enabled = !mainCamera.enabled;
		// 	droneCamera.enabled = !droneCamera.enabled;
		// }
	}
}
