using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour {
	private Camera droneCamera;
	private Camera mainCamera;
	private GameObject firstPerson;
	public GameObject ItemName;
	public GameObject Item_Description;
	private Text item_name;
	private Text description;
	public Button close;
	public Button use;
	public GameObject parent;
	private Item current_item;
	public Image parent_image;
	private GameObject inv;

	// Use this for initialization
	void Start () {
		item_name = ItemName.GetComponent<Text>();
		description = Item_Description.GetComponent<Text>();
		close.onClick.AddListener(TaskOnClick);
		use.onClick.AddListener(TaskOnClickUse);
		firstPerson = GameObject.Find("FirstPersonCharacter");
		mainCamera = firstPerson.GetComponent<Camera>();
		GameObject drone = GameObject.Find("Drone_Camera");
		droneCamera = drone.GetComponent<Camera>();
		inv = GameObject.Find("Inventory");

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetUp(Item newItem ){
		current_item = newItem;
		item_name = ItemName.GetComponent<Text>();
		description = Item_Description.GetComponent<Text>();
		item_name.text = newItem.getName();
		description.text = newItem.getDescription();
	}
	void TaskOnClick(){
		Destroy(parent);
	}

	void TaskOnClickUse(){
		Destroy(parent);
		inv.SetActive(false);
		UseItems.item_in_use = current_item;
		UseItems.USE = 1;
	}
}
