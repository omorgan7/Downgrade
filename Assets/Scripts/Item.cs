using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	private string ItemName;
	private string ItemDescription;
	private float use_time;
	private float timeRemaining;


	public string getName(){
		return ItemName;
	}
	public string getDescription(){
		return ItemDescription;

	}
	public enum Items {Light, Drone, Weapon, Other};
	private Items a;

	public Item(Items itemx){
		use_time = 10.0f;
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
				ItemName = "Other";
				ItemDescription = "Other item maybe?";
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
}
