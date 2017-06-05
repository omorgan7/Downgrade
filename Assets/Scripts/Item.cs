using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	private string ItemName;
	private string ItemDescription;
	private int Item_int;

	public string getName(){
		return ItemName;
	}
	public string getDescription(){
		return ItemDescription;

	}
	public Item(int i ){
		Item_int = i;
		if(i == 0){
			ItemName = "Lamp";
			ItemDescription = "Use this item to light maze";
		}	
	
		if(i == 1){
			ItemName = "Drone";
			ItemDescription = "Use this item to preview the maze";
		}
		if(i==2){
			ItemName = "Weapon";
			ItemDescription = "Use this item to fight enemies";

		}
		if(i==3){
			ItemName = "Other";
			ItemDescription = "Other item maybe?";
		}
	}
}
