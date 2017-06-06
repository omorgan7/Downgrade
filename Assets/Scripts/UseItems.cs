using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
using Random = UnityEngine.Random;

public class UseItems : MonoBehaviour {
	public Camera droneCamera;
	private Camera mainCamera;
	public GameObject firstPerson;
	public GameObject torch;
	static public Item item_in_use;
	static public int USE = 0;
	private float timeRemaining = -10.0f;
	private float startTime = 0.0f;
	private float timeincrease = 0.0f;
	static public int LADDER = 0;
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
			end_use(item_in_use.return_type());
			timeRemaining = -10.0f;
		}	
	}
	public void use_item(Item.Items itemx){
		switch(itemx){
			case Item.Items.Light:
				if(Item.item_no[0]>0){
					torch.SetActive(true);
					print("LIGHT STUFF");
					Item.item_no[0] = Item.item_no[0]-1;
				}
			break;
			case Item.Items.Drone:
				if(Item.item_no[1]>0){
					Vector3 DronePosition = new Vector3(mainCamera.transform.position.x, 100.0f, mainCamera.transform.position.z); //chose pos based on first person camera
					droneCamera.transform.position = DronePosition;
					mainCamera.enabled = !mainCamera.enabled;
					droneCamera.enabled = !droneCamera.enabled;
					Item.item_no[1] = Item.item_no[1]-1;
				}
			break;
			case Item.Items.Weapon:	
				if(Item.item_no[2]>0){
					Vector3 temp = new Vector3(Random.Range(0,10), 0.0f, Random.Range(0,10));
					GameObject g = GameObject.Find("FPSController");
					g.transform.position += temp;
					print("WEAPON STUFF");
					Item.item_no[2] = Item.item_no[2]-1;
				}
			break;
			case Item.Items.Other:
				if(Item.item_no[3]>0){
					GameObject g = GameObject.Find("FPSController");
					FirstPersonController person = g.GetComponent<FirstPersonController>();
					person.m_JumpSpeed = 2.0f*person.m_JumpSpeed;
					print("OTHER");
					Item.item_no[3] = Item.item_no[3] -1;
				}
			break;
		}
	}
	public void end_use(Item.Items itemx){
			switch(itemx){
			case Item.Items.Light:
			torch.SetActive(false);
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
			GameObject g = GameObject.Find("FPSController");
				FirstPersonController person = g.GetComponent<FirstPersonController>();
				person.m_JumpSpeed = 0.5f*person.m_JumpSpeed;
				print("OTHER");
			break;
		}
	}

}
