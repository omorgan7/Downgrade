using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCube : MonoBehaviour {
	public Item Weapon;
	// Use this for initialization
	void Start () {
		Weapon = new Item(Item.Items.Weapon);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
