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
		
		switch (itemx){
			case Items.Light:
				ItemName = "Torch";	
				timeRemaining = 10.0f;
				ItemDescription = "The torch can be used to light your path in the maze. You can use this item for " + timeRemaining.ToString() + " seconds.";
				a = Items.Light;
				break;
			case Items.Drone:
				timeRemaining = 5.0f;
				ItemName = "Drone";
				ItemDescription = "Use this item to preview the maze. You can use this item for " + timeRemaining.ToString() + " seconds.";
				a = Items.Drone;
				break;
			case Items.Weapon:
				timeRemaining = 7.0f;
				ItemName = "Weapon";
				ItemDescription = "Use this item to fight enemies. You can use this item for " + timeRemaining.ToString() + " seconds.";
				a = Items.Weapon;
			break;
			case Items.Other:
				ItemName = "Ladder";
				ItemDescription = "Use this item to climb over the hedge. You can use this item once.";
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
	public int return_number_of_items(Items itemx){
		switch(itemx){
			case Items.Light:
				return item_no[0];
			case Items.Drone:
				return item_no[1];
			case Items.Weapon:
				return item_no[2];
			case Items.Other:
				return item_no[3];
		}
		return 0;
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
