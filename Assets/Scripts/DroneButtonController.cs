﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneButtonController : MonoBehaviour {
	public Button yourButton;
	public GameObject ItemName;
	public GameObject Number;
	public GameObject ItemDescription;
	private GameObject box;
	private Item item;
	private Text itemname;
	private Text itemNumber;
	private int number_of_item = 0;
	

	// Use this for initialization
	void Start () {
		item = new Item(Item.Items.Drone);
		yourButton.onClick.AddListener(TaskOnClick);
		itemname = ItemName.GetComponent<Text>();
		itemNumber = Number.GetComponent<Text>();
		itemname.text = item.getName();
		itemNumber.text = (Item.item_no[1]).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		itemNumber.text = (Item.item_no[1]).ToString();
	}
	void TaskOnClick(){
		box = Instantiate(ItemDescription, Vector3.zero, Quaternion.identity);
		GameObject boxPanel= GameObject.Find("DescriptionPanel");
		ItemDescription data = boxPanel.GetComponent<ItemDescription>();
		data.SetUp(item);		
	}
}