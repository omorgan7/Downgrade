using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItems : MonoBehaviour {
	private Camera droneCamera;
	public Camera mainCamera;
	private GameObject firstPerson;
	public Button use;
	public GameObject parent;
	public Item item_in_use;
	// Use this for initialization
	void Start () {
		use.onClick.AddListener(TaskOnClick);
		ItemDescription data = parent.GetComponent<ItemDescription>();
		print(data==null);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		public void use_item(Item.Items itemx){
		switch(itemx){
			case Item.Items.Light:
				print("LIGHT STUFF");
			break;
			case Item.Items.Drone:
				Vector3 DronePosition = new Vector3(mainCamera.transform.position.x, 20.0f, mainCamera.transform.position.z); //chose pos based on first person camera
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
	void TaskOnClick(){
		Destroy(parent);
	//	use_item(current_item.return_type());
		GameObject canvas = GameObject.Find("Inventory");
		canvas.SetActive(false);
	}
}
