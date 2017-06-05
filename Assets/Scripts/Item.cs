using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item {
	private string ItemName;
	private string ItemDescription;
	private float use_time;
	private float timeRemaining;
	private int number_of_items = 0;
	static public int [] item_no = new int [4] {0,0,0,0};

	public string getName(){
		return ItemName;
	}
	public string getDescription(){
		return ItemDescription;

	}
	public enum Items {Light, Drone, Weapon, Other};
	private Items a;

	public Item(Items itemx){
		timeRemaining = 5.0f;
		switch (itemx){
			case Items.Light:
				ItemName = "Lamp";	
				ItemDescription = "Use this item to light maze. You can use this item for " + use_time.ToString() + " seconds";
				a = Items.Light;
				break;
			case Items.Drone:
				ItemName = "Drone";
				ItemDescription = "Use this item to preview the maze";
				a = Items.Drone;
				break;
			case Items.Weapon:
				ItemName = "Weapon";
				ItemDescription = "Use this item to fight enemies";
				a = Items.Weapon;
			break;
			case Items.Other:
				ItemName = "Ladder";
				ItemDescription = "Use this item to climb over the hedge";
				a = Items. Other;
			break;
		}
	}
	public float return_remaining_time(){
		return timeRemaining;
	}
	public Items return_type(){
		return a;
	}
	public int return_number_of_items(){
		return item_no[0];
	}
	public void increase_number(Items itemx){
		switch(itemx){
			case Items.Light:
				item_no[0] += 1;
			break;
			case Items.Drone:
				item_no[1] += 1;
			break;
			case Items.Weapon:
				item_no[2] += 1;
			break;
			case Items.Other:
				item_no[3] += 1;
			break;
		}
	}

}
